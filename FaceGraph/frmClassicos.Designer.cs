namespace UI
{
    partial class frmClassicos
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolds = new System.Windows.Forms.TextBox();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.fbdAbrir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnTestar = new System.Windows.Forms.Button();
            this.btnTreinar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnTestar);
            this.panel1.Controls.Add(this.btnTreinar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtParametro);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFolds);
            this.panel1.Controls.Add(this.btnProcessar);
            this.panel1.Controls.Add(this.cmbMetodo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 32);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Parametro:";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(605, 5);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(43, 20);
            this.txtParametro.TabIndex = 9;
            this.txtParametro.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Folds:";
            // 
            // txtFolds
            // 
            this.txtFolds.Location = new System.Drawing.Point(497, 5);
            this.txtFolds.Name = "txtFolds";
            this.txtFolds.Size = new System.Drawing.Size(43, 20);
            this.txtFolds.TabIndex = 7;
            this.txtFolds.Text = "10";
            // 
            // btnProcessar
            // 
            this.btnProcessar.Image = global::UI.Properties.Resources.home;
            this.btnProcessar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessar.Location = new System.Drawing.Point(344, 4);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(112, 23);
            this.btnProcessar.TabIndex = 6;
            this.btnProcessar.Text = "Selecionar pasta";
            this.btnProcessar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Items.AddRange(new object[] {
            "EigenFace",
            "FisherFace",
            "LBPHFace"});
            this.cmbMetodo.Location = new System.Drawing.Point(7, 5);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(179, 21);
            this.cmbMetodo.TabIndex = 5;
            // 
            // fbdAbrir
            // 
            this.fbdAbrir.SelectedPath = "C:\\SIFT\\FEI database";
            // 
            // btnTestar
            // 
            this.btnTestar.Image = global::UI.Properties.Resources.binoculars;
            this.btnTestar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestar.Location = new System.Drawing.Point(265, 4);
            this.btnTestar.Name = "btnTestar";
            this.btnTestar.Size = new System.Drawing.Size(70, 23);
            this.btnTestar.TabIndex = 13;
            this.btnTestar.Text = "Testar";
            this.btnTestar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestar.UseVisualStyleBackColor = true;
            this.btnTestar.Click += new System.EventHandler(this.btnTestar_Click);
            // 
            // btnTreinar
            // 
            this.btnTreinar.Image = global::UI.Properties.Resources.burn;
            this.btnTreinar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTreinar.Location = new System.Drawing.Point(189, 4);
            this.btnTreinar.Name = "btnTreinar";
            this.btnTreinar.Size = new System.Drawing.Size(70, 23);
            this.btnTreinar.TabIndex = 12;
            this.btnTreinar.Text = "Treinar";
            this.btnTreinar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTreinar.UseVisualStyleBackColor = true;
            this.btnTreinar.Click += new System.EventHandler(this.btnTreinar_Click);
            // 
            // frmClassicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 282);
            this.Controls.Add(this.panel1);
            this.Name = "frmClassicos";
            this.Text = "Reconhecimento de faces clássicos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.FolderBrowserDialog fbdAbrir;
        private System.Windows.Forms.TextBox txtFolds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Button btnTestar;
        private System.Windows.Forms.Button btnTreinar;
    }
}