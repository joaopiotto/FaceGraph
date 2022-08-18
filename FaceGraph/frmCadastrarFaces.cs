using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCadastrarFaces : Form
    {

        #region Atributos da classe

        /// <summary>
        /// Objeto de câmera
        /// </summary>
        Capture cap;

        /// <summary>
        /// Retangulo para parâmetro de face
        /// </summary>
        Rectangle faceParametro;

        /// <summary>
        /// Frame de imagem
        /// </summary>
        Image<Bgr, byte> frame;

        /// <summary>
        /// Url com a pasta a ser salva sequencia de imagens
        /// </summary>
        String urlPasta = String.Empty;

        #endregion

        #region Eventos da classe

        /// <summary>
        /// Evento do timer para simular tempo real
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCamera_Tick(object sender, EventArgs e)
        {
            frame = cap.QueryFrame();
            frame.Draw(faceParametro, new Bgr(0, double.MaxValue, 0), 3);
            imgCamera.Image = frame.ToBitmap();
        }

        /// <summary>
        /// Evento de fechar a janela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCadastrarFaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrCamera.Stop();
            cap.Dispose();
        }

        /// <summary>
        /// Ação do botão Gravar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGravar_Click(object sender, EventArgs e)
        {

            tmrCamera.Stop();

            int inicioAmostra = int.Parse(txtInicioAmostra.Text);

            for (int i = 0; i < int.Parse(txtTotalFaces.Text); i++)
            {
                cap.QueryFrame().ToBitmap().Save(urlPasta + txtIdFace.Text + "-" + String.Format("{0:000}", inicioAmostra) + ".jpg", System.Drawing.Imaging.ImageFormat.Tiff);
                inicioAmostra++;
            }

            tmrCamera.Start();

            MessageBox.Show("Procedimento executado com sucesso.");

        }

        /// <summary>
        /// Ação do botão Selecionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelecionar_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                urlPasta = fbdAbrir.SelectedPath + "\\";

        }

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public frmCadastrarFaces()
        {
            InitializeComponent();
            faceParametro = new Rectangle(180, 30, 300, 350);
            cap = new Capture(0);
            tmrCamera.Start();
        }

        #endregion

    }
}
