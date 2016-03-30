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
    public partial class ConsultarClassificacao : Form
    {
        Inicial frmInicial;

        public ConsultarClassificacao(Inicial ini)
        {
            InitializeComponent();
            frmInicial = ini;
        }

        private void ConsultarClassificacao_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        public void Inicializa()
        {
            txtDescricao.Focus();
            txtDescricao.TabIndex = 0;
            btnLimpar.TabIndex = 1;
            btnPesquisar.TabIndex = 2;
            lblMesagem.Text = "";
        }

        private void Limpar()
        {
            txtDescricao.Clear();
            dgvClassificacao.DataSource = new DataTable();
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
                    where = " WHERE cla_descricao LIKE '%" + txtDescricao.Text.Replace("'", "''") + "%'";

                string query = "SELECT cla_cod, cla_descricao, cla_valor, cla_tempo FROM classificacao" + where;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable classificacao = new DataTable();
                da.Fill(classificacao);

                if (classificacao.Rows.Count > 0)
                {
                    lblMesagem.Text = classificacao.Rows.Count + ((classificacao.Rows.Count > 1) ? " registros." : " registro.");
                    lblMesagem.ForeColor = Color.Black;

                    dgvClassificacao.DataSource = classificacao;
                    dgvClassificacao.Columns["cla_cod"].Visible = false;
                    dgvClassificacao.Columns["cla_descricao"].HeaderText = "Descrição";
                    dgvClassificacao.Columns["cla_valor"].HeaderText = "Valor (R$)";
                    dgvClassificacao.Columns["cla_tempo"].HeaderText = "Tempo (dias)";
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
                MessageBox.Show("Erro ao pesquisar classificação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            dgvClassificacao.DataSource = new DataTable();
            Pesquisar();
        }

        private void dgvClassificacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CadastrarClassificacao cClassificacao = new CadastrarClassificacao(this);
            int index = e.RowIndex;
            cClassificacao.cla_cod = Convert.ToInt32(dgvClassificacao.Rows[index].Cells["cla_cod"].Value);
            cClassificacao.CarregarDadosClassificacao();
            this.Enabled = false;
            cClassificacao.Show();
        }

        private void ConsultarClassificacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
        }
    }
}
