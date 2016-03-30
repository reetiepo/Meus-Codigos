namespace Locadora
{
    partial class CadastrarFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarFilme));
            this.gbDadosFilme = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClassificacao = new System.Windows.Forms.ComboBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtDiretor = new System.Windows.Forms.TextBox();
            this.lxlDiretor = new System.Windows.Forms.Label();
            this.txtAnoLancamento = new System.Windows.Forms.MaskedTextBox();
            this.txtSinopse = new System.Windows.Forms.TextBox();
            this.lblSinopse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.gbDadosFilme.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDadosFilme
            // 
            this.gbDadosFilme.Controls.Add(this.label3);
            this.gbDadosFilme.Controls.Add(this.label1);
            this.gbDadosFilme.Controls.Add(this.cbClassificacao);
            this.gbDadosFilme.Controls.Add(this.cbGenero);
            this.gbDadosFilme.Controls.Add(this.lblClassificacao);
            this.gbDadosFilme.Controls.Add(this.lblGenero);
            this.gbDadosFilme.Controls.Add(this.txtDiretor);
            this.gbDadosFilme.Controls.Add(this.lxlDiretor);
            this.gbDadosFilme.Controls.Add(this.txtAnoLancamento);
            this.gbDadosFilme.Controls.Add(this.txtSinopse);
            this.gbDadosFilme.Controls.Add(this.lblSinopse);
            this.gbDadosFilme.Controls.Add(this.label2);
            this.gbDadosFilme.Controls.Add(this.txtNome);
            this.gbDadosFilme.Controls.Add(this.lblCPF);
            this.gbDadosFilme.Controls.Add(this.lblNome);
            this.gbDadosFilme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosFilme.Location = new System.Drawing.Point(12, 35);
            this.gbDadosFilme.Name = "gbDadosFilme";
            this.gbDadosFilme.Size = new System.Drawing.Size(460, 344);
            this.gbDadosFilme.TabIndex = 0;
            this.gbDadosFilme.TabStop = false;
            this.gbDadosFilme.Text = "Dados filme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(331, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(61, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "*";
            // 
            // cbClassificacao
            // 
            this.cbClassificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassificacao.FormattingEnabled = true;
            this.cbClassificacao.Location = new System.Drawing.Point(258, 301);
            this.cbClassificacao.Name = "cbClassificacao";
            this.cbClassificacao.Size = new System.Drawing.Size(182, 24);
            this.cbClassificacao.TabIndex = 28;
            this.cbClassificacao.TextChanged += new System.EventHandler(this.cbClassificacao_TextChanged);
            // 
            // cbGenero
            // 
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(20, 301);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(207, 24);
            this.cbGenero.TabIndex = 27;
            this.cbGenero.TextChanged += new System.EventHandler(this.cbGenero_TextChanged);
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificacao.Location = new System.Drawing.Point(255, 282);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(81, 16);
            this.lblClassificacao.TabIndex = 26;
            this.lblClassificacao.Text = "Classificação";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(17, 281);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(49, 16);
            this.lblGenero.TabIndex = 23;
            this.lblGenero.Text = "Gênero";
            // 
            // txtDiretor
            // 
            this.txtDiretor.Location = new System.Drawing.Point(173, 247);
            this.txtDiretor.Name = "txtDiretor";
            this.txtDiretor.Size = new System.Drawing.Size(267, 23);
            this.txtDiretor.TabIndex = 21;
            // 
            // lxlDiretor
            // 
            this.lxlDiretor.AutoSize = true;
            this.lxlDiretor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxlDiretor.Location = new System.Drawing.Point(170, 228);
            this.lxlDiretor.Name = "lxlDiretor";
            this.lxlDiretor.Size = new System.Drawing.Size(47, 16);
            this.lxlDiretor.TabIndex = 22;
            this.lxlDiretor.Text = "Diretor";
            // 
            // txtAnoLancamento
            // 
            this.txtAnoLancamento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnoLancamento.Location = new System.Drawing.Point(20, 247);
            this.txtAnoLancamento.Mask = "0000";
            this.txtAnoLancamento.Name = "txtAnoLancamento";
            this.txtAnoLancamento.Size = new System.Drawing.Size(123, 23);
            this.txtAnoLancamento.TabIndex = 21;
            // 
            // txtSinopse
            // 
            this.txtSinopse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSinopse.Location = new System.Drawing.Point(20, 93);
            this.txtSinopse.MaxLength = 200;
            this.txtSinopse.Multiline = true;
            this.txtSinopse.Name = "txtSinopse";
            this.txtSinopse.Size = new System.Drawing.Size(420, 120);
            this.txtSinopse.TabIndex = 7;
            // 
            // lblSinopse
            // 
            this.lblSinopse.AutoSize = true;
            this.lblSinopse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinopse.Location = new System.Drawing.Point(17, 74);
            this.lblSinopse.Name = "lblSinopse";
            this.lblSinopse.Size = new System.Drawing.Size(53, 16);
            this.lblSinopse.TabIndex = 6;
            this.lblSinopse.Text = "Sinopse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(53, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "*";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(20, 41);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(420, 23);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(17, 228);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(118, 16);
            this.lblCPF.TabIndex = 0;
            this.lblCPF.Text = "Ano de lançamento";
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
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(397, 398);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(309, 398);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(12, 9);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(211, 16);
            this.lblAviso.TabIndex = 14;
            this.lblAviso.Text = "Os campos com * são obrigatórios.";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(217, 398);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // CadastrarFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 431);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbDadosFilme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastrarFilme";
            this.Text = "100% Video - Cadastrar Filme";
            this.Load += new System.EventHandler(this.CadastrarFilme_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadastrarFilme_FormClosing);
            this.gbDadosFilme.ResumeLayout(false);
            this.gbDadosFilme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDadosFilme;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.TextBox txtSinopse;
        private System.Windows.Forms.Label lblSinopse;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtDiretor;
        private System.Windows.Forms.Label lxlDiretor;
        private System.Windows.Forms.MaskedTextBox txtAnoLancamento;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cbClassificacao;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;

    }
}

