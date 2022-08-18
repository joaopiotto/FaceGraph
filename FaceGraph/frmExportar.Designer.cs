namespace UI
{
    partial class frmExportar
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbCabec = new System.Windows.Forms.CheckBox();
            this.ckbClasse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(198, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(279, 112);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbFormato
            // 
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Items.AddRange(new object[] {
            "Formato Brasileiro",
            "Formato Americano"});
            this.cmbFormato.Location = new System.Drawing.Point(15, 25);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(171, 21);
            this.cmbFormato.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Formato:";
            // 
            // ckbCabec
            // 
            this.ckbCabec.AutoSize = true;
            this.ckbCabec.Location = new System.Drawing.Point(15, 55);
            this.ckbCabec.Name = "ckbCabec";
            this.ckbCabec.Size = new System.Drawing.Size(198, 17);
            this.ckbCabec.TabIndex = 8;
            this.ckbCabec.Text = "Incluir cabeçalho (A1; A2.. CLASSE)";
            this.ckbCabec.UseVisualStyleBackColor = true;
            // 
            // ckbClasse
            // 
            this.ckbClasse.AutoSize = true;
            this.ckbClasse.Location = new System.Drawing.Point(15, 81);
            this.ckbClasse.Name = "ckbClasse";
            this.ckbClasse.Size = new System.Drawing.Size(143, 17);
            this.ckbClasse.TabIndex = 9;
            this.ckbClasse.Text = "Classe nominal (P1; P2..)";
            this.ckbClasse.UseVisualStyleBackColor = true;
            // 
            // frmExportar
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 142);
            this.Controls.Add(this.ckbClasse);
            this.Controls.Add(this.ckbCabec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFormato);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar dados excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbFormato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbCabec;
        private System.Windows.Forms.CheckBox ckbClasse;
    }
}