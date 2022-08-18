using Classificadores;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AnaliseGrafo
{

    public class PontosPorRegiaoInteresse
    {

        #region Atributos da classe

        /// <summary>
        /// Caminho com os arquivos de treinamento
        /// </summary>
        static String path = @"C:\opencv\sources\data\haarcascades\";

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método estático que retorna os pontos chaves desenhados em uma imagem
        /// </summary>
        /// <param name="urlImagem">Url da imagem</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="raio">Raio da intersecção</param>
        /// <returns>Imagem desenhada</returns>
        public static RetornoDescritor DesenharPontosChave(String urlImagem, TipoDescritor tipo, double raio, bool aplicarFiltroMedia)
        {

            Image<Gray, Byte> imgGray = new Image<Gray, Byte>(urlImagem);
            Rectangle area = DetectarAreaDaFace(imgGray);

            List<CoordenadaGeral> listaPontos;

            if (aplicarFiltroMedia)
                listaPontos = Descritores.AplicarFiltroMedia(Descritores.ListarPontosPorCores(imgGray, tipo, raio));
            else
                listaPontos = Descritores.ListarPontosPorCores(imgGray, tipo, raio);

            int cont = 0;
            Image<Bgr, byte> imgCor = new Image<Bgr, byte>(urlImagem);
            imgCor.Draw(area, new Bgr(0, double.MaxValue, 0), 2);

            Bitmap imgBmp = imgCor.Bitmap;

            CoordenadaPontoChave ponto;
            foreach (CoordenadaGeral item in listaPontos)
            {

                if (area.Contains(item.Coordenada))
                {

                    ponto = new CoordenadaPontoChave(2, item.Coordenada.X, item.Coordenada.Y);

                    foreach (Point vizinho in ponto.VetorIndices)
                        imgBmp.SetPixel(vizinho.X, vizinho.Y, item.Cor);

                    cont++;

                }

            }

            return new RetornoDescritor()
            {
                ImagemDestacada = imgBmp,
                TotalPontos = cont
            };

        }

        /// <summary>
        /// Método que lista os pontos chaves dentro da região da face
        /// </summary>
        /// <param name="imgGray">Imagem da face</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="raio">Raio da intersecção</param>
        /// <returns></returns>
        public static List<Point> ListarPontos(Image<Gray, Byte> imgGray, TipoDescritor tipo, double raio)
        {

            Rectangle area = DetectarAreaDaFace(imgGray);

            List<Point> listaPontos = Descritores.ListarPontos(imgGray, tipo, raio);
            List<Point> listaRetorno = new List<Point>();

            foreach (Point item in listaPontos)
            {
                if (area.Contains(item))
                    listaRetorno.Add(item);
            }

            return listaRetorno;

        }

        /// <summary>
        /// Método que detecta características de uma imagem
        /// </summary>
        /// <param name="urlImagem">Url da imagem</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="aplicarFiltro">Aplicar filtro da média</param>
        /// <returns>Lista com as características da imagem</returns>
        public static List<Amostra> DetectarCaracteristicas(Image<Gray, Byte> imgGray, TipoDescritor tipo)
        {

            ImageFeature<float>[] listaPontoChaveFloat;

            Rectangle area = DetectarAreaDaFace(imgGray);

            if (tipo == TipoDescritor.SIFT)
                listaPontoChaveFloat = new SIFTDetector().DetectFeatures(imgGray, null);
            else if (tipo == TipoDescritor.SURF)
                listaPontoChaveFloat = new SURFDetector(500, false).DetectFeatures(imgGray, null);
            else
                throw new Exception("O método só suporta descritores do tipo SIFT ou SURF");

            List<Amostra> listaRetorno = new List<Amostra>();

            Amostra item;
            for (int i = 0; i < listaPontoChaveFloat.Length; i++)
            {

                if (area.Contains(new Point((int)listaPontoChaveFloat[i].KeyPoint.Point.X, (int)listaPontoChaveFloat[i].KeyPoint.Point.Y)))
                {

                    item = new Amostra();

                    for (int j = 0; j < listaPontoChaveFloat[i].Descriptor.Length; j++)
                    {
                        item.Caracteristicas.Add(listaPontoChaveFloat[i].Descriptor[j]);
                    }

                    listaRetorno.Add(item);

                }

            }

            return listaRetorno;

        }

        /// <summary>
        /// Método para remover olhos duplicados
        /// </summary>
        /// <param name="amostras">Amostras</param>
        /// <returns></returns>
        public static Rectangle[] RemoverAreasOlhosDupicadas(Rectangle[] amostras)
        {
            // procurando quem tem o menor x
            int menorX = int.MaxValue;
            foreach (Rectangle item in amostras) if (item.X < menorX) menorX = item.X;

            // procurando quem tem o maior x
            int maiorX = int.MinValue;
            foreach (Rectangle item in amostras) if (item.X > maiorX) maiorX = item.X;

            // Calculando o ponto médio
            double xCentral = (menorX + maiorX) / 2;
            
            // Determinado quem está do lado direito e quem está do lado esquerdo
            List<Rectangle> listaEsquerda = new List<Rectangle>();
            List<Rectangle> listaDireita = new List<Rectangle>();
            foreach (Rectangle item in amostras)
            {

                if (item.X < xCentral)
                    listaEsquerda.Add(item);
                else
                    listaDireita.Add(item);
            }

            Rectangle olhoEsquerdo = new Rectangle();
            olhoEsquerdo.Height = 1;
            olhoEsquerdo.Width = 1;

            Rectangle olhoDireito = new Rectangle();
            olhoDireito.Height = 1;
            olhoDireito.Width = 1;

            foreach (Rectangle item in listaEsquerda) if (item.Height > olhoEsquerdo.Height && item.Width > olhoEsquerdo.Width) olhoEsquerdo = item;
            foreach (Rectangle item in listaDireita) if (item.Height > olhoDireito.Height && item.Width > olhoDireito.Width) olhoDireito = item;

            return new Rectangle[] { olhoEsquerdo, olhoDireito };

        }
        
        /// <summary>
        /// Método que retorna a área da face composta por olhos e nariz
        /// </summary>
        /// <param name="imgGray">Imagem</param>
        /// <returns></returns>
        public static Rectangle DetectarAreaDaFace(Image<Gray, Byte> imgGray)
        {

            List<Rectangle> olhos = new CascadeClassifier(path + "haarcascade_eye.xml").DetectMultiScale(imgGray, 1.4, 4, new Size(20, 20), new Size(300, 300)).ToList<Rectangle>();
            List<Rectangle> nariz = new CascadeClassifier(path + "haarcascade_mcs_nose.xml").DetectMultiScale(imgGray, 1.4, 4, new Size(20, 20), new Size(100, 100)).ToList<Rectangle>();

            olhos.AddRange(nariz); 

            if (olhos.Count < 1)
                throw new Exception("Não foram encontrados olhos e nariz.");

            // procurando o ponto mais baixo em Y olhos
            int top = int.MaxValue;
            int left = int.MaxValue;
            int right = int.MinValue;
            int down = int.MinValue;

            foreach (Rectangle item in olhos)
            {

                if (item.Top < top)
                    top = item.Top;

                if (item.Left < left)
                    left = item.Left;

                if (item.Right > right)
                    right = item.Right;

                if (item.Bottom > down)
                    down = item.Bottom;

            }

            Rectangle retorno = new Rectangle();

            retorno.X = left;
            retorno.Y = top;
            retorno.Width = right - left;
            retorno.Height = down - top;

            return retorno;

        }

        #endregion

    }

}
