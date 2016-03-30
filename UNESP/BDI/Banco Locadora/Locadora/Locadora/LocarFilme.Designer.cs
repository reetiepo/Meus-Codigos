namespace Locadora
{
    partial class LocarFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocarFilme));
            this.gbDadosLocacao = new System.Windows.Forms.GroupBox();
            this.txtFilme = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtDevolverEm = new System.Windows.Forms.TextBox();
            this.lblDevolverEm = new System.Windows.Forms.Label();
            this.txtDataLocacao = new System.Windows.Forms.TextBox();
            this.lblDataLocacao = new System.Windows.Forms.Label();
            this.btnPesquisarFilme = new System.Windows.Forms.Button();
            this.btnPesquisaCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnLocar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.gbDadosLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDadosLocacao
            // 
            this.gbDadosLocacao.Controls.Add(this.txtFilme);
            this.gbDadosLocacao.Controls.Add(this.txtCliente);
            this.gbDadosLocacao.Controls.Add(this.txtValor);
            this.gbDadosLocacao.Controls.Add(this.lblValor);
            this.gbDadosLocacao.Controls.Add(this.txtDevolverEm);
            this.gbDadosLocacao.Controls.Add(this.lblDevolverEm);
            this.gbDadosLocacao.Controls.Add(this.txtDataLocacao);
            this.gbDadosLocacao.Controls.Add(this.lblDataLocacao);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisarFilme);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisaCliente);
            this.gbDadosLocacao.Controls.Add(this.label1);
            this.gbDadosLocacao.Controls.Add(this.lblFilme);
            this.gbDadosLocacao.Controls.Add(this.label2);
            this.gbDadosLocacao.Controls.Add(this.lblCliente);
            this.gbDadosLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosLocacao.Location = new System.Drawing.Point(12, 35);
            this.gbDadosLocacao.Name = "gbDadosLocacao";
            this.gbDadosLocacao.Size = new System.Drawing.Size(460, 175);
            this.gbDadosLocacao.TabIndex = 0;
            this.gbDadosLocacao.TabStop = false;
            this.gbDadosLocacao.Text = "Dados locação";
            // 
            // txtFilme
            // 
            this.txtFilme.Location = new System.Drawing.Point(20, 86);
            this.txtFilme.Name = "txtFilme";
            this.txtFilme.ReadOnly = true;
            this.txtFilme.Size = new System.Drawing.Size(398, 23);
            this.txtFilme.TabIndex = 22;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(20, 41);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(398, 23);
            this.txtCliente.TabIndex = 21;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(311, 131);
            this.txtValor.MaxLength = 50;
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(107, 23);
            this.txtValor.TabIndex = 20;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(308, 112);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(38, 16);
            this.lblValor.TabIndex = 19;
            this.lblValor.Text = "Valor";
            // 
            // txtDevolverEm
            // 
            this.txtDevolverEm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevolverEm.Location = new System.Drawing.Point(171, 131);
            this.txtDevolverEm.MaxLength = 50;
            this.txtDevolverEm.Name = "txtDevolverEm";
            this.txtDevolverEm.ReadOnly = true;
            this.txtDevolverEm.Size = new System.Drawing.Size(107, 23);
            this.txtDevolverEm.TabIndex = 18;
            // 
            // lblDevolverEm
            // 
            this.lblDevolverEm.AutoSize = true;
            this.lblDevolverEm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevolverEm.Location = new System.Drawing.Point(168, 112);
            this.lblDevolverEm.Name = "lblDevolverEm";
            this.lblDevolverEm.Size = new System.Drawing.Size(79, 16);
            this.lblDevolverEm.TabIndex = 17;
            this.lblDevolverEm.Text = "Devolver em";
            // 
            // txtDataLocacao
            // 
            this.txtDataLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataLocacao.Location = new System.Drawing.Point(23, 131);
            this.txtDataLocacao.MaxLength = 50;
            this.txtDataLocacao.Name = "txtDataLocacao";
            this.txtDataLocacao.ReadOnly = true;
            this.txtDataLocacao.Size = new System.Drawing.Size(107, 23);
            this.txtDataLocacao.TabIndex = 16;
            // 
            // lblDataLocacao
            // 
            this.lblDataLocacao.AutoSize = true;
            this.lblDataLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataLocacao.Location = new System.Drawing.Point(20, 112);
            this.lblDataLocacao.Name = "lblDataLocacao";
            this.lblDataLocacao.Size = new System.Drawing.Size(81, 16);
            this.lblDataLocacao.TabIndex = 15;
            this.lblDataLocacao.Text = "Data locação";
            // 
            // btnPesquisarFilme
            // 
            this.btnPesquisarFilme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarFilme.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarFilme.Image")));
            this.btnPesquisarFilme.Location = new System.Drawing.Point(424, 84);
            this.btnPesquisarFilme.Name = "btnPesquisarFilme";
            this.btnPesquisarFilme.Size = new System.Drawing.Size(25, 25);
            this.btnPesquisarFilme.TabIndex = 14;
            this.btnPesquisarFilme.UseVisualStyleBackColor = true;
            this.btnPesquisarFilme.Click += new System.EventHandler(this.btnPesquisarFilme_Click);
            // 
            // btnPesquisaCliente
            // 
            this.btnPesquisaCliente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisaCliente.Image")));
            this.btnPesquisaCliente.Location = new System.Drawing.Point(424, 39);
            this.btnPesquisaCliente.Name = "btnPesquisaCliente";
            this.btnPesquisaCliente.Size = new System.Drawing.Size(25, 25);
            this.btnPesquisaCliente.TabIndex = 13;
            this.btnPesquisaCliente.UseVisualStyleBackColor = true;
            this.btnPesquisaCliente.Click += new System.EventHandler(this.btnPesquisaCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(51, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "*";
            // 
            // lblFilme
            // 
            this.lblFilme.AutoSize = true;
            this.lblFilme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilme.Location = new System.Drawing.Point(17, 67);
            this.lblFilme.Name = "lblFilme";
            this.lblFilme.Size = new System.Drawing.Size(39, 16);
            this.lblFilme.TabIndex = 4;
            this.lblFilme.Text = "Filme";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(59, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "*";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(17, 22);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 16);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente";
            // 
            // btnLocar
            // 
            this.btnLocar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocar.Location = new System.Drawing.Point(397, 226);
            this.btnLocar.Name = "btnLocar";
            this.btnLocar.Size = new System.Drawing.Size(75, 23);
            this.btnLocar.TabIndex = 13;
            this.btnLocar.Text = "Locar";
            this.btnLocar.UseVisualStyleBackColor = true;
            this.btnLocar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(309, 226);
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
            // LocarFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnLocar);
            this.Controls.Add(this.gbDadosLocacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocarFilme";
            this.Text = "100% Video - Locar Filme";
            this.Load += new System.EventHandler(this.LocarFilme_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocarFilme_FormClosing);
            this.gbDadosLocacao.ResumeLayout(false);
            this.gbDadosLocacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDadosLocacao;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnLocar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFilme;
        private System.Windows.Forms.Button btnPesquisaCliente;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtDevolverEm;
        private System.Windows.Forms.Label lblDevolverEm;
        private System.Windows.Forms.TextBox txtDataLocacao;
        private System.Windows.Forms.Label lblDataLocacao;
        private System.Windows.Forms.Button btnPesquisarFilme;
        private System.Windows.Forms.TextBox txtFilme;
        private System.Windows.Forms.TextBox txtCliente;

    }
}

