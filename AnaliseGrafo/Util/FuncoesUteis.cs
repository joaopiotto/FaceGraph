using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace AnaliseGrafo
{

    public class FuncoesUteis
    {

        /// <summary>
        /// Método para extrair o nome do arquivo
        /// </summary>
        /// <param name="url">Url com o nome do arquivo</param>
        /// <returns>Nome do arquivo</returns>
        public static double ExtrairClasseNomeArquivo(String url)
        {

            int inicio = url.LastIndexOf('\\') + 1;
            int tam = url.LastIndexOf('-') - inicio;

            return double.Parse(url.Substring(inicio, tam));

        }

        /// <summary>
        /// Método que realiza o processo de alargamento de contraste (histogram strechting)
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public static Image<Gray, Byte> AplicarAlargamentoContraste(Image<Gray, Byte> imagem)
        {

            Image<Gray, Byte> imgRetorno = new Image<Gray, byte>(imagem.Width, imagem.Height);

            // Vetor do histograma e probabilidade
	        double[] H = new double[256];
            double[] HAlargado = new double[256];

            double acumulado = 0, totalPixels = imagem.Width * imagem.Height;

            // Calculando a distribuíção de níveis de cinza para cada pixel da imagem
            for (int i = 0; i < imagem.Height; i++)
                for (int j = 0; j < imagem.Width; j++)
                    H[(int)imagem[i, j].Intensity]++;

            // Alargando o histograma
            for (int i = 0; i < 256; i++)
            {
                HAlargado[i] = (H[i] / totalPixels) + acumulado;
                acumulado = HAlargado[i];
                HAlargado[i] = Math.Round(HAlargado[i] * 255);
            }

            for (int i = 0; i < imagem.Height; i++)
                for (int j = 0; j < imagem.Width; j++)
                    imgRetorno.Data[i, j, 0] = (byte)HAlargado[(int)imagem[i, j].Intensity];

            return imgRetorno;

        }

    }
}
