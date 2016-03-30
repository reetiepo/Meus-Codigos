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
    public partial class LocarFilme : Form
    {
        Inicial frmInicial;
        public int cli_cod = 0;
        public int dvd_cod = 0;

        public string Cliente
        {
            set {
                txtCliente.Text = value;
                txtCliente.BackColor = Color.White;
            }
        }

        public string Filme
        {
            set { 
                txtFilme.Text = value; 
                txtFilme.BackColor = Color.White; 
            }
        }

        public LocarFilme(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        public void AtualizarInformacoesLocacao()
        {
            if (dvd_cod > 0)
            {
                string query = "SELECT cla_valor, cla_tempo FROM classificacao INNER JOIN dvd ON " + 
                "classificacao.cla_cod = dvd.cla_cod where dvd_cod = " + dvd_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable classificacao = new DataTable();
                da.Fill(classificacao);

                if (classificacao.Rows.Count > 0)
                {
                    txtValor.Text = classificacao.Rows[0]["cla_valor"].ToString();
                    txtDataLocacao.Text = DateTime.Now.ToShortDateString();
                    txtDevolverEm.Text = DateTime.Now.AddDays(Convert.ToInt32(classificacao.Rows[0]["cla_tempo"])).ToShortDateString();
                }
            }
        }

        private void LocarFilme_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        private void Inicializa()
        {
            btnPesquisaCliente.Focus();
            btnPesquisaCliente.TabIndex = 0;
            btnPesquisarFilme.TabIndex = 1;
            btnLimpar.TabIndex = 2;
            btnLocar.TabIndex = 3;
        }

        private bool VerificaCamposObrigatorios()
        {
            bool retorno = true;

            if (cli_cod <= 0)
            {
                txtCliente.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (dvd_cod <= 0)
            {
                txtFilme.BackColor = Color.MistyRose;
                retorno = false;
            }

            return retorno;
        }

        private void GerarComprovanteLocacao()
        {
            Report relatorioPdf = new Report(new PdfFormatter());

            FontDef tipoFont = new FontDef(relatorioPdf, FontDef.StandardFont.TimesRoman);
            FontProp tamanhoFont = new FontProp(tipoFont, 10);
            FontProp tamanhoFontRodape = new FontProp(tipoFont, 8);

            Root.Reports.Page PDFpagina = new Root.Reports.Page(relatorioPdf) ;

            PDFpagina.AddCB_MM(10, new RepString(tamanhoFont, "Cliente: " + txtCliente.Text));
            PDFpagina.AddCB_MM(17, new RepString(tamanhoFont, "Filme: " + txtFilme.Text));
            PDFpagina.AddCB_MM(24, new RepString(tamanhoFont, "Data da locação: " + txtDataLocacao.Text));
            PDFpagina.AddCB_MM(31, new RepString(tamanhoFont, "Data prevista para devolução: " + txtDevolverEm.Text));
            PDFpagina.AddCB_MM(38, new RepString(tamanhoFont, "Valor da locação: R$ " + txtValor.Text));
            PDFpagina.AddCB_MM(48, new RepString(tamanhoFontRodape, "Comprovante emitido em " + DateTime.Now.ToString()));

            try
            {
                //visualiza o PDF
                RT.ViewPDF(relatorioPdf, "Locação.pdf");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gerar comprovante.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Limpar()
        {
            txtCliente.Clear();
            txtFilme.Clear();
            txtDataLocacao.Clear();
            txtDevolverEm.Clear();
            txtValor.Clear();
            cli_cod = 0;
            dvd_cod = 0;;
            Inicializa();
        }

        private void Locar()
        {
            try
            {
                string query = "INSERT INTO locacao (dvd_cod, loc_dataLocacao, loc_dataPrevistaDevolucao, " +
                               "loc_situacao, cli_cod) VALUES('" + dvd_cod + "','" + DateTime.Now.ToString() + 
                               "','" + txtDevolverEm.Text + "','0','" + cli_cod + "'); " +
                               "UPDATE dvd SET dvd_situacao = 1 WHERE dvd_cod = " + dvd_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                DialogResult cadastrarNovo = MessageBox.Show("Locação efetuada com sucesso. Deseja gerar comprovante de locação?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cadastrarNovo == DialogResult.Yes)
                    GerarComprovanteLocacao();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao locar filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos de locação?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCamposObrigatorios())
            {
                Locar();
            }
            else
            {
                MessageBox.Show("Os campos com * são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPesquisaCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente frmCliente = new ConsultarCliente(this);
            frmCliente.locarFilme = true;
            this.Enabled = false;
            frmCliente.Show();
        }

        private void btnPesquisarFilme_Click(object sender, EventArgs e)
        {
            ConsultarFilme frmFilme = new ConsultarFilme(this);
            frmFilme.locarFilme = true;
            this.Enabled = false;
            frmFilme.Show();
        }

        private void LocarFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
