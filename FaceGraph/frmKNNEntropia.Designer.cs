namespace UI
{
    partial class frmKNNEntropia
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
            this.cmbClassificador = new System.Windows.Forms.ComboBox();
            this.btnTestar = new System.Windows.Forms.Button();
            this.btnTreinar = new System.Windows.Forms.Button();
            this.ckbFiltro = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolds = new System.Windows.Forms.TextBox();
            this.btnValidacaoCruzada = new System.Windows.Forms.Button();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.fbdAbrir = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.cmbClassificador);
            this.panel1.Controls.Add(this.btnTestar);
            this.panel1.Controls.Add(this.btnTreinar);
            this.panel1.Controls.Add(this.ckbFiltro);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFolds);
            this.panel1.Controls.Add(this.btnValidacaoCruzada);
            this.panel1.Controls.Add(this.cmbMetodo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 32);
            this.panel1.TabIndex = 7;
            // 
            // cmbClassificador
            // 
            this.cmbClassificador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassificador.FormattingEnabled = true;
            this.cmbClassificador.Items.AddRange(new object[] {
            "KNN",
            "Random Forest"});
            this.cmbClassificador.Location = new System.Drawing.Point(268, 5);
            this.cmbClassificador.Name = "cmbClassificador";
            this.cmbClassificador.Size = new System.Drawing.Size(123, 21);
            this.cmbClassificador.TabIndex = 12;
            // 
            // btnTestar
            // 
            this.btnTestar.Image = global::UI.Properties.Resources.binoculars;
            this.btnTestar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestar.Location = new System.Drawing.Point(477, 3);
            this.btnTestar.Name = "btnTestar";
            this.btnTestar.Size = new System.Drawing.Size(70, 23);
            this.btnTestar.TabIndex = 11;
            this.btnTestar.Text = "Testar";
            this.btnTestar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestar.UseVisualStyleBackColor = true;
            this.btnTestar.Click += new System.EventHandler(this.btnTestar_Click);
            // 
            // btnTreinar
            // 
            this.btnTreinar.Image = global::UI.Properties.Resources.burn;
            this.btnTreinar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreinar.Location = new System.Drawing.Point(401, 3);
            this.btnTreinar.Name = "btnTreinar";
            this.btnTreinar.Size = new System.Drawing.Size(70, 23);
            this.btnTreinar.TabIndex = 10;
            this.btnTreinar.Text = "Treinar";
            this.btnTreinar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTreinar.UseVisualStyleBackColor = true;
            this.btnTreinar.Click += new System.EventHandler(this.btnTreinar_Click);
            // 
            // ckbFiltro
            // 
            this.ckbFiltro.AutoSize = true;
            this.ckbFiltro.Location = new System.Drawing.Point(136, 7);
            this.ckbFiltro.Name = "ckbFiltro";
            this.ckbFiltro.Size = new System.Drawing.Size(126, 17);
            this.ckbFiltro.TabIndex = 9;
            this.ckbFiltro.Text = "Aplicar filtro da média";
            this.ckbFiltro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(685, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Folds:";
            // 
            // txtFolds
            // 
            this.txtFolds.Location = new System.Drawing.Point(723, 5);
            this.txtFolds.Name = "txtFolds";
            this.txtFolds.Size = new System.Drawing.Size(43, 20);
            this.txtFolds.TabIndex = 7;
            this.txtFolds.Text = "10";
            // 
            // btnValidacaoCruzada
            // 
            this.btnValidacaoCruzada.Image = global::UI.Properties.Resources.home;
            this.btnValidacaoCruzada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidacaoCruzada.Location = new System.Drawing.Point(554, 3);
            this.btnValidacaoCruzada.Name = "btnValidacaoCruzada";
            this.btnValidacaoCruzada.Size = new System.Drawing.Size(125, 23);
            this.btnValidacaoCruzada.TabIndex = 6;
            this.btnValidacaoCruzada.Text = "Validação Cruzada";
            this.btnValidacaoCruzada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidacaoCruzada.UseVisualStyleBackColor = true;
            this.btnValidacaoCruzada.Click += new System.EventHandler(this.btnValidacaoCruzada_Click);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Location = new System.Drawing.Point(7, 5);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(123, 21);
            this.cmbMetodo.TabIndex = 5;
            // 
            // fbdAbrir
            // 
            this.fbdAbrir.SelectedPath = "C:\\SIFT\\";
            // 
            // frmKNNEntropia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 320);
            this.Controls.Add(this.panel1);
            this.Name = "frmKNNEntropia";
            this.Text = "Classificação com maximização de entropia";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolds;
        private System.Windows.Forms.Button btnValidacaoCruzada;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.FolderBrowserDialog fbdAbrir;
        private System.Windows.Forms.CheckBox ckbFiltro;
        private System.Windows.Forms.Button btnTreinar;
        private System.Windows.Forms.Button btnTestar;
        private System.Windows.Forms.ComboBox cmbClassificador;
    }
}