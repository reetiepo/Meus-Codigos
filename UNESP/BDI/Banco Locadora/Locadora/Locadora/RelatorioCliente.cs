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
    public partial class RelatorioCliente : Form
    {
        Inicial frmInicial;

        public RelatorioCliente(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        private void RelatorioCliente_Load(object sender, EventArgs e)
        {
            Inicializa();
            CarregarGeneros(cbGenero);
            CarregarClassificacoes(cbClassificacao);
        }

        public void CarregarGeneros(ComboBox cb)
        {
            try
            {
                string query = "SELECT 0 gen_cod, 'Selecione um gênero' gen_descricao UNION SELECT gen_cod, gen_descricao FROM genero";

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);

                adpt.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cb.Items.Clear();
                    cb.DisplayMember = "gen_descricao";
                    cb.ValueMember = "gen_cod";
                    cb.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Não existem gêneros cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar gêneros. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        public void CarregarClassificacoes(ComboBox cb)
        {
            try
            {
                string query = "SELECT 0 cla_cod, 'Selecione uma classificação' cla_descricao UNION SELECT cla_cod, cla_descricao FROM classificacao";

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);

                adpt.Fill(ds);
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cb.Items.Clear();
                    cb.DisplayMember = "cla_descricao";
                    cb.ValueMember = "cla_cod";
                    cb.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Não existem classificações cadastradas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar classificações. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void Inicializa()
        {
            cbGenero.TabIndex = 0;
            cbClassificacao.TabIndex = 1;
            txtDataIni.TabIndex = 2;
            txtDataFim.TabIndex = 3;
            btnLimpar.TabIndex = 4;
            btnGerarRelatorio.TabIndex = 5;
        }

        private void Limpar()
        {
            cbGenero.SelectedIndex = 0;
            cbClassificacao.SelectedIndex = 0;
            txtDataIni.Clear();
            txtDataFim.Clear();
            Inicializa();
        }

        private Report relatorioPdf; 
        private FontDef tipoFont;
        private FontProp tamanhoFont;
        private FontProp tamanhoFontTitulo;
        private Double rPosLeft = 20;
        private Double rPosRight = 195;
        private Double rPosTop = 24;
        private Double rPosBottom = 278;
        private string data = "";

        private void Relatorio(DataTable dt)
        {
            relatorioPdf = new Report(new PdfFormatter());
            tipoFont = new FontDef(relatorioPdf, FontDef.StandardFont.Helvetica);
            tamanhoFont = new FontPropMM(tipoFont, 1.9);
            tamanhoFontTitulo = new FontPropMM(tipoFont, 3);

            TableLayoutManager tlm;
            using (tlm = new TableLayoutManager(tamanhoFont))
            {
                tlm.rContainerHeightMM = rPosBottom - rPosTop;
                tlm.tlmCellDef_Header.rAlignV = RepObj.rAlignCenter;
                tlm.tlmCellDef_Default.penProp_LineBottom = new PenProp(relatorioPdf, 0.05, Color.Black);
                tlm.tlmHeightMode = TlmHeightMode.AdjustLast;
                tlm.eNewContainer += new TableLayoutManager.NewContainerEventHandler(Tlm_NewContainer);

                TlmColumn col;

                col = new TlmColumnMM(tlm, "Nome do Cliente", 80);
                col.tlmCellDef_Default.tlmTextMode = TlmTextMode.MultiLine;
                col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                col = new TlmColumnMM(tlm, "Telefone", 26);
                col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                col = new TlmColumnMM(tlm, "E-mail", 26);
                col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                col = new TlmColumnMM(tlm, "Qtd. de Locações", 30);
                col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                col.tlmCellDef_Default.rAlignH = RepObj.rAlignRight;

                foreach (DataRow dr in dt.Rows)
                {
                    tlm.NewRow();
                    tlm.Add(0, new RepString(tamanhoFont, (dr["cli_nome"] != null ? dr["cli_nome"].ToString() : "")));
                    tlm.Add(1, new RepString(tamanhoFont, (dr["cli_telefone"] != null ? dr["cli_telefone"].ToString() : "")));
                    tlm.Add(2, new RepString(tamanhoFont, (dr["cli_email"] != null ? dr["cli_email"].ToString() : "")));
                    tlm.Add(3, new RepString(tamanhoFont, (dr["qtdLoc"] != null ? dr["qtdLoc"].ToString() : "")));
                }
            }

            try
            {
                //visualiza o PDF
                RT.ViewPDF(relatorioPdf, "Relatório.pdf");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao gerar relatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Tlm_NewContainer(Object oSender, TableLayoutManager.NewContainerEventArgs ea)
        {
            Page PDFpagina = new Page(relatorioPdf);

            int posicao = 18;

            if (PDFpagina.iPageNo == 1)
            {
                tamanhoFontTitulo.bBold = true;
                PDFpagina.AddCT_MM(rPosLeft + (rPosRight - rPosLeft) / 2, 12, new RepString(tamanhoFontTitulo, "Relatório dos Cliente que Mais Locam"));

                if (cbGenero.SelectedIndex > 0)
                {
                    posicao += 3;
                    PDFpagina.AddMM(rPosLeft, posicao, new RepString(tamanhoFont, "Gênero: " + cbGenero.Text));
                }
                if (cbClassificacao.SelectedIndex > 0)
                {
                    posicao += 3;
                    PDFpagina.AddMM(rPosLeft, posicao, new RepString(tamanhoFont, "Classificação: " + cbClassificacao.Text));
                }
                if (!data.Equals(""))
                {
                    posicao += 3;
                    PDFpagina.AddMM(rPosLeft, posicao, new RepString(tamanhoFont, data));
                }
                
                //ea.container.rHeightMM -= tamanhoFontTitulo.rLineFeedMM;
            }

            PDFpagina.AddMM(rPosLeft, posicao + 1, ea.container);
        }

        private void GerarRel()
        {
            try
            {
                string query = "";
                string where = "";

                Uteis u = new Uteis();

                if (((!txtDataIni.Text.Equals("  /  /")) && (!u.ValidaData(txtDataIni.Text))) ||
                   ((!txtDataFim.Text.Equals("  /  /")) && (!u.ValidaData(txtDataFim.Text))))
                    MessageBox.Show("Digite data(s) válida(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (cbGenero.SelectedIndex > 0)
                        where = "WHERE dvd.gen_cod = " + cbGenero.SelectedValue.ToString();
                    if (cbClassificacao.SelectedIndex > 0)
                        where += ((where.Equals("")) ? "WHERE" : " AND") + " dvd.cla_cod = " + cbClassificacao.SelectedValue.ToString();
                    if (u.ValidaData(txtDataIni.Text) && u.ValidaData(txtDataFim.Text))
                    {
                        where += ((where.Equals("")) ? "WHERE" : " AND") + " loc_dataLocacao BETWEEN CONVERT(datetime, '" +
                        Convert.ToDateTime(txtDataIni.Text).ToString("yyyy-MM-dd HH:mm:ss") + "', 120) AND CONVERT(datetime, '" +
                        Convert.ToDateTime(txtDataFim.Text).ToString("yyyy-MM-dd HH:mm:ss") + "', 120)";

                        data = "De " + txtDataIni.Text.ToString() + " até " + txtDataFim.Text.ToString();
                    }
                    else if (u.ValidaData(txtDataIni.Text))
                    {
                        where += ((where.Equals("")) ? "WHERE" : " AND") + " loc_dataLocacao >= CONVERT(datetime, '" +
                        Convert.ToDateTime(txtDataIni.Text).ToString("yyyy-MM-dd HH:mm:ss") + "', 120)";

                        data = "A partir de " + txtDataIni.Text.ToString();
                    }
                    else if (u.ValidaData(txtDataFim.Text))
                    {
                        where += ((where.Equals("")) ? "WHERE" : " AND") + " loc_dataLocacao <= CONVERT(datetime, '" +
                        Convert.ToDateTime(txtDataFim.Text).ToString("yyyy-MM-dd HH:mm:ss") + "', 120)";

                        data = "Até " + txtDataFim.Text.ToString();
                    }

                    if (cbGenero.SelectedIndex > 0 || cbClassificacao.SelectedIndex > 0)
                    {
                        query = "SELECT cli_nome, cli_telefone, cli_email, count(locacao.dvd_cod) qtdLoc FROM locacao " +
                        "INNER JOIN cliente ON locacao.cli_cod = cliente.cli_cod INNER JOIN dvd ON locacao.dvd_cod = " + 
                        " dvd.dvd_cod " + where + " GROUP BY locacao.cli_cod, cli_nome, cli_telefone, cli_email ORDER BY " +
                        " qtdLoc DESC";
                    }
                    else
                    {
                        query = "SELECT cli_nome, cli_telefone, cli_email, count(locacao.dvd_cod) qtdLoc FROM locacao " +
                        "INNER JOIN cliente ON locacao.cli_cod = cliente.cli_cod " + where + " GROUP BY locacao.cli_cod, " +
                        "cli_nome, cli_telefone, cli_email ORDER BY qtdLoc DESC";
                    }

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        Relatorio(dt);
                    else
                        MessageBox.Show("Sua pesquisa não retornou resultados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            GerarRel();
        }

        private void RelatorioCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }

    }
}
