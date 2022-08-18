namespace UI
{
    partial class frmCadastrarFaces
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalFaces = new System.Windows.Forms.TextBox();
            this.txtIdFace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicioAmostra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.imgCamera = new System.Windows.Forms.PictureBox();
            this.tmrCamera = new System.Windows.Forms.Timer(this.components);
            this.fbdAbrir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelecionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total de faces:";
            // 
            // txtTotalFaces
            // 
            this.txtTotalFaces.Location = new System.Drawing.Point(15, 25);
            this.txtTotalFaces.Name = "txtTotalFaces";
            this.txtTotalFaces.Size = new System.Drawing.Size(75, 20);
            this.txtTotalFaces.TabIndex = 1;
            this.txtTotalFaces.Text = "150";
            // 
            // txtIdFace
            // 
            this.txtIdFace.Location = new System.Drawing.Point(99, 25);
            this.txtIdFace.Name = "txtIdFace";
            this.txtIdFace.Size = new System.Drawing.Size(68, 20);
            this.txtIdFace.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id da pessoa:";
            // 
            // txtInicioAmostra
            // 
            this.txtInicioAmostra.Location = new System.Drawing.Point(176, 25);
            this.txtInicioAmostra.Name = "txtInicioAmostra";
            this.txtInicioAmostra.Size = new System.Drawing.Size(107, 20);
            this.txtInicioAmostra.TabIndex = 5;
            this.txtInicioAmostra.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amostra iniciando em:";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(401, 22);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // imgCamera
            // 
            this.imgCamera.Location = new System.Drawing.Point(15, 51);
            this.imgCamera.Name = "imgCamera";
            this.imgCamera.Size = new System.Drawing.Size(676, 417);
            this.imgCamera.TabIndex = 7;
            this.imgCamera.TabStop = false;
            // 
            // tmrCamera
            // 
            this.tmrCamera.Interval = 10;
            this.tmrCamera.Tick += new System.EventHandler(this.tmrCamera_Tick);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(289, 22);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(106, 23);
            this.btnSelecionar.TabIndex = 8;
            this.btnSelecionar.Text = "Selecionar pasta";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // frmCadastrarFaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 480);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.imgCamera);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtInicioAmostra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdFace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalFaces);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCadastrarFaces";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Faces";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadastrarFaces_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalFaces;
        private System.Windows.Forms.TextBox txtIdFace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInicioAmostra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.PictureBox imgCamera;
        private System.Windows.Forms.Timer tmrCamera;
        private System.Windows.Forms.FolderBrowserDialog fbdAbrir;
        private System.Windows.Forms.Button btnSelecionar;
    }
}