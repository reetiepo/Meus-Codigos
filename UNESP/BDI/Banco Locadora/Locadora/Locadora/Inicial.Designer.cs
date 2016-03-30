namespace Locadora
{
    partial class Inicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicial));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mCadastrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mCadastrarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mCadastrarFilme = new System.Windows.Forms.ToolStripMenuItem();
            this.mCadastrarGenero = new System.Windows.Forms.ToolStripMenuItem();
            this.mCadastrarClassificacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultar = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultarLocacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultarFilme = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultarGenero = new System.Windows.Forms.ToolStripMenuItem();
            this.mConsultarClassificacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mLocarFilme = new System.Windows.Forms.ToolStripMenuItem();
            this.mDevolverFilme = new System.Windows.Forms.ToolStripMenuItem();
            this.mRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.filmesMaisLocadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.mSair = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLocadora = new System.Windows.Forms.Label();
            this.clientesQueMaisLocamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.locaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCadastrar,
            this.mConsultar,
            this.mLocarFilme,
            this.mDevolverFilme,
            this.mRelatorios,
            this.mSobre,
            this.mSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mCadastrar
            // 
            this.mCadastrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCadastrarCliente,
            this.mCadastrarFilme,
            this.mCadastrarGenero,
            this.mCadastrarClassificacao});
            this.mCadastrar.Name = "mCadastrar";
            this.mCadastrar.Size = new System.Drawing.Size(69, 20);
            this.mCadastrar.Text = "Cadastrar";
            // 
            // mCadastrarCliente
            // 
            this.mCadastrarCliente.Name = "mCadastrarCliente";
            this.mCadastrarCliente.Size = new System.Drawing.Size(142, 22);
            this.mCadastrarCliente.Text = "Cliente";
            this.mCadastrarCliente.Click += new System.EventHandler(this.mCadastrarCliente_Click);
            // 
            // mCadastrarFilme
            // 
            this.mCadastrarFilme.Name = "mCadastrarFilme";
            this.mCadastrarFilme.Size = new System.Drawing.Size(142, 22);
            this.mCadastrarFilme.Text = "Filme";
            this.mCadastrarFilme.Click += new System.EventHandler(this.mCadastrarFilme_Click);
            // 
            // mCadastrarGenero
            // 
            this.mCadastrarGenero.Name = "mCadastrarGenero";
            this.mCadastrarGenero.Size = new System.Drawing.Size(142, 22);
            this.mCadastrarGenero.Text = "Gênero";
            this.mCadastrarGenero.Click += new System.EventHandler(this.mCadastrarGenero_Click);
            // 
            // mCadastrarClassificacao
            // 
            this.mCadastrarClassificacao.Name = "mCadastrarClassificacao";
            this.mCadastrarClassificacao.Size = new System.Drawing.Size(142, 22);
            this.mCadastrarClassificacao.Text = "Classificação";
            this.mCadastrarClassificacao.Click += new System.EventHandler(this.mCadastrarClassificacao_Click);
            // 
            // mConsultar
            // 
            this.mConsultar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mConsultarLocacao,
            this.mConsultarCliente,
            this.mConsultarFilme,
            this.mConsultarGenero,
            this.mConsultarClassificacao});
            this.mConsultar.Name = "mConsultar";
            this.mConsultar.Size = new System.Drawing.Size(70, 20);
            this.mConsultar.Text = "Consultar";
            // 
            // mConsultarLocacao
            // 
            this.mConsultarLocacao.Name = "mConsultarLocacao";
            this.mConsultarLocacao.Size = new System.Drawing.Size(142, 22);
            this.mConsultarLocacao.Text = "Locação";
            this.mConsultarLocacao.Click += new System.EventHandler(this.mConsultarLocacao_Click);
            // 
            // mConsultarCliente
            // 
            this.mConsultarCliente.Name = "mConsultarCliente";
            this.mConsultarCliente.Size = new System.Drawing.Size(142, 22);
            this.mConsultarCliente.Text = "Cliente";
            this.mConsultarCliente.Click += new System.EventHandler(this.mConsultarCliente_Click);
            // 
            // mConsultarFilme
            // 
            this.mConsultarFilme.Name = "mConsultarFilme";
            this.mConsultarFilme.Size = new System.Drawing.Size(142, 22);
            this.mConsultarFilme.Text = "Filme";
            this.mConsultarFilme.Click += new System.EventHandler(this.mConsultarFilme_Click);
            // 
            // mConsultarGenero
            // 
            this.mConsultarGenero.Name = "mConsultarGenero";
            this.mConsultarGenero.Size = new System.Drawing.Size(142, 22);
            this.mConsultarGenero.Text = "Gênero";
            this.mConsultarGenero.Click += new System.EventHandler(this.mConsultarGenero_Click);
            // 
            // mConsultarClassificacao
            // 
            this.mConsultarClassificacao.Name = "mConsultarClassificacao";
            this.mConsultarClassificacao.Size = new System.Drawing.Size(142, 22);
            this.mConsultarClassificacao.Text = "Classificação";
            this.mConsultarClassificacao.Click += new System.EventHandler(this.mConsultarClassificacao_Click);
            // 
            // mLocarFilme
            // 
            this.mLocarFilme.Name = "mLocarFilme";
            this.mLocarFilme.Size = new System.Drawing.Size(78, 20);
            this.mLocarFilme.Text = "Locar filme";
            this.mLocarFilme.Click += new System.EventHandler(this.mLocarFilme_Click);
            // 
            // mDevolverFilme
            // 
            this.mDevolverFilme.Name = "mDevolverFilme";
            this.mDevolverFilme.Size = new System.Drawing.Size(95, 20);
            this.mDevolverFilme.Text = "Devolver filme";
            this.mDevolverFilme.Click += new System.EventHandler(this.mDevolverFilme_Click);
            // 
            // mRelatorios
            // 
            this.mRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filmesMaisLocadosToolStripMenuItem,
            this.clientesQueMaisLocamToolStripMenuItem,
            this.locaçõesToolStripMenuItem});
            this.mRelatorios.Name = "mRelatorios";
            this.mRelatorios.Size = new System.Drawing.Size(71, 20);
            this.mRelatorios.Text = "Relatórios";
            // 
            // filmesMaisLocadosToolStripMenuItem
            // 
            this.filmesMaisLocadosToolStripMenuItem.Name = "filmesMaisLocadosToolStripMenuItem";
            this.filmesMaisLocadosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.filmesMaisLocadosToolStripMenuItem.Text = "Filmes mais locados";
            this.filmesMaisLocadosToolStripMenuItem.Click += new System.EventHandler(this.filmesMaisLocadosToolStripMenuItem_Click);
            // 
            // mSobre
            // 
            this.mSobre.Name = "mSobre";
            this.mSobre.Size = new System.Drawing.Size(49, 20);
            this.mSobre.Text = "Sobre";
            this.mSobre.Click += new System.EventHandler(this.mSobre_Click);
            // 
            // mSair
            // 
            this.mSair.Name = "mSair";
            this.mSair.Size = new System.Drawing.Size(38, 20);
            this.mSair.Text = "Sair";
            this.mSair.Click += new System.EventHandler(this.mSair_Click);
            // 
            // lblLocadora
            // 
            this.lblLocadora.AutoSize = true;
            this.lblLocadora.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocadora.Location = new System.Drawing.Point(77, 254);
            this.lblLocadora.Name = "lblLocadora";
            this.lblLocadora.Size = new System.Drawing.Size(327, 26);
            this.lblLocadora.TabIndex = 3;
            this.lblLocadora.Text = "L      O      C      A      D      O      R      A";
            // 
            // clientesQueMaisLocamToolStripMenuItem
            // 
            this.clientesQueMaisLocamToolStripMenuItem.Name = "clientesQueMaisLocamToolStripMenuItem";
            this.clientesQueMaisLocamToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.clientesQueMaisLocamToolStripMenuItem.Text = "Clientes que mais locam";
            this.clientesQueMaisLocamToolStripMenuItem.Click += new System.EventHandler(this.clientesQueMaisLocamToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Locadora.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(78, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // locaçõesToolStripMenuItem
            // 
            this.locaçõesToolStripMenuItem.Name = "locaçõesToolStripMenuItem";
            this.locaçõesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.locaçõesToolStripMenuItem.Text = "Locações";
            this.locaçõesToolStripMenuItem.Click += new System.EventHandler(this.locaçõesToolStripMenuItem_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.lblLocadora);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicial";
            this.Text = "100% Video";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mCadastrar;
        private System.Windows.Forms.ToolStripMenuItem mCadastrarCliente;
        private System.Windows.Forms.ToolStripMenuItem mCadastrarFilme;
        private System.Windows.Forms.ToolStripMenuItem mCadastrarGenero;
        private System.Windows.Forms.ToolStripMenuItem mCadastrarClassificacao;
        private System.Windows.Forms.ToolStripMenuItem mConsultar;
        private System.Windows.Forms.ToolStripMenuItem mConsultarLocacao;
        private System.Windows.Forms.ToolStripMenuItem mConsultarCliente;
        private System.Windows.Forms.ToolStripMenuItem mConsultarFilme;
        private System.Windows.Forms.ToolStripMenuItem mConsultarGenero;
        private System.Windows.Forms.ToolStripMenuItem mLocarFilme;
        private System.Windows.Forms.ToolStripMenuItem mSobre;
        private System.Windows.Forms.ToolStripMenuItem mSair;
        private System.Windows.Forms.ToolStripMenuItem mConsultarClassificacao;
        private System.Windows.Forms.Label lblLocadora;
        private System.Windows.Forms.ToolStripMenuItem mDevolverFilme;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mRelatorios;
        private System.Windows.Forms.ToolStripMenuItem filmesMaisLocadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesQueMaisLocamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaçõesToolStripMenuItem;
    }
}

