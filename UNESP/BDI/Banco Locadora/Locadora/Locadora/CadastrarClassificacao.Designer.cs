namespace Locadora
{
    partial class CadastrarClassificacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarClassificacao));
            this.gbDadosClassificacao = new System.Windows.Forms.GroupBox();
            this.txtValor = new System.Windows.Forms.NumericUpDown();
            this.txtTempo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.gbDadosClassificacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDadosClassificacao
            // 
            this.gbDadosClassificacao.Controls.Add(this.txtValor);
            this.gbDadosClassificacao.Controls.Add(this.txtTempo);
            this.gbDadosClassificacao.Controls.Add(this.label1);
            this.gbDadosClassificacao.Controls.Add(this.lblTempo);
            this.gbDadosClassificacao.Controls.Add(this.label4);
            this.gbDadosClassificacao.Controls.Add(this.lblValor);
            this.gbDadosClassificacao.Controls.Add(this.label2);
            this.gbDadosClassificacao.Controls.Add(this.txtDescricao);
            this.gbDadosClassificacao.Controls.Add(this.lblDescricao);
            this.gbDadosClassificacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosClassificacao.Location = new System.Drawing.Point(12, 35);
            this.gbDadosClassificacao.Name = "gbDadosClassificacao";
            this.gbDadosClassificacao.Size = new System.Drawing.Size(316, 150);
            this.gbDadosClassificacao.TabIndex = 0;
            this.gbDadosClassificacao.TabStop = false;
            this.gbDadosClassificacao.Text = "Dados classificação";
            // 
            // txtValor
            // 
            this.txtValor.DecimalPlaces = 2;
            this.txtValor.Increment = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            this.txtValor.Location = new System.Drawing.Point(20, 95);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(101, 23);
            this.txtValor.TabIndex = 41;
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(173, 95);
            this.txtTempo.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtTempo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.ReadOnly = true;
            this.txtTempo.Size = new System.Drawing.Size(84, 23);
            this.txtTempo.TabIndex = 40;
            this.txtTempo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(252, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "*";
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(172, 75);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(85, 16);
            this.lblTempo.TabIndex = 38;
            this.lblTempo.Text = "Tempo (dias)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(80, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "*";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(17, 75);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(67, 16);
            this.lblValor.TabIndex = 35;
            this.lblValor.Text = "Valor (R$)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(76, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "*";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(20, 41);
            this.txtDescricao.MaxLength = 20;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(273, 23);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.TextChanged += new System.EventHandler(this.txtDescricao_TextChanged);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(17, 22);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(63, 16);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(260, 205);
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
            this.btnLimpar.Location = new System.Drawing.Point(172, 205);
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
            this.btnExcluir.Location = new System.Drawing.Point(82, 205);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // CadastrarClassificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(347, 240);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbDadosClassificacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastrarClassificacao";
            this.Text = "100% Video - Cadastrar Classificação";
            this.Load += new System.EventHandler(this.CadastrarClassificacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadastrarClassificacao_FormClosing);
            this.gbDadosClassificacao.ResumeLayout(false);
            this.gbDadosClassificacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDadosClassificacao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown txtTempo;
        private System.Windows.Forms.NumericUpDown txtValor;
        private System.Windows.Forms.Button btnExcluir;

    }
}

