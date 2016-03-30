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
    public partial class ConsultarLocacao : Form
    {
        public bool pesquisandoDevolucao = false;
        public int cli_cod = 0;
        public int dvd_cod = 0;
        DevolverFilme frmDevolverFilme;
        Inicial frmInicial;

        public string Cliente
        {
            set { txtCliente.Text = value; }
        }

        public string Filme
        {
            set { txtFilme.Text = value; }
        }

        public ConsultarLocacao(Inicial ini)
        {
            InitializeComponent();
            cbSituacao.SelectedIndex = 0;
            frmInicial = ini;
        }

        public ConsultarLocacao(DevolverFilme dev)
        {
            InitializeComponent();
            cbSituacao.SelectedIndex = 1;
            cbSituacao.Enabled = false;
            frmDevolverFilme = dev;

        }

        private void ConsultarLocacao_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        private void Inicializa()
        {
            btnPesquisaCliente.Focus();
            btnPesquisaCliente.TabIndex = 0;
            btnPesquisarFilme.TabIndex = 1;
            cbSituacao.TabIndex = 2;
            btnLimpar.TabIndex = 3;
            btnPesquisar.TabIndex = 4;
        }

        private void Limpar()
        {
            txtCliente.Clear();
            txtFilme.Clear();
            cbSituacao.SelectedIndex = 0;
            cli_cod = 0;
            dvd_cod = 0;
            dgvLocacao.DataSource = new DataTable();
            Inicializa();
        }

        private void Pesquisar()
        {
            try
            {
                string where = "";

                if (dvd_cod > 0)
                    where = " WHERE locacao.dvd_cod = " + dvd_cod;
                if (cli_cod > 0)
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " locacao.cli_cod = " + cli_cod;
                if (cbSituacao.SelectedIndex > 0)
                    where += ((where.Equals("")) ? " WHERE" : " AND") + " loc_situacao = " + (cbSituacao.Text.Equals("Em aberto") ? "0" : "1");

                string query = "SELECT locacao.dvd_cod, locacao.cli_cod, dvd_nome, cli_nome, loc_dataLocacao dataLoc, " +
                "CONVERT(CHAR,loc_dataLocacao,103) loc_dataLocacao, CONVERT(CHAR,loc_dataPrevistaDevolucao,103) " +
                "loc_dataPrevistaDevolucao, CONVERT(CHAR,loc_dataDevolucao,103) loc_dataDevolucao, loc_valorMulta, " +
                "CASE loc_situacao WHEN 0 THEN 'Em aberto' ELSE 'Fechada' END loc_situacao FROM locacao INNER JOIN " +
                "dvd ON locacao.dvd_cod = dvd.dvd_cod INNER JOIN cliente ON locacao.cli_cod = cliente.cli_cod " + where;

                SqlConnection conn = Conexao.Conectar();
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable locacao = new DataTable();
                da.Fill(locacao);

                if (locacao.Rows.Count > 0)
                {
                    lblMesagem.Text = locacao.Rows.Count + ((locacao.Rows.Count > 1) ? " registros." : " registro.");
                    lblMesagem.ForeColor = Color.Black;

                    dgvLocacao.DataSource = locacao;
                    dgvLocacao.Columns["dvd_cod"].Visible = false;
                    dgvLocacao.Columns["cli_cod"].Visible = false;
                    dgvLocacao.Columns["dataLoc"].Visible = false;
                    dgvLocacao.Columns["dvd_nome"].HeaderText = "Nome filme";
                    dgvLocacao.Columns["cli_nome"].HeaderText = "Nome cliente";
                    dgvLocacao.Columns["loc_dataLocacao"].HeaderText = "Data locação";
                    dgvLocacao.Columns["loc_dataPrevistaDevolucao"].HeaderText = "Data prevista devolução";
                    dgvLocacao.Columns["loc_dataDevolucao"].HeaderText = "Data devolução";
                    dgvLocacao.Columns["loc_valorMulta"].HeaderText = "Valor multa";
                    dgvLocacao.Columns["loc_situacao"].HeaderText = "Situação";
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
                MessageBox.Show("Erro ao pesquisar locação. (Err: " + ex.Message + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult desejaLimpar = MessageBox.Show("Deseja mesmo limpar os campos de pesquisa?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (desejaLimpar == DialogResult.Yes)
                Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dgvLocacao.DataSource = new DataTable();
            Pesquisar();
        }

        private void btnPesquisaCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente frmCliente = new ConsultarCliente(this);
            frmCliente.pesquisandoLocacao = true;
            this.Enabled = false;
            frmCliente.Show();
        }

        private void btnPesquisarFilme_Click(object sender, EventArgs e)
        {
            ConsultarFilme frmFilme = new ConsultarFilme(this);
            frmFilme.pesquisandoLocacao = true;
            this.Enabled = false;
            frmFilme.Show();
        }

        private void dgvLocacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pesquisandoDevolucao)
            {
                int index = e.RowIndex;
                frmDevolverFilme.cli_cod = Convert.ToInt32(dgvLocacao.Rows[index].Cells["cli_cod"].Value);
                frmDevolverFilme.dvd_cod = Convert.ToInt32(dgvLocacao.Rows[index].Cells["dvd_cod"].Value);
                frmDevolverFilme.loc_dataLocacao = Convert.ToDateTime(dgvLocacao.Rows[index].Cells["loc_dataLocacao"].Value);
                frmDevolverFilme.loc_dataPrevistaDevolucao = Convert.ToDateTime(dgvLocacao.Rows[index].Cells["loc_dataPrevistaDevolucao"].Value);
                frmDevolverFilme.Locacao = dgvLocacao.Rows[index].Cells["cli_nome"].Value.ToString() + " - " + dgvLocacao.Rows[index].Cells["dvd_nome"].Value.ToString();


                frmDevolverFilme.dataLoc = dgvLocacao.Rows[index].Cells["dataLoc"].Value.ToString();
                pesquisandoDevolucao = false;
                frmDevolverFilme.AtualizarInformacoesDevolucao();
                Close();
            }
        }

        private void ConsultarLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmInicial != null)
                frmInicial.Enabled = true;
            if (frmDevolverFilme != null)
                frmDevolverFilme.Enabled = true;
        }
    }
}
