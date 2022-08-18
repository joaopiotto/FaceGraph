using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{

    public partial class frmDeteccaoCascata : Form
    {

        #region Atributos da classe

        /// <summary>
        /// Caminho com os arquivos de treinamento
        /// </summary>
        String path = @"C:\opencv\sources\data\haarcascades\";

        /// <summary>
        /// Objeto de câmera
        /// </summary>
        Capture cap;

        /// <summary>
        /// Classificador de cascata
        /// </summary>
        CascadeClassifier haar;

        /// <summary>
        /// Comprimento mínimo 
        /// </summary>
        int widthMin = 0;

        /// <summary>
        /// Largura mínima
        /// </summary>
        int heightMin = 0;

        /// <summary>
        /// Comprimento máximo
        /// </summary>
        int widthMax = 0;

        /// <summary>
        /// Largura máxima
        /// </summary>
        int heightMax = 0;

        #endregion

        #region Eventos da classe

        /// <summary>
        /// Ação do botão Iniciar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            if (cap == null)
                cap = new Capture(0);

            if (tmrTempoReal.Enabled)
                tmrTempoReal.Stop();

            widthMin = int.Parse(txtTamanhoMin.Text.Split(',')[0]);
            heightMin = int.Parse(txtTamanhoMin.Text.Split(',')[1]);

            widthMax = int.Parse(txtTamanhoMax.Text.Split(',')[0]);
            heightMax = int.Parse(txtTamanhoMax.Text.Split(',')[1]);

            // adjust path to find your xml
            haar = new CascadeClassifier(path+cmbHaarCascade.SelectedItem.ToString());

            tmrTempoReal.Start();

        }

        /// <summary>
        /// Evento do timer para simular tempo real
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrTempoReal_Tick(object sender, EventArgs e)
        {
            using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
            {
                if (nextFrame != null)
                {

                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();

                    Rectangle[] a = haar.DetectMultiScale(grayframe, 1.4, 4, new Size(widthMin, heightMin), new Size(widthMax, heightMax));

                    foreach (var face in a)
                    {

                        nextFrame.Draw(face, new Bgr(0, double.MaxValue, 0), 3);

                        if (ckbUnico.Checked)
                            break;

                    }

                    imgResultado.Image = nextFrame.ToBitmap();

                }
            }
        }

        /// <summary>
        /// Ação do botão Parar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParar_Click(object sender, EventArgs e)
        {
            tmrTempoReal.Stop();
        }

        /// <summary>
        /// Ação do botão Processar imagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetectar_Click(object sender, EventArgs e)
        {

            if (ofdAbrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Image<Bgr, byte> imgCor = new Image<Bgr, byte>(ofdAbrir.FileName);
                Image<Gray, byte> imgCinza = imgCor.Convert<Gray, byte>();

                widthMin = int.Parse(txtTamanhoMin.Text.Split(',')[0]);
                heightMin = int.Parse(txtTamanhoMin.Text.Split(',')[1]);

                widthMax = int.Parse(txtTamanhoMax.Text.Split(',')[0]);
                heightMax = int.Parse(txtTamanhoMax.Text.Split(',')[1]);

                haar = new CascadeClassifier(path + cmbHaarCascade.SelectedItem.ToString());
                Rectangle[] a = haar.DetectMultiScale(imgCinza, 1.4, 4, new Size(widthMin, heightMin), new Size(widthMax, heightMax));

                foreach (Rectangle region in a)
                {
                    imgCor.Draw(region, new Bgr(0, double.MaxValue, 0), 3);
                }

                //Rectangle a = AnaliseGrafo.PontosPorRegiaoInteresse.AreaDaFace(imgCinza);
                //imgCor.Draw(a, new Bgr(0, double.MaxValue, 0), 3);

                

                imgResultado.Image = imgCor.Bitmap;

            }

        }

        /// <summary>
        /// Ação do botão Exportar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {

            String urlDiretorioOrigem;
            String urlDiretorioDestino;
            Image<Bgr, byte> imgCor;
            Image<Gray, byte> imgCinza;
            Rectangle area;

            if (fbdDiretorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                urlDiretorioOrigem = fbdDiretorio.SelectedPath;

                if (fbdDiretorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    urlDiretorioDestino = fbdDiretorio.SelectedPath;
                    
                    foreach (String arquivo in System.IO.Directory.GetFiles(urlDiretorioOrigem))
                    {

                        imgCor = new Image<Bgr, byte>(arquivo);
                        imgCinza = imgCor.Convert<Gray, byte>();

                        MCvAvgComp[][] facesDetected = imgCinza.DetectHaarCascade(
                        new HaarCascade(path + cmbHaarCascade.SelectedItem.ToString()),
                        1.2,
                        10,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20));

                        foreach (MCvAvgComp f in facesDetected[0])
                        {

                            area = f.rect;

                            area.Width += int.Parse(txtAjuste.Text.Split(',')[0]);
                            area.Height += int.Parse(txtAjuste.Text.Split(',')[1]);

                            SalvarRegiaoInteresse(imgCor, area, urlDiretorioDestino + "\\" + extrairNomeArquivo(arquivo));

                        }

                    }

                    MessageBox.Show("Procedimento realizado com sucesso.");

                }

            }

        }

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public frmDeteccaoCascata()
        {

            InitializeComponent();

            foreach (String item in System.IO.Directory.GetFiles(path))
            {
                cmbHaarCascade.Items.Add(extrairNomeArquivo(item));
            }

        }

        /// <summary>
        /// Método para extrair o nome do arquivo
        /// </summary>
        /// <param name="url">Url com o nome do arquivo</param>
        /// <returns>Nome do arquivo</returns>
        private String extrairNomeArquivo(String url)
        {

            int inicio = url.LastIndexOf('\\') + 1;
            return url.Substring(inicio);

        }

        /// <summary>
        /// Método que salva uma região de interesse da imagem passada no parâmetro
        /// </summary>
        /// <param name="imagem">Imagem com a região de interesse</param>
        /// <param name="regiaoInteresse">Localização de interesse</param>
        /// <param name="urlArquivo">Url do arquivo a ser salvo</param>
        private void SalvarRegiaoInteresse(Image<Bgr, byte> imagem, Rectangle regiaoInteresse, String urlArquivo)
        {

            Image<Bgr, byte> face = imagem.Copy(regiaoInteresse);
            face.Bitmap.Save(urlArquivo, System.Drawing.Imaging.ImageFormat.Tiff); 

        }

        #endregion

    }

}
