using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Locadora
{
    public partial class ConsultarFilme : Form
    {
        public bool locarFilme = false;
        public bool pesquisandoLocacao = false;
        LocarFilme frmLocarFilme;
        ConsultarLocacao frmConsultarLocacao;
        Inicial frmInicial;

        public ConsultarFilme(Inicial ini)
        {
            InitializeComponent();
            cbSituacao.SelectedIndex = 0;
            frmInicial = ini;
        }

        public ConsultarFilme(LocarFilme loc)
        {
            InitializeComponent();
            frmLocarFilme = loc;
            cbSituacao.SelectedIndex = 1;
            cbSituacao.Enabled = false;
        }

        public ConsultarFilme(ConsultarLocacao loc)
        {
            InitializeComponent();
            frmConsultarLocacao = loc;
        }

        public void atualizaPesquisa()
        {
            btnPesquisar_Click(new object(), new EventArgs());
        }

        private void ConsultarFilme_Load(object sender, EventArgs e)
        {
            CadastrarFilme cFilme = new CadastrarFilme(this);
            cFilme.CarregarClassificacoes(cbClassificacao);
            cFilme.CarregarGeneros(cbGenero);
            Inicializa();
        }

        public void Inicializa()
        {
            txtNome.Focus();
            txtNome.TabIndex = 0;
            txtDiretor.TabIndex = 1;
            txtAnoLancamento.TabIndex = 2;
            cbGenero.TabIndex = 3;
            cbClassificacao.TabIndex = 4;
            cbSituacao.TabIndex = 5;
            btnLimpar.TabIndex = 6;
            btnPesquisar.TabIndex = 7;
            lblMesagem.Text = "";
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtDiretor.Clear();
            txtAnoLancamento.Clear();
            cbGenero.SelectedIndex = 0;
            cbClassificacao.SelectedIndex = 0;
            cbSituacao.SelectedIndex = 0;
            dgvFilme.DataSource = new DataTable();
            Inicializa();
        }

        private void Pesquisar()
        {
            try
            {
                string where = "";

                if (!txtNome.Text.Equals(""))
                    where = " WHERE dvd_nome LIKE '%" + txtNome.Text.Replace("'", "''") + "%'";
                if (!txtDiretor.Text.Equals(""))
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " dvd_diretor LIKE '%" + txtDiretor.Text + "%'"; 
                if (!txtAnoLancamento.Text.Equals(""))
                {
                    if (txtAnoLancamento.Text.Length == 4)
                    {
                        where += ((where.Equals("")) ? " WHERE" : " AND") + " dvd_anoLancamento LIKE '" + txtAnoLancamento.Text + "'";
                    }
                    else
                    {
                        MessageBox.Show("Digite um ano válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtAnoLancamento.Focus();
                        where = "false";
                    }
                }
                if (cbGenero.SelectedIndex > 0)
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " dvd.gen_cod = '" + cbGenero.SelectedValue.ToString() + "'";
                if (cbClassificacao.SelectedIndex > 0)
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " dvd.cla_cod = '" + cbClassificacao.SelectedValue.ToString() + "'";
                if (cbSituacao.SelectedIndex > 0)
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " dvd_situacao = " + (cbSituacao.Text.Equals("Disponível") ? "0" : "1");

                if (!where.Equals("false"))
                {
                    string query = "SELECT dvd_cod, dvd_nome, dvd_sinopse, dvd_diretor, dvd_anoLancamento, " +
                    "CASE dvd_situacao WHEN 0 THEN 'Disponível' ELSE 'Locado' END dvd_situacao, gen_descricao, " +
                    "cla_descricao FROM dvd INNER JOIN genero ON dvd.gen_cod = genero.gen_cod INNER JOIN classificacao " +
                    "ON dvd.cla_cod = classificacao.cla_cod" + where;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable filme = new DataTable();
                    da.Fill(filme);

                    if (filme.Rows.Count > 0)
                    {
                        lblMesagem.Text = filme.Rows.Count + ((filme.Rows.Count > 1) ? " registros." : " registro.");
                        lblMesagem.ForeColor = Color.Black;

                        dgvFilme.DataSource = filme;
                        dgvFilme.Columns["dvd_cod"].Visible = false;
                        dgvFilme.Columns["dvd_nome"].HeaderText = "Nome";
                        dgvFilme.Columns["dvd_sinopse"].HeaderText = "Sinopse";
                        dgvFilme.Columns["dvd_diretor"].HeaderText = "Diretor";
                        dgvFilme.Columns["dvd_anoLancamento"].HeaderText = "Ano lançamento";
                        dgvFilme.Columns["dvd_situacao"].HeaderText = "Situação";
                        dgvFilme.Columns["gen_descricao"].HeaderText = "Gênero";
                        dgvFilme.Columns["cla_descricao"].HeaderText = "Classificação";
                    }
                    else
                    {
                        lblMesagem.Text = "Não foram encontrados registros.";
                        lblMesagem.ForeColor = Color.Red;
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos de pesquisa?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvFilme.DataSource = new DataTable();
            Pesquisar();
        }

        private void dgvFilme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (locarFilme)
            {
                int index = e.RowIndex;
                frmLocarFilme.dvd_cod = Convert.ToInt32(dgvFilme.Rows[index].Cells["dvd_cod"].Value);
                frmLocarFilme.Filme = dgvFilme.Rows[index].Cells["dvd_nome"].Value.ToString();

                locarFilme = false;
                frmLocarFilme.AtualizarInformacoesLocacao();
                Close();
            }
            else if (pesquisandoLocacao)
            {
                int index = e.RowIndex;
                frmConsultarLocacao.dvd_cod = Convert.ToInt32(dgvFilme.Rows[index].Cells["dvd_cod"].Value);
                frmConsultarLocacao.Filme = dgvFilme.Rows[index].Cells["dvd_nome"].Value.ToString();

                pesquisandoLocacao = false;
                Close();
            }
            else
            {
                CadastrarFilme cFilme = new CadastrarFilme(this);
                int index = e.RowIndex;
                cFilme.dvd_cod = Convert.ToInt32(dgvFilme.Rows[index].Cells["dvd_cod"].Value);
                this.Enabled = false;
                cFilme.Show();
            }
        }

        private void ConsultarFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
            if (frmConsultarLocacao != null)
                frmConsultarLocacao.Enabled = true;
            if (frmLocarFilme != null)
                frmLocarFilme.Enabled = true;
        }
    }
}
