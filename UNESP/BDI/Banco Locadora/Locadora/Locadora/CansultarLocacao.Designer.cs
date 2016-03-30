namespace Locadora
{
    partial class ConsultarLocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarLocacao));
            this.gbDadosLocacao = new System.Windows.Forms.GroupBox();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.txtFilme = new System.Windows.Forms.TextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnPesquisarFilme = new System.Windows.Forms.Button();
            this.btnPesquisaCliente = new System.Windows.Forms.Button();
            this.lblFilme = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMesagem = new System.Windows.Forms.Label();
            this.dgvLocacao = new System.Windows.Forms.DataGridView();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.gbDadosLocacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacao)).BeginInit();
            this.gbResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDadosLocacao
            // 
            this.gbDadosLocacao.Controls.Add(this.cbSituacao);
            this.gbDadosLocacao.Controls.Add(this.txtFilme);
            this.gbDadosLocacao.Controls.Add(this.lblSituacao);
            this.gbDadosLocacao.Controls.Add(this.btnLimpar);
            this.gbDadosLocacao.Controls.Add(this.txtCliente);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisar);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisarFilme);
            this.gbDadosLocacao.Controls.Add(this.btnPesquisaCliente);
            this.gbDadosLocacao.Controls.Add(this.lblFilme);
            this.gbDadosLocacao.Controls.Add(this.lblCliente);
            this.gbDadosLocacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosLocacao.Location = new System.Drawing.Point(12, 12);
            this.gbDadosLocacao.Name = "gbDadosLocacao";
            this.gbDadosLocacao.Size = new System.Drawing.Size(460, 205);
            this.gbDadosLocacao.TabIndex = 0;
            this.gbDadosLocacao.TabStop = false;
            this.gbDadosLocacao.Text = "Dados locação";
            // 
            // cbSituacao
            // 
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Selecione uma situação",
            "Em aberto",
            "Fechada"});
            this.cbSituacao.Location = new System.Drawing.Point(20, 131);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(187, 24);
            this.cbSituacao.TabIndex = 47;
            // 
            // txtFilme
            // 
            this.txtFilme.Location = new System.Drawing.Point(20, 86);
            this.txtFilme.Name = "txtFilme";
            this.txtFilme.Size = new System.Drawing.Size(398, 23);
            this.txtFilme.TabIndex = 22;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(17, 112);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(57, 16);
            this.lblSituacao.TabIndex = 46;
            this.lblSituacao.Text = "Situação";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(284, 165);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(20, 41);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(398, 23);
            this.txtCliente.TabIndex = 21;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(374, 165);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 13;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            // dgvLocacao
            // 
            this.dgvLocacao.AllowUserToAddRows = false;
            this.dgvLocacao.AllowUserToDeleteRows = false;
            this.dgvLocacao.AllowUserToOrderColumns = true;
            this.dgvLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocacao.Location = new System.Drawing.Point(20, 52);
            this.dgvLocacao.Name = "dgvLocacao";
            this.dgvLocacao.ReadOnly = true;
            this.dgvLocacao.Size = new System.Drawing.Size(429, 169);
            this.dgvLocacao.TabIndex = 0;
            this.dgvLocacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocacao_CellDoubleClick);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.lblMesagem);
            this.gbResultado.Controls.Add(this.dgvLocacao);
            this.gbResultado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultado.Location = new System.Drawing.Point(12, 223);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(460, 227);
            this.gbResultado.TabIndex = 37;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado";
            // 
            // ConsultarLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbDadosLocacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarLocacao";
            this.Text = "100% Video - Consultar Locação";
            this.Load += new System.EventHandler(this.ConsultarLocacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultarLocacao_FormClosing);
            this.gbDadosLocacao.ResumeLayout(false);
            this.gbDadosLocacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacao)).EndInit();
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDadosLocacao;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFilme;
        private System.Windows.Forms.TextBox txtFilme;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnPesquisarFilme;
        private System.Windows.Forms.Button btnPesquisaCliente;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblMesagem;
        private System.Windows.Forms.DataGridView dgvLocacao;
        private System.Windows.Forms.GroupBox gbResultado;

    }
}

