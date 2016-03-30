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
    public partial class CadastrarCliente : Form
    {
        public int cli_cod;
        ConsultarCliente frmCliente;
        Inicial frmInicial;

        public CadastrarCliente(Inicial ini)
        {
            InitializeComponent();
            btnExcluir.Visible = false;
            frmInicial = ini;
        }

        public CadastrarCliente(ConsultarCliente cli)
        {
            InitializeComponent();
            frmCliente = cli;
            btnSalvar.Text = "Alterar";
            btnExcluir.Visible = true;
        }

        public void CarregarDadosCliente()
        {
            try
            {
                string query = "SELECT cli_cod, cli_nome, cli_CPF, cli_uf, cli_cidade, cli_CEP, cli_rua, cli_numero, " +
                    "cli_bairro, cli_complemento, cli_email, cli_telefone FROM cliente WHERE cli_cod = " + cli_cod;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable cliente = new DataTable();
                da.Fill(cliente);

                if (cliente.Rows.Count > 0)
                {
                    txtNome.Text = cliente.Rows[0]["cli_nome"].ToString();
                    txtCPF.Text = cliente.Rows[0]["cli_CPF"].ToString();
                    cbUF.SelectedIndex = cbUF.FindString(cliente.Rows[0]["cli_uf"].ToString());
                    txtCidade.Text = cliente.Rows[0]["cli_cidade"].ToString();
                    txtCEP.Text = cliente.Rows[0]["cli_CEP"].ToString();
                    txtRua.Text = cliente.Rows[0]["cli_rua"].ToString();
                    txtNum.Text = cliente.Rows[0]["cli_numero"].ToString();
                    txtBairro.Text = cliente.Rows[0]["cli_bairro"].ToString();
                    txtComplemento.Text = cliente.Rows[0]["cli_complemento"].ToString();
                    txtEmail.Text = cliente.Rows[0]["cli_email"].ToString();
                    txtDDD.Text = cliente.Rows[0]["cli_telefone"].ToString().Substring(0,3);
                    txtTelefone.Text = cliente.Rows[0]["cli_telefone"].ToString().Substring(3);
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar cliente. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void CadastrarCliente_Load(object sender, EventArgs e)
        {
            Inicializa();
            if (btnSalvar.Text.Equals("Alterar"))
                CarregarDadosCliente();
        }

        private void Inicializa()
        {
            cbUF.SelectedIndex = 0;
            txtNome.Focus();
            txtNome.TabIndex = 0;
            txtCPF.TabIndex = 1;
            cbUF.TabIndex = 2;
            txtCidade.TabIndex = 3;
            txtCEP.TabIndex = 4;
            txtRua.TabIndex = 5;
            txtNum.TabIndex = 6;
            txtBairro.TabIndex = 7;
            txtComplemento.TabIndex = 8;
            txtEmail.TabIndex = 9;
            txtDDD.TabIndex = 10;
            txtTelefone.TabIndex = 11;
            btnExcluir.TabIndex = 12;
            btnLimpar.TabIndex = 13;
            btnSalvar.TabIndex = 14;
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtCidade.Clear();
            txtComplemento.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtNum.Clear();
            txtRua.Clear();
            txtTelefone.Clear();
            Inicializa();
        }

        private bool VerificarCamposObrigatorios()
        {
            bool retorno = true;
            if (txtNome.Text.Equals(""))
            {
                txtNome.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (cbUF.SelectedIndex <= 0)
            {
                cbUF.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtCidade.Text.Equals(""))
            {
                txtCidade.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtCEP.Text.Equals("     -"))
            {
                txtCEP.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtRua.Text.Equals(""))
            {
                txtRua.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtCPF.Text.Equals("   .   .   -"))
            {
                txtCPF.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtBairro.Text.Equals(""))
            {
                txtBairro.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtDDD.Text.Equals("(  )"))
            {
                txtDDD.BackColor = Color.MistyRose;
                retorno = false;
            }
            if (txtTelefone.Text.Equals(""))
            {
                txtTelefone.BackColor = Color.MistyRose;
                retorno = false;
            }

            return retorno;
        }

        private void Salvar()
        {
            if (btnSalvar.Text.Equals("Salvar"))
            {
                try
                {
                    string query = "INSERT INTO cliente " +
                    "(cli_nome, cli_CPF, cli_uf, cli_cidade, cli_CEP, cli_rua, cli_numero, cli_bairro, " +
                    "cli_complemento, cli_email, cli_telefone) VALUES('" + txtNome.Text.Replace("'", "''") + "','" +
                    txtCPF.Text + "','" + cbUF.Text + "','" + txtCidade.Text.Replace("'", "''") + "','" +
                    txtCEP.Text + "','" + txtRua.Text.Replace("'", "''") + "','" + txtNum.Text.Replace("'", "''") + "','" +
                    txtBairro.Text.Replace("'", "''") + "','" + txtComplemento.Text.Replace("'", "''") + "','" +
                    txtEmail.Text.Replace("'", "''") + "','" + txtDDD.Text + txtTelefone.Text + "')";

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    DialogResult cadastrarNovo = MessageBox.Show("Cliente salvo com sucesso. Deseja cadastrar um novo cliente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cadastrarNovo == DialogResult.Yes)
                        Limpar();
                    else
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar cliente. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (btnSalvar.Text.Equals("Alterar"))
            {
                try
                {
                    string query = "UPDATE cliente SET cli_nome = '" + txtNome.Text.Replace("'", "''") +
                    "', cli_CPF = '" + txtCPF.Text + "', cli_uf = '" + cbUF.Text + "', cli_cidade = '" +
                    txtCidade.Text.Replace("'", "''") + "', cli_CEP = '" + txtCEP.Text + "', cli_rua = '" +
                    txtRua.Text.Replace("'", "''") + "', cli_numero = '" + txtNum.Text.Replace("'", "''") +
                    "', cli_bairro = '" + txtBairro.Text.Replace("'", "''") + "', cli_complemento = '" +
                    txtComplemento.Text.Replace("'", "''") + "', cli_email = '" +
                    txtEmail.Text.Replace("'", "''") + "', cli_telefone = '" + txtDDD.Text + txtTelefone.Text + "' WHERE cli_cod = " + cli_cod;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Cliente alterado com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCliente.atualizaPesquisa();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar cliente. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Uteis u = new Uteis();
                if (!u.ValidaCPF(txtCPF.Text.Replace(" ", "")))
                {
                    MessageBox.Show("Digite um CPF válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCPF.Focus();
                }
                else if (txtCEP.Text.Replace(" ", "").Length < 9)
                {
                    MessageBox.Show("Digite um CEP válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCEP.Focus();
                }
                else if (txtDDD.Text.Replace(" ", "").Replace("(","").Replace(")","").Length < 2)
                {
                    MessageBox.Show("Digite um DDD válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTelefone.Focus();
                }
                else if (txtTelefone.Text.Replace(" ", "").Length < 8)
                {
                    MessageBox.Show("Digite um telefone válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTelefone.Focus();
                }
                else
                {
                    Salvar();
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
                string query = "SELECT dvd_cod FROM locacao WHERE cli_cod = " + cli_cod;
                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable locacao = new DataTable();
                da.Fill(locacao);

                if (locacao.Rows.Count > 0)
                    MessageBox.Show("Esse cliente possui registro(s) de locação. Não é possível excluí-lo.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    query = "DELETE FROM cliente WHERE cli_cod = " + cli_cod;

                    SqlCommand cmd2 = new SqlCommand(query, conn);
                    cmd2.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Cliente excluído com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCliente.atualizaPesquisa();
                    Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CadastrarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmCliente != null)
                frmCliente.Enabled = true;
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.White;
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtCPF.BackColor = Color.White;
        }

        private void cbUF_TextChanged(object sender, EventArgs e)
        {
            cbUF.BackColor = Color.White;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.White;
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            txtCEP.BackColor = Color.White;
        }

        private void txtRua_TextChanged(object sender, EventArgs e)
        {
            txtRua.BackColor = Color.White;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.White;
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.BackColor = Color.White;
        }

        private void txtDDD_TextChanged(object sender, EventArgs e)
        {
            txtDDD.BackColor = Color.White;
        }
    }
}
