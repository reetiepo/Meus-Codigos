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
    public partial class CadastrarGenero : Form
    {
        public int gen_cod;
        ConsultarGenero frmGenero;
        Inicial frmInicial;

        public CadastrarGenero(Inicial ini)
        {
            InitializeComponent();
            btnExcluir.Visible = false;
            frmInicial = ini;
        }

        public CadastrarGenero(ConsultarGenero gen)
        {
            InitializeComponent();
            frmGenero = gen;
            btnSalvar.Text = "Alterar";
            btnExcluir.Visible = true;
        }

        public void carregarDadosGenero()
        {
            try
            {
                string query = "SELECT gen_descricao, gen_prateleira FROM genero WHERE gen_cod = " + gen_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable genero = new DataTable();
                da.Fill(genero);

                if (genero.Rows.Count > 0)
                {
                    txtDescricao.Text = genero.Rows[0]["gen_descricao"].ToString();
                    txtPrateleira.Text = genero.Rows[0]["gen_prateleira"].ToString();
                }
                else
                {
                    MessageBox.Show("Gênero não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar gênero. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void CadastrarGenero_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        public void Inicializa()
        {
            txtDescricao.Focus();
            txtDescricao.TabIndex = 0;
            txtPrateleira.TabIndex = 1;
            btnExcluir.TabIndex = 2;
            btnLimpar.TabIndex = 3;
            btnSalvar.TabIndex = 4;
        }

        public bool VerificarCamposObrigatorios()
        {
            bool retorno = true;

            if (txtDescricao.Text.Equals(""))
            {
                txtDescricao.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtPrateleira.Text.Equals(""))
            {
                txtPrateleira.BackColor = Color.MistyRose;
                retorno = false;
            }

            return retorno;
        }

        private void Limpar()
        {
            txtDescricao.Clear();
            txtPrateleira.Clear();
            Inicializa();
        }

        private void Salvar()
        {
            if (btnSalvar.Text.Equals("Salvar"))
            {
                try
                {
                    string query = "INSERT INTO genero (gen_descricao, gen_prateleira) " +
                                    "VALUES('" + txtDescricao.Text.Replace("'", "''") +
                                    "','" + txtPrateleira.Text + "')";

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    DialogResult cadastrarNovo = MessageBox.Show("Gênero salvo com sucesso. Deseja cadastrar um novo gênero?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cadastrarNovo == DialogResult.Yes)
                        Limpar();
                    else
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar gênero. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (btnSalvar.Text.Equals("Alterar"))
            {
                try
                {
                    string query = "UPDATE genero SET gen_descricao = '" + txtDescricao.Text.Replace("'", "''") +
                    "', gen_prateleira = '" + txtPrateleira.Text + "' WHERE gen_cod = " + gen_cod;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Gênero alterado com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGenero.atualizaPesquisa();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar gênero. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (VerificarCamposObrigatorios())
            {
                if (txtPrateleira.Text.Length == 2)
                {
                    Salvar();
                }
                else
                {
                    MessageBox.Show("Digite uma prateleira vália (uma letra seguida de um número. Ex: A1).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Os campos com * são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT dvd_nome FROM dvd WHERE gen_cod = " + gen_cod;
                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable filme = new DataTable();
                da.Fill(filme);

                if (filme.Rows.Count > 0)
                {
                    int i;
                    string filmes = "";
                    for (i = 0; i < filme.Rows.Count; i++)
                        filmes += Environment.NewLine + ">> " + filme.Rows[i]["dvd_nome"].ToString();

                    MessageBox.Show("Não foi possível excluir o gênero, pois o(s) seguinte(s) registro(s) " +
                    "está(ão) ligado(s) a ele: " + Environment.NewLine + filmes, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    query = "DELETE FROM genero WHERE gen_cod = " + gen_cod;

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Gênero excluído com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGenero.atualizaPesquisa();
                    Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir gênero. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CadastrarGenero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
            if (frmGenero != null)
                frmGenero.Enabled = true;
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.White;
        }

        private void txtPrateleira_TextChanged(object sender, EventArgs e)
        {
            txtPrateleira.BackColor = Color.White;
        }
    }
}
