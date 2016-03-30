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
    public partial class RelatorioFilme : Form
    {
        Inicial frmInicial;

        public RelatorioFilme(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        private void RelatorioFilme_Load(object sender, EventArgs e)
        {
            Inicializa();
            CarregarGeneros(cbGenero);
            CarregarClassificacoes(cbClassificacao);
            rbPorGenero.Checked = true;  
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
            rbPorGenero.TabIndex = 0;
            rbPorClassificacao.TabIndex = 1;
            rbPorMes.TabIndex = 2;
            rbPorAno.TabIndex = 3;
            cbGenero.TabIndex = 4;
            cbClassificacao.TabIndex = 5;
            txtDataIni.TabIndex = 6;
            txtDataFim.TabIndex = 7;
            btnLimpar.TabIndex = 8;
            btnGerarRelatorio.TabIndex = 9;
        }

        private void Limpar()
        {
            rbPorGenero.Checked = true;
            rbPorClassificacao.Checked = false;
            rbPorMes.Checked = false;
            rbPorAno.Checked = false;
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

        private void Relatorio(DataTable dt, string order)
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

                if (order.Equals("gen_descricao"))
                {
                    col = new TlmColumnMM(tlm, "Gênero", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Nome do Filme", 60);
                    col.tlmCellDef_Default.tlmTextMode = TlmTextMode.MultiLine;
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Classificação", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                }
                else if (order.Equals("cla_descricao"))
                {
                    col = new TlmColumnMM(tlm, "Classificação", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Nome do Filme", 60);
                    col.tlmCellDef_Default.tlmTextMode = TlmTextMode.MultiLine;
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Gênero", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                }
                else
                {
                    col = new TlmColumnMM(tlm, "Nome do Filme", 60);
                    col.tlmCellDef_Default.tlmTextMode = TlmTextMode.MultiLine;
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Classificação", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                    col = new TlmColumnMM(tlm, "Gênero", 36);
                    col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                    col.tlmCellDef_Default.rAlignH = RepObj.rAlignLeft;
                }
                col = new TlmColumnMM(tlm, "Qtd. de Locações", 30);
                col.tlmCellDef_Header.rAlignH = RepObj.rAlignLeft;
                col.tlmCellDef_Default.rAlignH = RepObj.rAlignRight;

                foreach (DataRow dr in dt.Rows)
                {
                    tlm.NewRow();
                    if (order.Equals("gen_descricao"))
                    {
                        tlm.Add(0, new RepString(tamanhoFont, (dr["gen_descricao"] != null ? dr["gen_descricao"].ToString() : "")));
                        tlm.Add(1, new RepString(tamanhoFont, (dr["dvd_nome"] != null ? dr["dvd_nome"].ToString() : "")));
                        tlm.Add(2, new RepString(tamanhoFont, (dr["cla_descricao"] != null ? dr["cla_descricao"].ToString() : "")));
                    }
                    else if (order.Equals("gen_descricao"))
                    {
                        tlm.Add(0, new RepString(tamanhoFont, (dr["cla_descricao"] != null ? dr["cla_descricao"].ToString() : "")));
                        tlm.Add(1, new RepString(tamanhoFont, (dr["dvd_nome"] != null ? dr["dvd_nome"].ToString() : "")));
                        tlm.Add(2, new RepString(tamanhoFont, (dr["gen_descricao"] != null ? dr["gen_descricao"].ToString() : "")));
                    }
                    else
                    {
                        tlm.Add(0, new RepString(tamanhoFont, (dr["dvd_nome"] != null ? dr["dvd_nome"].ToString() : "")));
                        tlm.Add(1, new RepString(tamanhoFont, (dr["cla_descricao"] != null ? dr["cla_descricao"].ToString() : "")));
                        tlm.Add(2, new RepString(tamanhoFont, (dr["gen_descricao"] != null ? dr["gen_descricao"].ToString() : "")));
                    }

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

            if (PDFpagina.iPageNo == 1)
            {
                tamanhoFontTitulo.bBold = true;
                PDFpagina.AddCT_MM(rPosLeft + (rPosRight - rPosLeft) / 2, 12, new RepString(tamanhoFontTitulo, "Relatório dos Filmes Mais Locados"));
                
                if (!data.Equals(""))
                {
                    PDFpagina.AddMM(rPosLeft, 20, new RepString(tamanhoFont, data));
                }
                
                ea.container.rHeightMM -= tamanhoFontTitulo.rLineFeedMM;
            }

            PDFpagina.AddMM(rPosLeft, 21, ea.container);
        }

        private void GerarRel()
        {
            try
            {
                string query = "";
                string where = "";
                string order = "";

                Uteis u = new Uteis();

                if (((!txtDataIni.Text.Equals("  /  /")) && (!u.ValidaData(txtDataIni.Text))) ||
                   ((!txtDataFim.Text.Equals("  /  /")) && (!u.ValidaData(txtDataFim.Text))))
                    MessageBox.Show("Digite data(s) válida(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (cbGenero.SelectedIndex > 0)
                        where = "WHERE genero.gen_cod = " + cbGenero.SelectedValue.ToString();
                    if (cbClassificacao.SelectedIndex > 0)
                        where += ((where.Equals("")) ? "WHERE" : " AND") + " classificacao.cla_cod = " + cbClassificacao.SelectedValue.ToString();
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

                    if (rbPorGenero.Checked)
                        order = "gen_descricao";
                    else if (rbPorClassificacao.Checked)
                        order = "cla_descricao";
                    else if (rbPorMes.Checked)
                        order = "MONTH";
                    else if (rbPorAno.Checked)
                        order = "YEAR";

                    if (rbPorGenero.Checked || rbPorClassificacao.Checked)
                    {
                        query = "SELECT dvd_nome, cla_descricao, gen_descricao, count(locacao.dvd_cod) qtdLoc FROM locacao " +
                        "INNER JOIN dvd ON locacao.dvd_cod = dvd.dvd_cod INNER JOIN classificacao ON dvd.cla_cod = " +
                        "classificacao.cla_cod INNER JOIN genero ON dvd.gen_cod = genero.gen_cod " + where + " GROUP BY " +
                        "dvd.dvd_cod, dvd_nome, cla_descricao, gen_descricao ORDER BY " + order + ", qtdLoc DESC";
                    }
                    else
                    {
                        query = "SELECT dvd_nome, cla_descricao, gen_descricao, " + order + "(loc_dataLocacao) as mesAnoLoc, " +
                        "count(locacao.dvd_cod) qtdLoc FROM locacao INNER JOIN dvd ON locacao.dvd_cod = dvd.dvd_cod " +
                        "INNER JOIN classificacao ON dvd.cla_cod = classificacao.cla_cod INNER JOIN genero ON dvd.gen_cod " +
                        "= genero.gen_cod " + where + " GROUP BY " + order + "(loc_dataLocacao), dvd_nome, cla_descricao, gen_descricao " +
                        "ORDER BY " + order + "(loc_dataLocacao), qtdLoc DESC";
                    }

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        Relatorio(dt, order);
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

        private void RelatorioFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
