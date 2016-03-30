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
    public partial class CadastrarClassificacao : Form
    {
        public int cla_cod;
        ConsultarClassificacao frmClassificacao;
        Inicial frmInicial;

        public CadastrarClassificacao(Inicial ini)
        {
            InitializeComponent();
            btnExcluir.Visible = false;
            frmInicial = ini;
        }

        public CadastrarClassificacao(ConsultarClassificacao cla)
        {
            InitializeComponent();
            frmClassificacao = cla;
            btnSalvar.Text = "Alterar";
            btnExcluir.Visible = true;
        }

        public void CarregarDadosClassificacao()
        {
            try
            {
                string query = "SELECT cla_descricao, cla_valor, cla_tempo FROM classificacao WHERE cla_cod = " + cla_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable classificacao = new DataTable();
                da.Fill(classificacao);

                if (classificacao.Rows.Count > 0)
                {
                    txtDescricao.Text = classificacao.Rows[0]["cla_descricao"].ToString();
                    txtValor.Text = classificacao.Rows[0]["cla_valor"].ToString();
                    txtTempo.Text = classificacao.Rows[0]["cla_tempo"].ToString();
                }
                else
                {
                    MessageBox.Show("Classificação não encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar classificação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void CadastrarClassificacao_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        public void Inicializa()
        {
            txtDescricao.Focus();
            txtDescricao.TabIndex = 0;
            txtValor.TabIndex = 1;
            txtTempo.TabIndex = 2;
            btnExcluir.TabIndex = 3;
            btnLimpar.TabIndex = 4;
            btnSalvar.TabIndex = 5;
        }

        private void Limpar()
        {
            txtDescricao.Clear();
            txtValor.Value = 0;
            txtTempo.Value = 1;
            Inicializa();
        }

        private bool VerificaCamposObrigatórios()
        {
            if (txtDescricao.Text.Equals(""))
            {
                txtDescricao.BackColor = Color.MistyRose;
                return false;
            }

            return true;
        }

        private void Salvar()
        {
            if (btnSalvar.Text.Equals("Salvar"))
            {
                try
                {
                    string query = "INSERT INTO classificacao (cla_descricao, cla_valor, cla_tempo) " +
                                    "VALUES('" + txtDescricao.Text.Replace("'", "''") +
                                    "','" + txtValor.Value.ToString().Replace(",", ".") + "','" + txtTempo.Value.ToString() + "')";

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    DialogResult cadastrarNovo = MessageBox.Show("Classificação salva com sucesso. Deseja cadastrar um nova classificação?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cadastrarNovo == DialogResult.Yes)
                        Limpar();
                    else
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar classificação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (btnSalvar.Text.Equals("Alterar"))
            {
                try
                {
                    string query = "UPDATE classificacao SET cla_descricao = '" + txtDescricao.Text.Replace("'", "''") + 
                    "', cla_valor = '" + txtValor.Value.ToString().Replace(",", ".") + "', cla_tempo = '" + 
                    txtTempo.Value.ToString() + "' WHERE cla_cod = " + cla_cod;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Classificação alterada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmClassificacao.atualizaPesquisa();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar classificação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (VerificaCamposObrigatórios())
                Salvar();
            else
                MessageBox.Show("Os campos com * são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT dvd_nome FROM dvd WHERE cla_cod = " + cla_cod;
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

                    MessageBox.Show("Não foi possível excluir a classificação, pois o(s) seguinte(s) registro(s) " +
                    "está(ão) ligado(s) à ela: " + Environment.NewLine + filmes, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    query = "DELETE FROM classificacao WHERE cla_cod = " + cla_cod;

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Classificação excluída com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmClassificacao.atualizaPesquisa();
                    Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir classificação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.White;
        }

        private void CadastrarClassificacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
            if (frmClassificacao != null)
                frmClassificacao.Enabled = true;
        }
    }
}
