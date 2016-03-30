using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Root.Reports;

namespace Locadora
{
    public partial class DevolverFilme : Form
    {
        Inicial frmInicial;
        public int cli_cod = 0;
        public int dvd_cod = 0;
        public DateTime loc_dataLocacao = new DateTime();
        public DateTime loc_dataPrevistaDevolucao = new DateTime();
        public String dataLoc = "";

        public string Locacao
        {
            set 
            { 
                txtLocacao.Text = value;
                txtLocacao.BackColor = Color.White;
            }
        }

        public DevolverFilme(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        public void AtualizarInformacoesDevolucao()
        {
            if (dvd_cod > 0)
            {
                string query = "SELECT cla_valor FROM classificacao INNER JOIN dvd ON " + 
                "classificacao.cla_cod = dvd.cla_cod where dvd_cod = " + dvd_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable classificacao = new DataTable();
                da.Fill(classificacao);

                if (classificacao.Rows.Count > 0)
                {
                    txtDataLocacao.Text = loc_dataLocacao.ToShortDateString();
                    txtDataPrevistaDevolucao.Text = loc_dataPrevistaDevolucao.ToShortDateString();
                    int atraso = DateTime.Now.Subtract(loc_dataPrevistaDevolucao).Days;
                    if (atraso > 0)
                        atraso = atraso * 4;
                    else
                        atraso = 0;
                    txtMulta.Text = Convert.ToString(atraso + ",00");
                    txtValor.Text = Convert.ToString(Convert.ToDecimal(classificacao.Rows[0]["cla_valor"]) + atraso);
                }
            }
        }

        private void DevolverFilme_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        private void Inicializa()
        {
            btnPesquisaLocacao.Focus();
            btnPesquisaLocacao.TabIndex = 0;
            btnLimpar.TabIndex = 1;
            btnDevolver.TabIndex = 2;
        }

        private bool VerificarCamposObrigatorios()
        {
            if (cli_cod <= 0 && dvd_cod <= 0)
            {
                txtLocacao.BackColor = Color.MistyRose;
                return false;
            }

            return true;
        }

        private void GerarComprovanteDevolucao()
        {
            Report relatorioPdf = new Report(new PdfFormatter());

            FontDef tipoFont = new FontDef(relatorioPdf, FontDef.StandardFont.TimesRoman);
            FontProp tamanhoFont = new FontProp(tipoFont, 10);
            FontProp tamanhoFontRodape = new FontProp(tipoFont, 8);

            Root.Reports.Page PDFpagina = new Root.Reports.Page(relatorioPdf);

            int atraso = DateTime.Now.Subtract(loc_dataPrevistaDevolucao).Days;
            string valorLocacao = (Convert.ToDecimal(txtValor.Text) - Convert.ToDecimal(txtMulta.Text)).ToString();

            PDFpagina.AddCB_MM(10, new RepString(tamanhoFont, "Cliente: " + txtLocacao.Text.Split('-')[0]));
            PDFpagina.AddCB_MM(17, new RepString(tamanhoFont, "Filme:" + txtLocacao.Text.Split('-')[1]));
            PDFpagina.AddCB_MM(24, new RepString(tamanhoFont, "Data da locação: " + txtDataLocacao.Text));
            PDFpagina.AddCB_MM(31, new RepString(tamanhoFont, "Data prevista para devolução: " + txtDataPrevistaDevolucao.Text));
            PDFpagina.AddCB_MM(38, new RepString(tamanhoFont, "Data da devolução: " + DateTime.Now.ToShortDateString()));
            PDFpagina.AddCB_MM(45, new RepString(tamanhoFont, "Dias de atraso: " + ((atraso > 0) ? atraso.ToString() : "0")));
            PDFpagina.AddCB_MM(52, new RepString(tamanhoFont, "Valor da locação: R$ " + valorLocacao));
            PDFpagina.AddCB_MM(59, new RepString(tamanhoFont, "Valor da multa: R$ " + txtMulta.Text));
            PDFpagina.AddCB_MM(66, new RepString(tamanhoFont, "Valor total: R$ " + txtValor.Text));
            PDFpagina.AddCB_MM(76, new RepString(tamanhoFontRodape, "Comprovante emitido em " + DateTime.Now.ToString()));

            try
            {
                //visualiza o PDF
                RT.ViewPDF(relatorioPdf, "Devolução.pdf");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gerar comprovante.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Limpar()
        {
            txtLocacao.Clear();
            txtDataLocacao.Clear();
            txtDataPrevistaDevolucao.Clear();
            txtMulta.Clear();
            txtValor.Clear();
            cli_cod = 0;
            dvd_cod = 0;
            loc_dataLocacao = new DateTime();
            loc_dataPrevistaDevolucao = new DateTime();
            Inicializa();
        }

        private void Devolver()
        {
            try
            {
                string query = "UPDATE locacao SET loc_situacao = 1, loc_dataDevolucao = '" + DateTime.Now.ToString() +
                "', loc_valorMulta = '" + txtMulta.Text.Replace(',', '.') + "' WHERE dvd_cod = " + dvd_cod +
                " AND loc_dataLocacao = CONVERT(datetime, '" + Convert.ToDateTime(dataLoc).ToString("yyyy-MM-dd HH:mm:ss") + 
                "', 120)";

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                query = "UPDATE dvd SET dvd_situacao = 0 WHERE dvd_cod = " + dvd_cod;

                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                DialogResult cadastrarNovo = MessageBox.Show("Devolução efetuada com sucesso. Deseja gerar comprovante de devolução?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cadastrarNovo == DialogResult.Yes)
                    GerarComprovanteDevolucao();
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao devolver filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos de devolução?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposObrigatorios())
            {
                Devolver();
            }
            else
            {
                MessageBox.Show("Os campos com * são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPesquisaLocacao_Click(object sender, EventArgs e)
        {
            ConsultarLocacao frmLocacao = new ConsultarLocacao(this);
            frmLocacao.pesquisandoDevolucao = true;
            this.Enabled = false;
            frmLocacao.Show();
        }

        private void DevolverFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
