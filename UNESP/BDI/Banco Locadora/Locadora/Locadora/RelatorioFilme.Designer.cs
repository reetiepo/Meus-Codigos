namespace Locadora
{
    partial class RelatorioFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatorioFilme));
            this.gbTipoRel = new System.Windows.Forms.GroupBox();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.rbPorGenero = new System.Windows.Forms.RadioButton();
            this.rbPorClassificacao = new System.Windows.Forms.RadioButton();
            this.rbPorMes = new System.Windows.Forms.RadioButton();
            this.rbPorAno = new System.Windows.Forms.RadioButton();
            this.cbClassificacao = new System.Windows.Forms.ComboBox();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblDataIni = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.txtDataIni = new System.Windows.Forms.MaskedTextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.gbTipoRel.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTipoRel
            // 
            this.gbTipoRel.Controls.Add(this.rbPorAno);
            this.gbTipoRel.Controls.Add(this.rbPorMes);
            this.gbTipoRel.Controls.Add(this.rbPorClassificacao);
            this.gbTipoRel.Controls.Add(this.rbPorGenero);
            this.gbTipoRel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoRel.Location = new System.Drawing.Point(12, 12);
            this.gbTipoRel.Name = "gbTipoRel";
            this.gbTipoRel.Size = new System.Drawing.Size(460, 149);
            this.gbTipoRel.TabIndex = 0;
            this.gbTipoRel.TabStop = false;
            this.gbTipoRel.Text = "Tipo Relatório";
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRelatorio.Location = new System.Drawing.Point(364, 323);
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
            this.btnLimpar.Location = new System.Drawing.Point(270, 323);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // rbPorGenero
            // 
            this.rbPorGenero.AutoSize = true;
            this.rbPorGenero.Location = new System.Drawing.Point(21, 33);
            this.rbPorGenero.Name = "rbPorGenero";
            this.rbPorGenero.Size = new System.Drawing.Size(208, 20);
            this.rbPorGenero.TabIndex = 29;
            this.rbPorGenero.TabStop = true;
            this.rbPorGenero.Text = "Filmes mais locados por gênero";
            this.rbPorGenero.UseVisualStyleBackColor = true;
            // 
            // rbPorClassificacao
            // 
            this.rbPorClassificacao.AutoSize = true;
            this.rbPorClassificacao.Location = new System.Drawing.Point(21, 59);
            this.rbPorClassificacao.Name = "rbPorClassificacao";
            this.rbPorClassificacao.Size = new System.Drawing.Size(239, 20);
            this.rbPorClassificacao.TabIndex = 30;
            this.rbPorClassificacao.TabStop = true;
            this.rbPorClassificacao.Text = "Filmes mais locados por classificação";
            this.rbPorClassificacao.UseVisualStyleBackColor = true;
            // 
            // rbPorMes
            // 
            this.rbPorMes.AutoSize = true;
            this.rbPorMes.Location = new System.Drawing.Point(20, 85);
            this.rbPorMes.Name = "rbPorMes";
            this.rbPorMes.Size = new System.Drawing.Size(192, 20);
            this.rbPorMes.TabIndex = 31;
            this.rbPorMes.TabStop = true;
            this.rbPorMes.Text = "Filmes mais locados por mês";
            this.rbPorMes.UseVisualStyleBackColor = true;
            // 
            // rbPorAno
            // 
            this.rbPorAno.AutoSize = true;
            this.rbPorAno.Location = new System.Drawing.Point(20, 111);
            this.rbPorAno.Name = "rbPorAno";
            this.rbPorAno.Size = new System.Drawing.Size(189, 20);
            this.rbPorAno.TabIndex = 32;
            this.rbPorAno.TabStop = true;
            this.rbPorAno.Text = "Filmes mais locados por ano";
            this.rbPorAno.UseVisualStyleBackColor = true;
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
            this.gbFiltros.Location = new System.Drawing.Point(12, 167);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(460, 136);
            this.gbFiltros.TabIndex = 33;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
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
            // txtDataIni
            // 
            this.txtDataIni.Location = new System.Drawing.Point(149, 94);
            this.txtDataIni.Mask = "00/00/0000";
            this.txtDataIni.Name = "txtDataIni";
            this.txtDataIni.Size = new System.Drawing.Size(73, 23);
            this.txtDataIni.TabIndex = 36;
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
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(260, 94);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(73, 23);
            this.txtDataFim.TabIndex = 38;
            // 
            // RelatorioFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Controls.Add(this.gbTipoRel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RelatorioFilme";
            this.Text = "100% Video - Relatório Filmes Mais Locados";
            this.Load += new System.EventHandler(this.RelatorioFilme_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelatorioFilme_FormClosing);
            this.gbTipoRel.ResumeLayout(false);
            this.gbTipoRel.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTipoRel;
        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.RadioButton rbPorAno;
        private System.Windows.Forms.RadioButton rbPorMes;
        private System.Windows.Forms.RadioButton rbPorClassificacao;
        private System.Windows.Forms.RadioButton rbPorGenero;
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

    }
}

