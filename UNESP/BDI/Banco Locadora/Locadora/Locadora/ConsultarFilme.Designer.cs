namespace Locadora
{
    partial class ConsultarFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarFilme));
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.cbClassificacao = new System.Windows.Forms.ComboBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtDiretor = new System.Windows.Forms.TextBox();
            this.lxlDiretor = new System.Windows.Forms.Label();
            this.txtAnoLancamento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.lblMesagem = new System.Windows.Forms.Label();
            this.dgvFilme = new System.Windows.Forms.DataGridView();
            this.gbPesquisa.SuspendLayout();
            this.gbResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilme)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Controls.Add(this.cbSituacao);
            this.gbPesquisa.Controls.Add(this.lblSituacao);
            this.gbPesquisa.Controls.Add(this.cbClassificacao);
            this.gbPesquisa.Controls.Add(this.cbGenero);
            this.gbPesquisa.Controls.Add(this.lblClassificacao);
            this.gbPesquisa.Controls.Add(this.lblGenero);
            this.gbPesquisa.Controls.Add(this.txtDiretor);
            this.gbPesquisa.Controls.Add(this.lxlDiretor);
            this.gbPesquisa.Controls.Add(this.txtAnoLancamento);
            this.gbPesquisa.Controls.Add(this.label1);
            this.gbPesquisa.Controls.Add(this.btnLimpar);
            this.gbPesquisa.Controls.Add(this.btnPesquisar);
            this.gbPesquisa.Controls.Add(this.txtNome);
            this.gbPesquisa.Controls.Add(this.lblNome);
            this.gbPesquisa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPesquisa.Location = new System.Drawing.Point(12, 12);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(601, 207);
            this.gbPesquisa.TabIndex = 0;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisa";
            // 
            // cbSituacao
            // 
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Selecione uma situação",
            "Disponível",
            "Alugado"});
            this.cbSituacao.Location = new System.Drawing.Point(20, 133);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(187, 24);
            this.cbSituacao.TabIndex = 45;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(17, 114);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(57, 16);
            this.lblSituacao.TabIndex = 44;
            this.lblSituacao.Text = "Situação";
            // 
            // cbClassificacao
            // 
            this.cbClassificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassificacao.FormattingEnabled = true;
            this.cbClassificacao.Location = new System.Drawing.Point(399, 87);
            this.cbClassificacao.Name = "cbClassificacao";
            this.cbClassificacao.Size = new System.Drawing.Size(182, 24);
            this.cbClassificacao.TabIndex = 43;
            // 
            // cbGenero
            // 
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(161, 87);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(207, 24);
            this.cbGenero.TabIndex = 42;
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificacao.Location = new System.Drawing.Point(396, 68);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(81, 16);
            this.lblClassificacao.TabIndex = 41;
            this.lblClassificacao.Text = "Classificação";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(158, 67);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(49, 16);
            this.lblGenero.TabIndex = 40;
            this.lblGenero.Text = "Gênero";
            // 
            // txtDiretor
            // 
            this.txtDiretor.Location = new System.Drawing.Point(315, 41);
            this.txtDiretor.Name = "txtDiretor";
            this.txtDiretor.Size = new System.Drawing.Size(267, 23);
            this.txtDiretor.TabIndex = 37;
            // 
            // lxlDiretor
            // 
            this.lxlDiretor.AutoSize = true;
            this.lxlDiretor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxlDiretor.Location = new System.Drawing.Point(312, 22);
            this.lxlDiretor.Name = "lxlDiretor";
            this.lxlDiretor.Size = new System.Drawing.Size(47, 16);
            this.lxlDiretor.TabIndex = 39;
            this.lxlDiretor.Text = "Diretor";
            // 
            // txtAnoLancamento
            // 
            this.txtAnoLancamento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnoLancamento.Location = new System.Drawing.Point(20, 88);
            this.txtAnoLancamento.Mask = "0000";
            this.txtAnoLancamento.Name = "txtAnoLancamento";
            this.txtAnoLancamento.Size = new System.Drawing.Size(123, 23);
            this.txtAnoLancamento.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ano de lançamento";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(419, 166);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 15;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(506, 166);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(20, 41);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(276, 23);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(17, 22);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(41, 16);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome";
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.lblMesagem);
            this.gbResultado.Controls.Add(this.dgvFilme);
            this.gbResultado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultado.Location = new System.Drawing.Point(12, 225);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(601, 255);
            this.gbResultado.TabIndex = 36;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado";
            // 
            // lblMesagem
            // 
            this.lblMesagem.AutoSize = true;
            this.lblMesagem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesagem.Location = new System.Drawing.Point(17, 33);
            this.lblMesagem.Name = "lblMesagem";
            this.lblMesagem.Size = new System.Drawing.Size(70, 16);
            this.lblMesagem.TabIndex = 1;
            this.lblMesagem.Text = "Mensagem";
            // 
            // dgvFilme
            // 
            this.dgvFilme.AllowUserToAddRows = false;
            this.dgvFilme.AllowUserToDeleteRows = false;
            this.dgvFilme.AllowUserToOrderColumns = true;
            this.dgvFilme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilme.Location = new System.Drawing.Point(20, 52);
            this.dgvFilme.Name = "dgvFilme";
            this.dgvFilme.ReadOnly = true;
            this.dgvFilme.Size = new System.Drawing.Size(562, 197);
            this.dgvFilme.TabIndex = 0;
            this.dgvFilme.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilme_CellDoubleClick);
            // 
            // ConsultarFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(634, 492);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbPesquisa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarFilme";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "100% Video - Consultar Filme";
            this.Load += new System.EventHandler(this.ConsultarFilme_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultarFilme_FormClosing);
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.Label lblMesagem;
        private System.Windows.Forms.DataGridView dgvFilme;
        private System.Windows.Forms.ComboBox cbClassificacao;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtDiretor;
        private System.Windows.Forms.Label lxlDiretor;
        private System.Windows.Forms.MaskedTextBox txtAnoLancamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label lblSituacao;

    }
}

