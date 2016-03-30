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
    public partial class CadastrarFilme : Form
    {
        public int dvd_cod;
        ConsultarFilme frmFilme;
        Inicial frmInicial;

        public CadastrarFilme(Inicial ini)
        {
            InitializeComponent();
            btnExcluir.Visible = false;
            frmInicial = ini;
        }

        public CadastrarFilme(ConsultarFilme fil)
        {
            InitializeComponent();
            frmFilme = fil;
            btnSalvar.Text = "Alterar";
            btnExcluir.Visible = true;
        }

        private void CarregarDadosFilme()
        {
            try
            {
                string query = "SELECT dvd_nome, dvd_sinopse, dvd_diretor, dvd_anoLancamento, " +
                "gen_cod, cla_cod FROM dvd WHERE dvd_cod = " + dvd_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable filme = new DataTable();
                da.Fill(filme);

                if (filme.Rows.Count > 0)
                {
                    txtNome.Text = filme.Rows[0]["dvd_nome"].ToString();
                    txtSinopse.Text = filme.Rows[0]["dvd_sinopse"].ToString();
                    txtDiretor.Text = filme.Rows[0]["dvd_diretor"].ToString();
                    txtAnoLancamento.Text = filme.Rows[0]["dvd_anoLancamento"].ToString();
                    cbClassificacao.SelectedValue = filme.Rows[0]["cla_cod"].ToString();
                    cbGenero.SelectedValue = filme.Rows[0]["gen_cod"].ToString();
                }
                else
                {
                    MessageBox.Show("Filme não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void CadastrarFilme_Load(object sender, EventArgs e)
        {
            Inicializa();
            CarregarGeneros(cbGenero);
            CarregarClassificacoes(cbClassificacao);

            if (btnSalvar.Text.Equals("Alterar")) 
                CarregarDadosFilme();
            
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
                    MessageBox.Show("Não existem gêneros cadastrados. Antes de cadastrar um filme, cadastre pelo menos um tipo de gênero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.Close(); 
                    Close();
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
                    MessageBox.Show("Não existem classificações cadastradas. Antes de cadastrar um filme, cadastre pelo menos um tipo de classificação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.Close(); 
                    Close();
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
            txtNome.Focus();
            txtNome.TabIndex = 0;
            txtSinopse.TabIndex = 1;
            txtAnoLancamento.TabIndex = 2;
            txtDiretor.TabIndex = 3;
            cbGenero.TabIndex = 4;
            cbClassificacao.TabIndex = 5;
            btnExcluir.TabIndex = 6;
            btnLimpar.TabIndex = 7;
            btnSalvar.TabIndex = 8;
        }

        private bool VerificaCamposObrigatorios()
        {
            bool retorno = true;

            if(txtNome.Text.Equals(""))
            {
                txtNome.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (cbGenero.SelectedIndex <= 0)
            {
                cbGenero.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (cbClassificacao.SelectedIndex <= 0)
            {
                cbClassificacao.BackColor = Color.MistyRose;
                retorno = false;
            }

            return retorno;
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtSinopse.Clear();
            txtAnoLancamento.Clear();
            txtDiretor.Clear();
            cbGenero.SelectedIndex = 0;
            cbClassificacao.SelectedIndex = 0;
            Inicializa();
        }

        private void Salvar()
        {
            if (btnSalvar.Text.Equals("Salvar"))
            {
                try
                {
                    string query = "INSERT INTO dvd (dvd_nome, dvd_sinopse, dvd_diretor, " +
                                    "dvd_anoLancamento, dvd_situacao, gen_cod, cla_cod) VALUES('" + txtNome.Text.Replace("'", "''") +
                                    "','" + txtSinopse.Text.Replace("'", "''") + "','" + txtDiretor.Text.Replace("'", "''") +
                                    "','" + txtAnoLancamento.Text.Replace("'", "''") + "','0','" + cbGenero.SelectedValue +
                                    "','" + cbClassificacao.SelectedValue + "')";

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    DialogResult cadastrarNovo = MessageBox.Show("Filme salvo com sucesso. Deseja cadastrar um novo filme?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cadastrarNovo == DialogResult.Yes)
                        Limpar();
                    else
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (btnSalvar.Text.Equals("Salvar"))
            {
                try
                {
                    string query = "UPDATE dvd SET dvd_nome = '" + txtNome.Text.Replace("'", "''") + 
                    "', dvd_sinopse = '" + txtSinopse.Text.Replace("'", "''") + "', dvd_diretor = '" 
                    + txtDiretor.Text.Replace("'", "''") +"', dvd_anoLancamento = '" + 
                    txtAnoLancamento.Text.Replace("'", "''") + "', gen_cod = '" + cbGenero.SelectedValue + 
                    "', cla_cod = '" + cbClassificacao.SelectedValue + "' WHERE dvd_cod = " + dvd_cod;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Filme alterado com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFilme.atualizaPesquisa();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos de cadastro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCamposObrigatorios())
            {
                if (Convert.ToInt32(txtAnoLancamento.Text) > 1800)
                {
                    Salvar();
                }
                else
                {
                    MessageBox.Show("Digite um ano válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Os campos com * são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT dvd_cod FROM locacao WHERE dvd_cod = " + dvd_cod;
                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable locacao = new DataTable();
                da.Fill(locacao);

                if (locacao.Rows.Count > 0)
                    MessageBox.Show("Esse filme possui registro(s) de locação. Não é possível excluí-lo.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    query = "DELETE FROM dvd WHERE dvd_cod = " + dvd_cod;

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Filme excluído com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFilme.atualizaPesquisa();
                    Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir filme. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CadastrarFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
            if (frmFilme != null)
                frmFilme.Enabled = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.White;
        }

        private void cbGenero_TextChanged(object sender, EventArgs e)
        {
            cbGenero.BackColor = Color.White;
        }

        private void cbClassificacao_TextChanged(object sender, EventArgs e)
        {
            cbClassificacao.BackColor = Color.White;
        }
    }
}
