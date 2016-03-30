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
    public partial class ConsultarCliente : Form
    {
        public bool locarFilme = false;
        public bool pesquisandoLocacao = false;
        LocarFilme frmLocarFilme;
        ConsultarLocacao frmConsultarLocacao;
        Inicial frmInicial;

        public ConsultarCliente(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        public ConsultarCliente(LocarFilme loc)
        {
            InitializeComponent();
            frmLocarFilme = loc;
        }

        public ConsultarCliente(ConsultarLocacao loc)
        {
            InitializeComponent();
            frmConsultarLocacao = loc;
        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        public void Inicializa()
        {
            txtNome.Focus();
            txtNome.TabIndex = 0;
            txtCPF.TabIndex = 1;
            txtTelefone.TabIndex = 2;
            btnLimpar.TabIndex = 3;
            btnPesquisar.TabIndex = 4;
            lblMesagem.Text = "";
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            dgvCliente.DataSource = new DataTable();
            Inicializa();
        }

        public void atualizaPesquisa()
        {
            btnPesquisar_Click(new object(), new EventArgs());
        }

        private void Pesquisar()
        {
            try
            {
                string where = "";

                if (!txtNome.Text.Equals(""))
                    where = " WHERE cli_nome LIKE '%" + txtNome.Text.Replace("'", "''") + "%'";
                if (!txtCPF.Text.Equals("   .   .   -"))
                {
                    Uteis u = new Uteis();
                    if (u.ValidaCPF(txtCPF.Text.Replace(" ", "")))
                    {
                        where += ((where.Equals("")) ? " WHERE" : " AND") + " cli_cpf LIKE '%" + txtCPF.Text + "%'";
                    }
                    else
                    {
                        MessageBox.Show("Digite um CPF válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCPF.Focus();
                        where = "false";
                    }
                }
                if (!txtTelefone.Text.Equals("(  )") && txtTelefone.Text.Length >= 12)
                {
                    if (txtTelefone.Text.Replace(" ", "").Length >= 12)
                    {
                        where += ((where.Equals("")) ? " WHERE" : " AND") + " cli_telefone LIKE '%" + txtTelefone.Text + "%'";
                    }
                    else
                    {
                        MessageBox.Show("Digite um telefone válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtTelefone.Focus();
                        where = "false";
                    }
                }

                if (!where.Equals("false"))
                {
                    string query = "SELECT cli_cod, cli_nome, cli_CPF, cli_uf, cli_cidade, cli_CEP, cli_rua, cli_numero, " +
                    "cli_bairro, cli_complemento, cli_email, cli_telefone FROM cliente" + where;

                    SqlConnection conn = Conexao.Conectar();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable cliente = new DataTable();
                    da.Fill(cliente);

                    if (cliente.Rows.Count > 0)
                    {
                        lblMesagem.Text = cliente.Rows.Count + ((cliente.Rows.Count > 1) ? " registros." : " registro.");
                        lblMesagem.ForeColor = Color.Black;

                        dgvCliente.DataSource = cliente;
                        dgvCliente.Columns["cli_cod"].Visible = false;
                        dgvCliente.Columns["cli_nome"].HeaderText = "Nome";
                        dgvCliente.Columns["cli_CPF"].HeaderText = "CPF";
                        dgvCliente.Columns["cli_uf"].HeaderText = "Estado";
                        dgvCliente.Columns["cli_cidade"].HeaderText = "Cidade";
                        dgvCliente.Columns["cli_CEP"].HeaderText = "CEP";
                        dgvCliente.Columns["cli_rua"].HeaderText = "Rua";
                        dgvCliente.Columns["cli_numero"].HeaderText = "Nº";
                        dgvCliente.Columns["cli_bairro"].HeaderText = "Bairro";
                        dgvCliente.Columns["cli_complemento"].HeaderText = "Complemento";
                        dgvCliente.Columns["cli_email"].HeaderText = "Email";
                        dgvCliente.Columns["cli_telefone"].HeaderText = "Telefone";
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
                MessageBox.Show("Erro ao pesquisar cliente. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            dgvCliente.DataSource = new DataTable();
            Pesquisar();
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (locarFilme)
            {
                int index = e.RowIndex;
                frmLocarFilme.cli_cod = Convert.ToInt32(dgvCliente.Rows[index].Cells["cli_cod"].Value);
                frmLocarFilme.Cliente = dgvCliente.Rows[index].Cells["cli_nome"].Value.ToString();

                locarFilme = false;
                Close();
            }
            else if (pesquisandoLocacao)
            {
                int index = e.RowIndex;
                frmConsultarLocacao.cli_cod = Convert.ToInt32(dgvCliente.Rows[index].Cells["cli_cod"].Value);
                frmConsultarLocacao.Cliente = dgvCliente.Rows[index].Cells["cli_nome"].Value.ToString();

                pesquisandoLocacao = false;
                Close();
            }
            else
            {
                CadastrarCliente cCliente = new CadastrarCliente(this);
                int index = e.RowIndex;
                cCliente.cli_cod = Convert.ToInt32(dgvCliente.Rows[index].Cells["cli_cod"].Value);
                this.Enabled = false;
                cCliente.Show();
            }
        }

        private void ConsultarCliente_FormClosing(object sender, FormClosingEventArgs e)
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
