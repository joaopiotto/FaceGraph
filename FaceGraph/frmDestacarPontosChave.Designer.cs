namespace UI
{
    partial class frmDestacarPontosChave
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbFiltro = new System.Windows.Forms.CheckBox();
            this.btnRegiaoInteresse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRaio = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExportarLote = new System.Windows.Forms.Button();
            this.cmbDescritor = new System.Windows.Forms.ComboBox();
            this.btnDetectar = new System.Windows.Forms.Button();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.imgFigura = new System.Windows.Forms.PictureBox();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.fbdAbrir = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdSalvar = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFigura)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.ckbFiltro);
            this.panel1.Controls.Add(this.btnRegiaoInteresse);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRaio);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnExportarLote);
            this.panel1.Controls.Add(this.cmbDescritor);
            this.panel1.Controls.Add(this.btnDetectar);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 32);
            this.panel1.TabIndex = 3;
            // 
            // ckbFiltro
            // 
            this.ckbFiltro.AutoSize = true;
            this.ckbFiltro.Location = new System.Drawing.Point(855, 9);
            this.ckbFiltro.Name = "ckbFiltro";
            this.ckbFiltro.Size = new System.Drawing.Size(142, 17);
            this.ckbFiltro.TabIndex = 12;
            this.ckbFiltro.Text = "Aplicar filtro do centróide";
            this.ckbFiltro.UseVisualStyleBackColor = true;
            // 
            // btnRegiaoInteresse
            // 
            this.btnRegiaoInteresse.Enabled = false;
            this.btnRegiaoInteresse.Image = global::UI.Properties.Resources.statistics2;
            this.btnRegiaoInteresse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegiaoInteresse.Location = new System.Drawing.Point(463, 4);
            this.btnRegiaoInteresse.Name = "btnRegiaoInteresse";
            this.btnRegiaoInteresse.Size = new System.Drawing.Size(184, 23);
            this.btnRegiaoInteresse.TabIndex = 11;
            this.btnRegiaoInteresse.Text = "Detectar pontos na região facial";
            this.btnRegiaoInteresse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegiaoInteresse.UseVisualStyleBackColor = true;
            this.btnRegiaoInteresse.Click += new System.EventHandler(this.btnRegiaoInteresse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Raio:";
            // 
            // txtRaio
            // 
            this.txtRaio.Location = new System.Drawing.Point(800, 4);
            this.txtRaio.Name = "txtRaio";
            this.txtRaio.Size = new System.Drawing.Size(51, 20);
            this.txtRaio.TabIndex = 9;
            this.txtRaio.Text = "1,5";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1002, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 7;
            // 
            // btnExportarLote
            // 
            this.btnExportarLote.Image = global::UI.Properties.Resources.export;
            this.btnExportarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarLote.Location = new System.Drawing.Point(653, 4);
            this.btnExportarLote.Name = "btnExportarLote";
            this.btnExportarLote.Size = new System.Drawing.Size(110, 23);
            this.btnExportarLote.TabIndex = 6;
            this.btnExportarLote.Text = "Exportar em lote";
            this.btnExportarLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarLote.UseVisualStyleBackColor = true;
            this.btnExportarLote.Click += new System.EventHandler(this.btnExportarLote_Click);
            // 
            // cmbDescritor
            // 
            this.cmbDescritor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescritor.FormattingEnabled = true;
            this.cmbDescritor.Location = new System.Drawing.Point(7, 4);
            this.cmbDescritor.Name = "cmbDescritor";
            this.cmbDescritor.Size = new System.Drawing.Size(171, 21);
            this.cmbDescritor.TabIndex = 5;
            // 
            // btnDetectar
            // 
            this.btnDetectar.Enabled = false;
            this.btnDetectar.Image = global::UI.Properties.Resources.statistics2;
            this.btnDetectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetectar.Location = new System.Drawing.Point(313, 4);
            this.btnDetectar.Name = "btnDetectar";
            this.btnDetectar.Size = new System.Drawing.Size(144, 23);
            this.btnDetectar.TabIndex = 3;
            this.btnDetectar.Text = "Detectar Pontos chave";
            this.btnDetectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetectar.UseVisualStyleBackColor = true;
            this.btnDetectar.Click += new System.EventHandler(this.btnDetectar_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = global::UI.Properties.Resources.home;
            this.btnSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionar.Location = new System.Drawing.Point(184, 4);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(123, 23);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Text = "Selecionar imagem";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // imgFigura
            // 
            this.imgFigura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgFigura.Location = new System.Drawing.Point(0, 32);
            this.imgFigura.Name = "imgFigura";
            this.imgFigura.Size = new System.Drawing.Size(1094, 321);
            this.imgFigura.TabIndex = 4;
            this.imgFigura.TabStop = false;
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.InitialDirectory = "C:\\SIFT";
            // 
            // fbdAbrir
            // 
            this.fbdAbrir.SelectedPath = "C:\\SIFT";
            // 
            // frmDestacarPontosChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 353);
            this.Controls.Add(this.imgFigura);
            this.Controls.Add(this.panel1);
            this.Name = "frmDestacarPontosChave";
            this.Text = "Destacar pontos chave";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFigura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDescritor;
        private System.Windows.Forms.Button btnDetectar;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.PictureBox imgFigura;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Button btnExportarLote;
        private System.Windows.Forms.FolderBrowserDialog fbdAbrir;
        private System.Windows.Forms.SaveFileDialog sfdSalvar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRaio;
        private System.Windows.Forms.Button btnRegiaoInteresse;
        private System.Windows.Forms.CheckBox ckbFiltro;
    }
}