﻿namespace Locadora
{
    partial class RelatorioLocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioLocacao));
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.cbClassificacao = new System.Windows.Forms.ComboBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.txtDataIni = new System.Windows.Forms.MaskedTextBox();
            this.lblDataIni = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.cbOrder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(364, 215);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(108, 23);
            this.btnGerarRelatorio.TabIndex = 13;
            this.btnGerarRelatorio.Text = "Gerar relatório";
            this.btnGerarRelatorio.UseVisualStyleBackColor = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(270, 215);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // cbClassificacao
            // 
            this.cbClassificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassificacao.FormattingEnabled = true;
            this.cbClassificacao.Location = new System.Drawing.Point(258, 53);
            this.cbClassificacao.Name = "cbClassificacao";
            this.cbClassificacao.Size = new System.Drawing.Size(182, 24);
            this.cbClassificacao.TabIndex = 32;
            // 
            // cbGenero
            // 
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(20, 53);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(207, 24);
            this.cbGenero.TabIndex = 31;
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificacao.Location = new System.Drawing.Point(255, 34);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(81, 16);
            this.lblClassificacao.TabIndex = 30;
            this.lblClassificacao.Text = "Classificação";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(17, 33);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(49, 16);
            this.lblGenero.TabIndex = 29;
            this.lblGenero.Text = "Gênero";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.cbOrder);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.cbSituacao);
            this.gbFiltros.Controls.Add(this.lblSituacao);
            this.gbFiltros.Controls.Add(this.txtDataFim);
            this.gbFiltros.Controls.Add(this.lblDe);
            this.gbFiltros.Controls.Add(this.txtDataIni);
            this.gbFiltros.Controls.Add(this.lblDataIni);
            this.gbFiltros.Controls.Add(this.lblGenero);
            this.gbFiltros.Controls.Add(this.lblAte);
            this.gbFiltros.Controls.Add(this.cbGenero);
            this.gbFiltros.Controls.Add(this.cbClassificacao);
            this.gbFiltros.Controls.Add(this.lblClassificacao);
            this.gbFiltros.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(460, 188);
            this.gbFiltros.TabIndex = 33;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(260, 94);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(73, 23);
            this.txtDataFim.TabIndex = 38;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(120, 97);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(22, 16);
            this.lblDe.TabIndex = 37;
            this.lblDe.Text = "de";
            // 
            // txtDataIni
            // 
            this.txtDataIni.Location = new System.Drawing.Point(149, 94);
            this.txtDataIni.Mask = "00/00/0000";
            this.txtDataIni.Name = "txtDataIni";
            this.txtDataIni.Size = new System.Drawing.Size(73, 23);
            this.txtDataIni.TabIndex = 36;
            // 
            // lblDataIni
            // 
            this.lblDataIni.AutoSize = true;
            this.lblDataIni.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataIni.Location = new System.Drawing.Point(17, 97);
            this.lblDataIni.Name = "lblDataIni";
            this.lblDataIni.Size = new System.Drawing.Size(108, 16);
            this.lblDataIni.TabIndex = 33;
            this.lblDataIni.Text = "Data da locação: ";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.Location = new System.Drawing.Point(228, 97);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 16);
            this.lblAte.TabIndex = 34;
            this.lblAte.Text = "até";
            // 
            // cbSituacao
            // 
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Selecione uma situação",
            "Em aberto",
            "Fechada"});
            this.cbSituacao.Location = new System.Drawing.Point(20, 144);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(202, 24);
            this.cbSituacao.TabIndex = 49;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(17, 125);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(57, 16);
            this.lblSituacao.TabIndex = 48;
            this.lblSituacao.Text = "Situação";
            // 
            // cbOrder
            // 
            this.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrder.FormattingEnabled = true;
            this.cbOrder.Items.AddRange(new object[] {
            "Selecione uma ordenação",
            "Cliente",
            "Filme",
            "Data Locacao",
            "Data Devolucao",
            "Valor"});
            this.cbOrder.Location = new System.Drawing.Point(258, 144);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(182, 24);
            this.cbOrder.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Ordenar por";
            // 
            // RelatorioLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 256);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RelatorioLocacao";
            this.Text = "100% Video - Relatório de Locações";
            this.Load += new System.EventHandler(this.RelatorioLocacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelatorioLocacao_FormClosing);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cbClassificacao;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lblDataIni;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox txtDataIni;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.ComboBox cbOrder;
        private System.Windows.Forms.Label label1;

    }
}

