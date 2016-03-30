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
    public partial class ConsultarGenero : Form
    {
        Inicial frmInicial;

        public ConsultarGenero(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        private void ConsultarGenero_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        public void Inicializa()
        {
            txtDescricao.Focus();
            txtDescricao.TabIndex = 0;
            txtPrateleira.TabIndex = 1;
            btnLimpar.TabIndex = 2;
            btnPesquisar.TabIndex = 3;
            lblMesagem.Text = "";
        }

        private void Limpar()
        {
            txtDescricao.Clear();
            txtPrateleira.Clear();
            dgvGenero.DataSource = new DataTable();
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

                if (!txtDescricao.Text.Equals(""))
                    where = " WHERE gen_descricao LIKE '%" + txtDescricao.Text.Replace("'", "''") + "%'";
                if (!txtPrateleira.Text.Equals(""))
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " gen_prateleira LIKE '%" + txtPrateleira.Text.Replace("'", "''") + "%'";

                string query = "SELECT gen_cod, gen_descricao, gen_prateleira FROM genero" + where;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable genero = new DataTable();
                da.Fill(genero);

                if (genero.Rows.Count > 0)
                {
                    lblMesagem.Text = genero.Rows.Count + ((genero.Rows.Count > 1) ? " registros." : " registro.");
                    lblMesagem.ForeColor = Color.Black;

                    dgvGenero.DataSource = genero;
                    dgvGenero.Columns["gen_cod"].Visible = false;
                    dgvGenero.Columns["gen_descricao"].HeaderText = "Descrição";
                    dgvGenero.Columns["gen_prateleira"].HeaderText = "Prateleira";
                }
                else
                {
                    lblMesagem.Text = "Não foram encontrados registros.";
                    lblMesagem.ForeColor = Color.Red;
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar gênero. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            dgvGenero.DataSource = new DataTable();
            Pesquisar();
        }

        private void dgvGenero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CadastrarGenero cGenero = new CadastrarGenero(this);
            int index = e.RowIndex;
            cGenero.gen_cod = Convert.ToInt32(dgvGenero.Rows[index].Cells["gen_cod"].Value);
            cGenero.carregarDadosGenero();
            this.Enabled = false;
            cGenero.Show();
        }

        private void ConsultarGenero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
