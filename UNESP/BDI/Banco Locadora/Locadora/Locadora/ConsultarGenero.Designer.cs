﻿namespace Locadora
{
    partial class ConsultarGenero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarGenero));
            this.gbPesquisa = new System.Windows.Forms.GroupBox();
            this.lblPrateleira = new System.Windows.Forms.Label();
            this.txtPrateleira = new System.Windows.Forms.MaskedTextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.lblMesagem = new System.Windows.Forms.Label();
            this.dgvGenero = new System.Windows.Forms.DataGridView();
            this.gbPesquisa.SuspendLayout();
            this.gbResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenero)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPesquisa
            // 
            this.gbPesquisa.Controls.Add(this.lblPrateleira);
            this.gbPesquisa.Controls.Add(this.txtPrateleira);
            this.gbPesquisa.Controls.Add(this.btnLimpar);
            this.gbPesquisa.Controls.Add(this.btnPesquisar);
            this.gbPesquisa.Controls.Add(this.txtDescricao);
            this.gbPesquisa.Controls.Add(this.lblDescricao);
            this.gbPesquisa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPesquisa.Location = new System.Drawing.Point(12, 12);
            this.gbPesquisa.Name = "gbPesquisa";
            this.gbPesquisa.Size = new System.Drawing.Size(460, 122);
            this.gbPesquisa.TabIndex = 0;
            this.gbPesquisa.TabStop = false;
            this.gbPesquisa.Text = "Pesquisa";
            // 
            // lblPrateleira
            // 
            this.lblPrateleira.AutoSize = true;
            this.lblPrateleira.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrateleira.Location = new System.Drawing.Point(318, 22);
            this.lblPrateleira.Name = "lblPrateleira";
            this.lblPrateleira.Size = new System.Drawing.Size(63, 16);
            this.lblPrateleira.TabIndex = 33;
            this.lblPrateleira.Text = "Prateleira";
            // 
            // txtPrateleira
            // 
            this.txtPrateleira.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrateleira.Location = new System.Drawing.Point(321, 41);
            this.txtPrateleira.Mask = "?0";
            this.txtPrateleira.Name = "txtPrateleira";
            this.txtPrateleira.Size = new System.Drawing.Size(118, 23);
            this.txtPrateleira.TabIndex = 32;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(276, 83);
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
            this.btnPesquisar.Location = new System.Drawing.Point(364, 83);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(20, 41);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(281, 23);
            this.txtDescricao.TabIndex = 1;
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
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.lblMesagem);
            this.gbResultado.Controls.Add(this.dgvGenero);
            this.gbResultado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultado.Location = new System.Drawing.Point(12, 140);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(460, 337);
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
            // dgvGenero
            // 
            this.dgvGenero.AllowUserToAddRows = false;
            this.dgvGenero.AllowUserToDeleteRows = false;
            this.dgvGenero.AllowUserToOrderColumns = true;
            this.dgvGenero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenero.Location = new System.Drawing.Point(20, 52);
            this.dgvGenero.Name = "dgvGenero";
            this.dgvGenero.ReadOnly = true;
            this.dgvGenero.Size = new System.Drawing.Size(419, 279);
            this.dgvGenero.TabIndex = 0;
            this.dgvGenero.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenero_CellDoubleClick);
            // 
            // ConsultarGenero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 492);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbPesquisa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarGenero";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "100% Video - Consultar Gênero";
            this.Load += new System.EventHandler(this.ConsultarGenero_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultarGenero_FormClosing);
            this.gbPesquisa.ResumeLayout(false);
            this.gbPesquisa.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPesquisa;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.Label lblMesagem;
        private System.Windows.Forms.DataGridView dgvGenero;
        private System.Windows.Forms.Label lblPrateleira;
        private System.Windows.Forms.MaskedTextBox txtPrateleira;

    }
}

