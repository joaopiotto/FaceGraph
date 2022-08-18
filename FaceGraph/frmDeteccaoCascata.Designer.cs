namespace UI
{
    partial class frmDeteccaoCascata
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAjuste = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTamanhoMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTamanhoMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cmbHaarCascade = new System.Windows.Forms.ComboBox();
            this.btnDetectar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.tmrTempoReal = new System.Windows.Forms.Timer(this.components);
            this.imgResultado = new System.Windows.Forms.PictureBox();
            this.ofdAbrir = new System.Windows.Forms.OpenFileDialog();
            this.fbdDiretorio = new System.Windows.Forms.FolderBrowserDialog();
            this.ckbUnico = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.ckbUnico);
            this.panel1.Controls.Add(this.txtAjuste);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTamanhoMax);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTamanhoMin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnParar);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.cmbHaarCascade);
            this.panel1.Controls.Add(this.btnDetectar);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 32);
            this.panel1.TabIndex = 4;
            // 
            // txtAjuste
            // 
            this.txtAjuste.Location = new System.Drawing.Point(1158, 4);
            this.txtAjuste.Name = "txtAjuste";
            this.txtAjuste.Size = new System.Drawing.Size(100, 20);
            this.txtAjuste.TabIndex = 12;
            this.txtAjuste.Text = "-10,-10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ajustar janla corte em:";
            // 
            // txtTamanhoMax
            // 
            this.txtTamanhoMax.Location = new System.Drawing.Point(521, 6);
            this.txtTamanhoMax.Name = "txtTamanhoMax";
            this.txtTamanhoMax.Size = new System.Drawing.Size(71, 20);
            this.txtTamanhoMax.TabIndex = 10;
            this.txtTamanhoMax.Text = "300,300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tamanho máximo:";
            // 
            // txtTamanhoMin
            // 
            this.txtTamanhoMin.Location = new System.Drawing.Point(348, 6);
            this.txtTamanhoMin.Name = "txtTamanhoMin";
            this.txtTamanhoMin.Size = new System.Drawing.Size(71, 20);
            this.txtTamanhoMin.TabIndex = 8;
            this.txtTamanhoMin.Text = "80,60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tamanho mínimo:";
            // 
            // btnParar
            // 
            this.btnParar.Image = global::UI.Properties.Resources.delete;
            this.btnParar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParar.Location = new System.Drawing.Point(741, 3);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(62, 23);
            this.btnParar.TabIndex = 5;
            this.btnParar.Text = "Parar";
            this.btnParar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::UI.Properties.Resources.export;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(933, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 23);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar em lote";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cmbHaarCascade
            // 
            this.cmbHaarCascade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHaarCascade.FormattingEnabled = true;
            this.cmbHaarCascade.Location = new System.Drawing.Point(7, 5);
            this.cmbHaarCascade.Name = "cmbHaarCascade";
            this.cmbHaarCascade.Size = new System.Drawing.Size(237, 21);
            this.cmbHaarCascade.TabIndex = 5;
            // 
            // btnDetectar
            // 
            this.btnDetectar.Image = global::UI.Properties.Resources.statistics2;
            this.btnDetectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetectar.Location = new System.Drawing.Point(807, 3);
            this.btnDetectar.Name = "btnDetectar";
            this.btnDetectar.Size = new System.Drawing.Size(120, 23);
            this.btnDetectar.TabIndex = 3;
            this.btnDetectar.Text = "Processar imagem";
            this.btnDetectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetectar.UseVisualStyleBackColor = true;
            this.btnDetectar.Click += new System.EventHandler(this.btnDetectar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = global::UI.Properties.Resources.forward;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(673, 3);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(62, 23);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // tmrTempoReal
            // 
            this.tmrTempoReal.Tick += new System.EventHandler(this.tmrTempoReal_Tick);
            // 
            // imgResultado
            // 
            this.imgResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgResultado.Location = new System.Drawing.Point(0, 32);
            this.imgResultado.Name = "imgResultado";
            this.imgResultado.Size = new System.Drawing.Size(1300, 316);
            this.imgResultado.TabIndex = 5;
            this.imgResultado.TabStop = false;
            // 
            // fbdDiretorio
            // 
            this.fbdDiretorio.SelectedPath = "C:\\SIFT";
            // 
            // ckbUnico
            // 
            this.ckbUnico.AutoSize = true;
            this.ckbUnico.Location = new System.Drawing.Point(598, 11);
            this.ckbUnico.Name = "ckbUnico";
            this.ckbUnico.Size = new System.Drawing.Size(72, 17);
            this.ckbUnico.TabIndex = 13;
            this.ckbUnico.Text = "Uma face";
            this.ckbUnico.UseVisualStyleBackColor = true;
            // 
            // frmDeteccaoCascata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 348);
            this.Controls.Add(this.imgResultado);
            this.Controls.Add(this.panel1);
            this.Name = "frmDeteccaoCascata";
            this.Text = "Detectar características Haar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTamanhoMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox cmbHaarCascade;
        private System.Windows.Forms.Button btnDetectar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Timer tmrTempoReal;
        private System.Windows.Forms.PictureBox imgResultado;
        private System.Windows.Forms.TextBox txtTamanhoMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdAbrir;
        private System.Windows.Forms.FolderBrowserDialog fbdDiretorio;
        private System.Windows.Forms.TextBox txtAjuste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbUnico;
    }
}