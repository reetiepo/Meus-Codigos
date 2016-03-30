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
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void mSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mSobre_Click(object sender, EventArgs e)
        {
            Sobre fSobre = new Sobre(this);
            this.Enabled = false;
            fSobre.Show();
        }

        private void mCadastrarCliente_Click(object sender, EventArgs e)
        {
            CadastrarCliente fCadastrarCliente = new CadastrarCliente(this);
            this.Enabled = false;
            fCadastrarCliente.Show();
        }

        private void mCadastrarFilme_Click(object sender, EventArgs e)
        {
            CadastrarFilme fCadastrarFilme = new CadastrarFilme(this);
            this.Enabled = false;
            fCadastrarFilme.Show();
        }

        private void mCadastrarGenero_Click(object sender, EventArgs e)
        {
            CadastrarGenero fCadastrarGenero = new CadastrarGenero(this);
            this.Enabled = false;
            fCadastrarGenero.Show();
        }

        private void mCadastrarClassificacao_Click(object sender, EventArgs e)
        {
            CadastrarClassificacao fCadastrarClassificacao = new CadastrarClassificacao(this);
            this.Enabled = false;
            fCadastrarClassificacao.Show();
        }

        private void mConsultarCliente_Click(object sender, EventArgs e)
        {
            ConsultarCliente fConsultarCliente = new ConsultarCliente(this);
            this.Enabled = false;
            fConsultarCliente.Show();
        }

        private void mConsultarClassificacao_Click(object sender, EventArgs e)
        {
            ConsultarClassificacao fConsultarClassificacao = new ConsultarClassificacao(this);
            this.Enabled = false;
            fConsultarClassificacao.Show();
        }

        private void mConsultarGenero_Click(object sender, EventArgs e)
        {
            ConsultarGenero fConsultarGenero = new ConsultarGenero(this);
            this.Enabled = false;
            fConsultarGenero.Show();
        }

        private void mConsultarFilme_Click(object sender, EventArgs e)
        {
            ConsultarFilme fConsultarFilme = new ConsultarFilme(this);
            this.Enabled = false;
            fConsultarFilme.Show();
        }

        private void mLocarFilme_Click(object sender, EventArgs e)
        {
            LocarFilme fLocarFilme = new LocarFilme(this);
            this.Enabled = false;
            fLocarFilme.Show();
        }

        private void mConsultarLocacao_Click(object sender, EventArgs e)
        {
            ConsultarLocacao fConsultarLocacao = new ConsultarLocacao(this);
            this.Enabled = false;
            fConsultarLocacao.Show();
        }

        private void mDevolverFilme_Click(object sender, EventArgs e)
        {
            DevolverFilme fDevolverFilme = new DevolverFilme(this);
            this.Enabled = false;
            fDevolverFilme.Show();
        }

        private void filmesMaisLocadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioFilme fRelatorioFilme = new RelatorioFilme(this);
            this.Enabled = false;
            fRelatorioFilme.Show();
        }

        private void clientesQueMaisLocamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioCliente fRelatorioCliente = new RelatorioCliente(this);
            this.Enabled = false;
            fRelatorioCliente.Show();
        }

        private void locaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioLocacao fRelatorioLocacao = new RelatorioLocacao(this);
            this.Enabled = false;
            fRelatorioLocacao.Show();
        }
    }
}
