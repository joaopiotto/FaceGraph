namespace UI
{
    partial class frmAnaliseTextura
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbReescalar = new System.Windows.Forms.CheckBox();
            this.btnLimparMedidas = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnIncluirMedida = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.ckbOrdenar = new System.Windows.Forms.CheckBox();
            this.txtTamanhoVetor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRaio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCentralidade = new System.Windows.Forms.ComboBox();
            this.cmbDescritor = new System.Windows.Forms.ComboBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.fbdAbrir = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdSalvar = new System.Windows.Forms.SaveFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chtResultado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ckbGerarImagens = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtResultado)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.ckbGerarImagens);
            this.panel1.Controls.Add(this.ckbReescalar);
            this.panel1.Controls.Add(this.btnLimparMedidas);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.btnIncluirMedida);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.ckbOrdenar);
            this.panel1.Controls.Add(this.txtTamanhoVetor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRaio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCentralidade);
            this.panel1.Controls.Add(this.cmbDescritor);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1313, 32);
            this.panel1.TabIndex = 5;
            // 
            // ckbReescalar
            // 
            this.ckbReescalar.AutoSize = true;
            this.ckbReescalar.Checked = true;
            this.ckbReescalar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbReescalar.Location = new System.Drawing.Point(342, 8);
            this.ckbReescalar.Name = "ckbReescalar";
            this.ckbReescalar.Size = new System.Drawing.Size(74, 17);
            this.ckbReescalar.TabIndex = 22;
            this.ckbReescalar.Text = "Reescalar";
            this.ckbReescalar.UseVisualStyleBackColor = true;
            // 
            // btnLimparMedidas
            // 
            this.btnLimparMedidas.Image = global::UI.Properties.Resources.delete;
            this.btnLimparMedidas.Location = new System.Drawing.Point(302, 4);
            this.btnLimparMedidas.Name = "btnLimparMedidas";
            this.btnLimparMedidas.Size = new System.Drawing.Size(34, 23);
            this.btnLimparMedidas.TabIndex = 21;
            this.btnLimparMedidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparMedidas.UseVisualStyleBackColor = true;
            this.btnLimparMedidas.Click += new System.EventHandler(this.btnLimparMedidas_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::UI.Properties.Resources.export;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(916, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(72, 23);
            this.btnExportar.TabIndex = 20;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnIncluirMedida
            // 
            this.btnIncluirMedida.Image = global::UI.Properties.Resources.add;
            this.btnIncluirMedida.Location = new System.Drawing.Point(262, 4);
            this.btnIncluirMedida.Name = "btnIncluirMedida";
            this.btnIncluirMedida.Size = new System.Drawing.Size(34, 23);
            this.btnIncluirMedida.TabIndex = 18;
            this.btnIncluirMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluirMedida.UseVisualStyleBackColor = true;
            this.btnIncluirMedida.Click += new System.EventHandler(this.btnIncluirMedida_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::UI.Properties.Resources.trash_empty;
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(994, 4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(98, 23);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "Limpar gráfico";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // ckbOrdenar
            // 
            this.ckbOrdenar.AutoSize = true;
            this.ckbOrdenar.Checked = true;
            this.ckbOrdenar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbOrdenar.Location = new System.Drawing.Point(417, 8);
            this.ckbOrdenar.Name = "ckbOrdenar";
            this.ckbOrdenar.Size = new System.Drawing.Size(64, 17);
            this.ckbOrdenar.TabIndex = 15;
            this.ckbOrdenar.Text = "Ordenar";
            this.ckbOrdenar.UseVisualStyleBackColor = true;
            // 
            // txtTamanhoVetor
            // 
            this.txtTamanhoVetor.Location = new System.Drawing.Point(744, 5);
            this.txtTamanhoVetor.Name = "txtTamanhoVetor";
            this.txtTamanhoVetor.Size = new System.Drawing.Size(37, 20);
            this.txtTamanhoVetor.TabIndex = 14;
            this.txtTamanhoVetor.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tamanho vetor:";
            // 
            // txtRaio
            // 
            this.txtRaio.Location = new System.Drawing.Point(619, 5);
            this.txtRaio.Name = "txtRaio";
            this.txtRaio.Size = new System.Drawing.Size(38, 20);
            this.txtRaio.TabIndex = 12;
            this.txtRaio.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Raio:";
            // 
            // cmbCentralidade
            // 
            this.cmbCentralidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentralidade.FormattingEnabled = true;
            this.cmbCentralidade.Items.AddRange(new object[] {
            "Grau",
            "Proximidade",
            "Intermediacao",
            "Evcent",
            "Densidade",
            "Radius",
            "Diametro",
            "TriangulosAdjacentes",
            "CentralidadeAlpha",
            "Assortatividade",
            "AssortatividadeGrau",
            "AssortatividadeNominal",
            "AuthorityScore",
            "CaminhoMinimoMedio",
            "Cliques",
            "IndiceCluster",
            "Ecentricidade",
            "NosMaisDistantes",
            "HubScore",
            "Transitividade"});
            this.cmbCentralidade.Location = new System.Drawing.Point(105, 5);
            this.cmbCentralidade.Name = "cmbCentralidade";
            this.cmbCentralidade.Size = new System.Drawing.Size(151, 21);
            this.cmbCentralidade.TabIndex = 10;
            // 
            // cmbDescritor
            // 
            this.cmbDescritor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescritor.FormattingEnabled = true;
            this.cmbDescritor.Location = new System.Drawing.Point(7, 5);
            this.cmbDescritor.Name = "cmbDescritor";
            this.cmbDescritor.Size = new System.Drawing.Size(93, 21);
            this.cmbDescritor.TabIndex = 5;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = global::UI.Properties.Resources.home;
            this.btnSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionar.Location = new System.Drawing.Point(787, 4);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(123, 23);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Text = "Selecionar imagem";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.InitialDirectory = "C:\\SIFT";
            // 
            // fbdAbrir
            // 
            this.fbdAbrir.SelectedPath = "C:\\SIFT";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chtResultado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1305, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gráficos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chtResultado
            // 
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.Title = "Threshold";
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.Title = "Centralidade";
            chartArea1.Name = "ChartArea1";
            this.chtResultado.ChartAreas.Add(chartArea1);
            this.chtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtResultado.Legends.Add(legend1);
            this.chtResultado.Location = new System.Drawing.Point(3, 3);
            this.chtResultado.Name = "chtResultado";
            this.chtResultado.Size = new System.Drawing.Size(1299, 293);
            this.chtResultado.TabIndex = 2;
            this.chtResultado.CustomizeLegend += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CustomizeLegendEventArgs>(this.chtResultado_CustomizeLegend);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1313, 325);
            this.tabControl1.TabIndex = 7;
            // 
            // ckbGerarImagens
            // 
            this.ckbGerarImagens.AutoSize = true;
            this.ckbGerarImagens.Location = new System.Drawing.Point(482, 8);
            this.ckbGerarImagens.Name = "ckbGerarImagens";
            this.ckbGerarImagens.Size = new System.Drawing.Size(94, 17);
            this.ckbGerarImagens.TabIndex = 16;
            this.ckbGerarImagens.Text = "Gerar imagens";
            this.ckbGerarImagens.UseVisualStyleBackColor = true;
            // 
            // frmAnaliseTextura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 357);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAnaliseTextura";
            this.Text = "Análise de textura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtResultado)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDescritor;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.ComboBox cmbCentralidade;
        private System.Windows.Forms.TextBox txtTamanhoVetor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRaio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbOrdenar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnIncluirMedida;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.FolderBrowserDialog fbdAbrir;
        private System.Windows.Forms.SaveFileDialog sfdSalvar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtResultado;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnLimparMedidas;
        private System.Windows.Forms.CheckBox ckbReescalar;
        private System.Windows.Forms.CheckBox ckbGerarImagens;
    }
}