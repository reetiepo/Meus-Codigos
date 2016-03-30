namespace Locadora
{
    partial class DevolverFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolverFilme));
            this.gbDadosLocacao = new System.Windows.Forms.GroupBox();
            this.txtDataPrevistaDevolucao = new System.Windows.Forms.TextBox();
            this.lblDataPrevistaDevolucao = new System.Windows.Forms.Label();
            this.txtLocacao = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.lblMulta = new System.Windows.Forms.Label();
            this.txtDataLocacao = new System.Windows.Forms.TextBox();
            this.lblDataLocacao = new System.Windows.Forms.Label();
            this.btnPesquisaLocacao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocacao = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.gbDadosLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDadosLocacao
            // 
            this.gbDadosLocacao.Controls.Add(this.txtDataPrevistaDevolucao);
            this.gbDadosLocacao.Controls.Add(this.lblDataPrevistaDevolucao);
            this.gbDadosLocacao.Controls.Add(this.txtLocacao);
            this.gbDadosLocacao.Controls.Add(this.btnLimpar);
            this.gbDadosLocacao.Controls.Add(this.txtValor);
            this.gbDadosLocacao.Controls.Add(this.btnDevolver);
            this.gbDadosLocacao.Controls.Add(this.lblValor);
            this.gbDadosLocacao.Controls.Add(this.txtMulta);
            this.gbDadosLocacao.Controls.Add(this.lblMulta);
            this.gbDadosLocacao.Controls.Add(this.txtDataLocacao);
            this.gbDadosLocacao.Controls.Add(this.lblDataLocacao);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisaLocacao);
            this.gbDadosLocacao.Controls.Add(this.label2);
            this.gbDadosLocacao.Controls.Add(this.lblLocacao);
            this.gbDadosLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosLocacao.Location = new System.Drawing.Point(12, 35);
            this.gbDadosLocacao.Name = "gbDadosLocacao";
            this.gbDadosLocacao.Size = new System.Drawing.Size(460, 199);
            this.gbDadosLocacao.TabIndex = 0;
            this.gbDadosLocacao.TabStop = false;
            this.gbDadosLocacao.Text = "Dados locação";
            // 
            // txtDataPrevistaDevolucao
            // 
            this.txtDataPrevistaDevolucao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataPrevistaDevolucao.Location = new System.Drawing.Point(183, 86);
            this.txtDataPrevistaDevolucao.MaxLength = 50;
            this.txtDataPrevistaDevolucao.Name = "txtDataPrevistaDevolucao";
            this.txtDataPrevistaDevolucao.ReadOnly = true;
            this.txtDataPrevistaDevolucao.Size = new System.Drawing.Size(140, 23);
            this.txtDataPrevistaDevolucao.TabIndex = 23;
            // 
            // lblDataPrevistaDevolucao
            // 
            this.lblDataPrevistaDevolucao.AutoSize = true;
            this.lblDataPrevistaDevolucao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPrevistaDevolucao.Location = new System.Drawing.Point(180, 67);
            this.lblDataPrevistaDevolucao.Name = "lblDataPrevistaDevolucao";
            this.lblDataPrevistaDevolucao.Size = new System.Drawing.Size(174, 16);
            this.lblDataPrevistaDevolucao.TabIndex = 22;
            this.lblDataPrevistaDevolucao.Text = "Data prevista para devolução";
            // 
            // txtLocacao
            // 
            this.txtLocacao.Location = new System.Drawing.Point(20, 41);
            this.txtLocacao.Name = "txtLocacao";
            this.txtLocacao.ReadOnly = true;
            this.txtLocacao.Size = new System.Drawing.Size(398, 23);
            this.txtLocacao.TabIndex = 21;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(286, 163);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(147, 131);
            this.txtValor.MaxLength = 50;
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(100, 23);
            this.txtValor.TabIndex = 20;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolver.Location = new System.Drawing.Point(374, 163);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 13;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(144, 112);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(67, 16);
            this.lblValor.TabIndex = 19;
            this.lblValor.Text = "Valor total";
            // 
            // txtMulta
            // 
            this.txtMulta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMulta.Location = new System.Drawing.Point(20, 131);
            this.txtMulta.MaxLength = 50;
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.ReadOnly = true;
            this.txtMulta.Size = new System.Drawing.Size(100, 23);
            this.txtMulta.TabIndex = 18;
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulta.Location = new System.Drawing.Point(17, 112);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(74, 16);
            this.lblMulta.TabIndex = 17;
            this.lblMulta.Text = "Valor multa";
            // 
            // txtDataLocacao
            // 
            this.txtDataLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataLocacao.Location = new System.Drawing.Point(20, 86);
            this.txtDataLocacao.MaxLength = 50;
            this.txtDataLocacao.Name = "txtDataLocacao";
            this.txtDataLocacao.ReadOnly = true;
            this.txtDataLocacao.Size = new System.Drawing.Size(140, 23);
            this.txtDataLocacao.TabIndex = 16;
            // 
            // lblDataLocacao
            // 
            this.lblDataLocacao.AutoSize = true;
            this.lblDataLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataLocacao.Location = new System.Drawing.Point(17, 67);
            this.lblDataLocacao.Name = "lblDataLocacao";
            this.lblDataLocacao.Size = new System.Drawing.Size(81, 16);
            this.lblDataLocacao.TabIndex = 15;
            this.lblDataLocacao.Text = "Data locação";
            // 
            // btnPesquisaLocacao
            // 
            this.btnPesquisaLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaLocacao.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisaLocacao.Image")));
            this.btnPesquisaLocacao.Location = new System.Drawing.Point(424, 39);
            this.btnPesquisaLocacao.Name = "btnPesquisaLocacao";
            this.btnPesquisaLocacao.Size = new System.Drawing.Size(25, 25);
            this.btnPesquisaLocacao.TabIndex = 13;
            this.btnPesquisaLocacao.UseVisualStyleBackColor = true;
            this.btnPesquisaLocacao.Click += new System.EventHandler(this.btnPesquisaLocacao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(66, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "*";
            // 
            // lblLocacao
            // 
            this.lblLocacao.AutoSize = true;
            this.lblLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocacao.Location = new System.Drawing.Point(17, 22);
            this.lblLocacao.Name = "lblLocacao";
            this.lblLocacao.Size = new System.Drawing.Size(54, 16);
            this.lblLocacao.TabIndex = 0;
            this.lblLocacao.Text = "Locação";
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
            // DevolverFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 243);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.gbDadosLocacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevolverFilme";
            this.Text = "100% Video - Devolver Filme";
            this.Load += new System.EventHandler(this.DevolverFilme_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DevolverFilme_FormClosing);
            this.gbDadosLocacao.ResumeLayout(false);
            this.gbDadosLocacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDadosLocacao;
        private System.Windows.Forms.Label lblLocacao;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnPesquisaLocacao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.TextBox txtDataLocacao;
        private System.Windows.Forms.Label lblDataLocacao;
        private System.Windows.Forms.TextBox txtLocacao;
        private System.Windows.Forms.TextBox txtDataPrevistaDevolucao;
        private System.Windows.Forms.Label lblDataPrevistaDevolucao;

    }
}

