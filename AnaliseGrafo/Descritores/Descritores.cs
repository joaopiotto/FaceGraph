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

    #region Classe principal

    public class Descritores
    {

        #region Atributos da classe

        /// <summary>
        /// Constante de ponderação
        /// </summary>
        private static double constPonderacao = 1.4;

        /// <summary>
        /// Variável para armazenar a classe ao listar os descritores SIFT ou SURF de uma imagem - Método: DetectarCaracteristicas()
        /// </summary>
        private static double classeDescritor = 0;

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método estático que retorna os pontos chaves desenhados em uma imagem
        /// </summary>
        /// <param name="urlImagem">Url da imagem</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <returns>Imagem desenhada</returns>
        public static RetornoDescritor DesenharPontosChave(String urlImagem, TipoDescritor tipo, double raio, bool aplicarFiltroMedia)
        {

            Image<Gray, Byte> imgGray = new Image<Gray, Byte>(urlImagem);

            List<CoordenadaGeral> listaPontos;

            if (aplicarFiltroMedia)
                listaPontos = AplicarFiltroMedia(ListarPontosPorCores(imgGray, tipo, raio));
            else
                listaPontos = ListarPontosPorCores(imgGray, tipo, raio);

            Bitmap img = (Bitmap)Bitmap.FromFile(urlImagem);

            CoordenadaPontoChave ponto;
            foreach (CoordenadaGeral item in listaPontos)
            {

                if (item.Coordenada.X > 1 && (item.Coordenada.X < img.Size.Width - 2) && item.Coordenada.Y > 1 && (item.Coordenada.Y < img.Size.Height - 2))
                {

                    ponto = new CoordenadaPontoChave(2, item.Coordenada.X, item.Coordenada.Y);

                    foreach (Point vizinho in ponto.VetorIndices)
                        img.SetPixel(vizinho.X, vizinho.Y, item.Cor);

                }

            }

            return new RetornoDescritor()
            {
                ImagemDestacada = img,
                TotalPontos = listaPontos.Count
            };

        }

        /// <summary>
        /// Calcula as coordenadas dos descritores passada no parâmetro
        /// </summary>
        /// <param name="imgGray">Imagem processada</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="raio">Indica o raio de intersecção </param>
        /// <returns></returns>
        public static List<Point> ListarPontos(Image<Gray, Byte> imgGray, TipoDescritor tipo, double raio)
        {

            if (tipo == TipoDescritor.SIFT)
            {

                return ListarPontosInteresse(new SIFTDetector().DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.SURF)
            {

                return ListarPontosInteresse(new SURFDetector(500, false).DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.SIFT_UNIAO_SURF)
            {

                #region SIFT união com SURF

                List<Point> listaA = ListarPontosInteresse(new SIFTDetector().DetectKeyPoints(imgGray, null));
                List<Point> listaB = ListarPontosInteresse(new SURFDetector(500, false).DetectKeyPoints(imgGray, null));

                foreach (Point item in listaB)
                {
                    if (!VerificarExistenciaCoordenada(listaA, item.X, item.Y))
                    {
                        listaA.Add(item);
                    }
                }

                return listaA;

                #endregion

            }
            else if (tipo == TipoDescritor.SIFT_INSERCCAO_SURF)
            {

                #region SIFT Intersecao SURF

                return CalcularIntersecaoListas(
                    ListarPontosInteresse(new SIFTDetector().DetectKeyPoints(imgGray, null)),
                    ListarPontosInteresse(new SURFDetector(500, false).DetectKeyPoints(imgGray, null)),
                    raio);

                #endregion

            }
            else if (tipo == TipoDescritor.GOOD_FEATURES_TO_TRACK)
            {

                #region Good Features to Track

                PointF[][] a = imgGray.GoodFeaturesToTrack(300, 0.01d, 10, 5);

                List<Point> lista = new List<Point>();

                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a[i].Length; j++)
                    {

                        if (!VerificarExistenciaCoordenada(lista, (int)a[i][j].X, (int)a[i][j].Y))
                        {
                            lista.Add(new Point((int)a[i][j].X, (int)a[i][j].Y));
                        }

                    }
                }

                return lista;

                #endregion

            }
            else if (tipo == TipoDescritor.FAST)
            {

                return ListarPontosInteresse(new FastDetector(10, true).DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.MSER)
            {

                return ListarPontosInteresse(new MSERDetector().DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.ORB)
            {

                return ListarPontosInteresse(new ORBDetector(500).DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.BRISK)
            {

                return ListarPontosInteresse(new Brisk(30, 3, 1f).DetectKeyPoints(imgGray, null));

            }
            else if (tipo == TipoDescritor.FREAK)
            {

                #region Freak

                MKeyPoint[] pontosChave = new FastDetector(10, true).DetectKeyPoints(imgGray, null);
                ImageFeature<byte>[] features = new Freak(true, true, 22f, 4).ComputeDescriptors(imgGray, null, pontosChave);

                List<Point> lista = new List<Point>();

                for (int i = 0; i < features.Length; i++)
                {

                    if (!VerificarExistenciaCoordenada(lista, (int)features[i].KeyPoint.Point.X, (int)features[i].KeyPoint.Point.Y))
                    {
                        lista.Add(new Point((int)features[i].KeyPoint.Point.X, (int)features[i].KeyPoint.Point.Y));
                    }

                }

                return lista;

                #endregion

            }
            else if (tipo == TipoDescritor.ORB_INTERSECAO_SURF)
            {

                #region ORB Intersecao SURF

                return CalcularIntersecaoListas(
                    ListarPontosInteresse(new ORBDetector(500).DetectKeyPoints(imgGray, null)),
                    ListarPontosInteresse(new SURFDetector(500, false).DetectKeyPoints(imgGray, null)),
                    raio);

                #endregion

            }
            else if (tipo == TipoDescritor.Varios)
            {

                #region Varios

                List<Point> listaA = ListarPontosInteresse(new SIFTDetector().DetectKeyPoints(imgGray, null));
                List<Point> listaB = ListarPontosInteresse(new SURFDetector(500, false).DetectKeyPoints(imgGray, null));
                List<Point> listaC = CalcularIntersecaoListas(listaA, listaB, raio);

                listaA.Clear();
                listaA = ListarPontosInteresse(new MSERDetector().DetectKeyPoints(imgGray, null));

                listaB.Clear();
                listaB = CalcularIntersecaoListas(listaC, listaA, raio);

                listaA.Clear();
                listaA = ListarPontosInteresse(new ORBDetector(500).DetectKeyPoints(imgGray, null));

                listaC.Clear();
                listaC = CalcularIntersecaoListas(listaA, listaB, raio);

                return listaC;
                
                #endregion

            }

            return null;

        }

        /// <summary>
        /// Calcula as coordenadas dos descritores passada no parâmetro
        /// </summary>
        /// <param name="imgGray">Imagem processada</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="raio">Indica o raio de intersecção </param>
        /// <returns></returns>
        public static List<CoordenadaGeral> ListarPontosPorCores(Image<Gray, Byte> imgGray, TipoDescritor tipo, double raio)
        {

            List<CoordenadaGeral> listaRetorno = new List<CoordenadaGeral>();

            if (tipo == TipoDescritor.SIFT_UNIAO_SURF)
            {

                #region SIRF união SURF

                foreach (Point item in ListarPontos(imgGray, TipoDescritor.SIFT, raio))
                {
                    listaRetorno.Add(new CoordenadaGeral()
                    {
                        Coordenada = item,
                        Cor = Color.Red,
                        Descritor = TipoDescritor.SIFT
                    });
                }

                foreach (Point item in ListarPontos(imgGray, TipoDescritor.SURF, raio))
                {
                    listaRetorno.Add(new CoordenadaGeral()
                    {
                        Coordenada = item,
                        Cor = Color.Blue,
                        Descritor = TipoDescritor.SURF
                    });
                }

                #endregion

            }
            else
            {

                foreach (Point item in ListarPontos(imgGray, tipo, raio))
                {
                    listaRetorno.Add(new CoordenadaGeral()
                    {
                        Coordenada = item,
                        Cor = Color.Red,
                        Descritor = TipoDescritor.SIFT
                    });
                }

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
        public static List<Amostra> DetectarCaracteristicas(String arguivoImagem, TipoDescritor tipo, bool aplicarFiltro)
        {
            classeDescritor = FuncoesUteis.ExtrairClasseNomeArquivo(arguivoImagem);
            return DetectarCaracteristicas(new Image<Gray, Byte>(arguivoImagem), tipo, aplicarFiltro);
        }

        /// <summary>
        /// Método que detecta características de uma imagem
        /// </summary>
        /// <param name="urlImagem">Url da imagem</param>
        /// <param name="tipo">Tipo de descritor</param>
        /// <param name="aplicarFiltro">Aplicar filtro da média</param>
        /// <returns>Lista com as características da imagem</returns>
        public static List<Amostra> DetectarCaracteristicas(Image<Gray, Byte> imgGray, TipoDescritor tipo, bool aplicarFiltro)
        {

            ImageFeature<float>[] listaPontoChaveFloat = null;
            ImageFeature<byte>[] listaPontoChaveByte;
            double[] distancia = null;
            double x = 0, y = 0;
            double distanciaMedia = 0;
            List<Amostra> listaRetorno = new List<Amostra>();
            Amostra item;

            if (tipo == TipoDescritor.SIFT || tipo == TipoDescritor.SURF)
            {

                #region SIFT ou SURF

                if (tipo == TipoDescritor.SIFT)
                    listaPontoChaveFloat = new SIFTDetector().DetectFeatures(imgGray, null);
                else if (tipo == TipoDescritor.SURF)
                    listaPontoChaveFloat = new SURFDetector(500, false).DetectFeatures(imgGray, null);

                #region Filtro média

                if (aplicarFiltro)
                {

                    for (int i = 0; i < listaPontoChaveFloat.Length; i++)
                    {
                        x += listaPontoChaveFloat[i].KeyPoint.Point.X;
                        y += listaPontoChaveFloat[i].KeyPoint.Point.Y;
                    }

                    x = x / listaPontoChaveFloat.Length;
                    y = y / listaPontoChaveFloat.Length;

                    distancia = new double[listaPontoChaveFloat.Length];

                    for (int i = 0; i < distancia.Length; i++)
                    {
                        distancia[i] = Util.CalcularDistanciaEuclidiana(x, y,
                            listaPontoChaveFloat[i].KeyPoint.Point.X,
                            listaPontoChaveFloat[i].KeyPoint.Point.Y);
                    }

                    distanciaMedia = distancia.Average() * constPonderacao;

                }

                #endregion

                for (int i = 0; i < listaPontoChaveFloat.Length; i++)
                {

                    if ((aplicarFiltro) && (distancia[i] > distanciaMedia))
                        continue;

                    item = new Amostra();

                    for (int j = 0; j < listaPontoChaveFloat[i].Descriptor.Length; j++)
                    {
                        item.Caracteristicas.Add(listaPontoChaveFloat[i].Descriptor[j]);
                    }

                    item.Classe = classeDescritor;

                    listaRetorno.Add(item);

                }

                return listaRetorno;

                #endregion

            }
            else
            {

                #region Demais descritores

                listaPontoChaveByte = new ORBDetector(500).DetectFeatures(imgGray, null);

                #region Filtro média

                if (aplicarFiltro)
                {

                    for (int i = 0; i < listaPontoChaveByte.Length; i++)
                    {
                        x += listaPontoChaveByte[i].KeyPoint.Point.X;
                        y += listaPontoChaveByte[i].KeyPoint.Point.Y;
                    }

                    x = x / listaPontoChaveByte.Length;
                    y = y / listaPontoChaveByte.Length;

                    distancia = new double[listaPontoChaveByte.Length];

                    for (int i = 0; i < distancia.Length; i++)
                    {
                        distancia[i] = Util.CalcularDistanciaEuclidiana(x, y,
                            listaPontoChaveByte[i].KeyPoint.Point.X,
                            listaPontoChaveByte[i].KeyPoint.Point.Y);
                    }

                    distanciaMedia = distancia.Average() * constPonderacao;

                }

                #endregion

                for (int i = 0; i < listaPontoChaveByte.Length; i++)
                {

                    if ((aplicarFiltro) && (distancia[i] > distanciaMedia))
                        continue;

                    item = new Amostra();

                    for (int j = 0; j < listaPontoChaveByte[i].Descriptor.Length; j++)
                    {
                        item.Caracteristicas.Add(listaPontoChaveByte[i].Descriptor[j]);
                    }

                    item.Classe = classeDescritor;

                    listaRetorno.Add(item);

                }

                return listaRetorno;

                #endregion

            }

        }

        #region Métodos de filtros e localização de pontos chave

        /// <summary>
        /// Aplica o filtro da média ponderada
        /// </summary>
        /// <param name="listaPontoChaveFloat">Lista de pontos chave</param>
        /// <returns></returns>
        public static List<Point> AplicarFiltroMedia(List<Point> lista)
        {

            double centX = 0, centY = 0;

            // calculando centróide
            for (int i = 0; i < lista.Count; i++)
            {
                centX += lista[i].X;
                centY += lista[i].Y;
            }

            centX = centX / lista.Count;
            centY = centY / lista.Count;

            // calculando a distância entre o centróide e cada ponto
            double[] distancia = new double[lista.Count];
            for (int i = 0; i < distancia.Length; i++)
                distancia[i] = Util.CalcularDistanciaEuclidiana(centX, centY, lista[i].X, lista[i].Y);

            double distanciaMedia = distancia.Average() * constPonderacao;

            List<Point> listaPontos = new List<Point>();

            for (int i = 0; i < distancia.Length; i++)
            {

                if (distancia[i] <= distanciaMedia)
                    if (!VerificarExistenciaCoordenada(listaPontos, lista[i].X, lista[i].Y))
                        listaPontos.Add(lista[i]);

            }

            //listaPontos.Add(new Point((int)centX, (int)centY));

            return listaPontos;

        }

        /// <summary>
        /// Aplica o filtro da média ponderada
        /// </summary>
        /// <param name="listaPontoChaveFloat">Lista de pontos chave</param>
        /// <param name="Cor">Cor para identificar os pontos</param>
        /// <param name="tipo">Tipo para identificar o descritor</param>
        /// <returns></returns>
        public static List<CoordenadaGeral> AplicarFiltroMedia(List<CoordenadaGeral> lista)
        {

            double centX = 0, centY = 0;

            // calculando centróide
            for (int i = 0; i < lista.Count; i++)
            {
                centX += lista[i].Coordenada.X;
                centY += lista[i].Coordenada.Y;
            }

            centX = centX / lista.Count;
            centY = centY / lista.Count;

            // calculando a distância entre o centróide e cada ponto
            double[] distancia = new double[lista.Count];
            for (int i = 0; i < distancia.Length; i++)
                distancia[i] = Util.CalcularDistanciaEuclidiana(centX, centY, lista[i].Coordenada.X, lista[i].Coordenada.Y);

            double distanciaMedia = distancia.Average() * constPonderacao;

            List<CoordenadaGeral> listaPontos = new List<CoordenadaGeral>();
            
            for (int i = 0; i < distancia.Length; i++)
            {

                if (distancia[i] <= distanciaMedia)
                    if (!VerificarExistenciaCoordenada(listaPontos, lista[i].Coordenada.X, lista[i].Coordenada.Y))
                        listaPontos.Add(lista[i]);

            }

            CoordenadaGeral cg = new CoordenadaGeral();
            cg.Coordenada = new Point((int)centX, (int)centY);
            cg.Cor = Color.Green;

            listaPontos.Add(cg);

            return listaPontos;

        }

        /// <summary>
        /// Lista as coordenadas dos pontos chave de interesse
        /// </summary>
        /// <param name="pontosChave">Lista de pontos chave</param>
        /// <returns></returns>
        public static List<Point> ListarPontosInteresse(MKeyPoint[] pontosChave)
        {

            List<Point> listaPontos = new List<Point>();

            for (int i = 0; i < pontosChave.Length; i++)
            {

                if (!VerificarExistenciaCoordenada(listaPontos, (int)pontosChave[i].Point.X, (int)pontosChave[i].Point.Y))
                    listaPontos.Add(new Point((int)pontosChave[i].Point.X, (int)pontosChave[i].Point.Y));

            }

            return listaPontos;

        }
        
        /// <summary>
        /// Verifica se as coordendas já existem na lista
        /// </summary>
        /// <param name="lista">lista de coordenadas</param>
        /// <param name="x">Valor de x da coordenada a ser inserida</param>
        /// <param name="y">Valor de y da coordenada a ser inserida</param>
        /// <returns></returns>
        private static bool VerificarExistenciaCoordenada(List<Point> lista, int x, int y)
        {

            foreach (Point item in lista)
            {

                if (item.X == x && item.Y == y)
                    return true;

            }

            return false;

        }

        /// <summary>
        /// Verifica se as coordendas já existem na lista
        /// </summary>
        /// <param name="lista">lista de coordenadas</param>
        /// <param name="x">Valor de x da coordenada a ser inserida</param>
        /// <param name="y">Valor de y da coordenada a ser inserida</param>
        /// <returns></returns>
        private static bool VerificarExistenciaCoordenada(List<CoordenadaGeral> lista, int x, int y)
        {

            foreach (CoordenadaGeral item in lista)
            {

                if (item.Coordenada.X == x && item.Coordenada.Y == y)
                    return true;

            }

            return false;

        }

        /// <summary>
        /// Calcula os pontos de intersecao em duas listas
        /// </summary>
        /// <param name="listaA">Lista A</param>
        /// <param name="listaB">Lista B</param>
        /// <param name="raio">Raio a ser utilizado</param>
        /// <returns>Pontos comuns entre as duas listas</returns>
        public static List<Point> CalcularIntersecaoListas(List<Point> listaA, List<Point> listaB, double raio)
        {

            double[][] matrizSimilaridade = new double[listaA.Count][];
            double[] distancia;
            List<Point> listaRetorno = new List<Point>();

            #region Calculo da matriz de similaridade

            for (int i = 0; i < listaA.Count; i++)
            {

                distancia = new double[listaB.Count];

                for (int j = 0; j < listaB.Count; j++)
                {

                    distancia[j] = Classificadores.Util.CalcularDistanciaEuclidiana(
                        listaA[i].X,
                        listaA[i].Y,
                        listaB[j].X,
                        listaB[j].Y);

                }

                matrizSimilaridade[i] = distancia;

            }

            #endregion

            #region Encontrando pontos semelhantes

            bool achou = false;
            for (int i = 0; i < matrizSimilaridade.Length; i++)
            {

                achou = false;

                for (int j = 0; j < matrizSimilaridade[i].Length; j++)
                {

                    if (matrizSimilaridade[i][j] <= raio)
                    {

                        if (!VerificarExistenciaCoordenada(listaRetorno, listaB[j].X, listaB[j].Y))
                        {
                            listaRetorno.Add(listaB[j]);
                            achou = true;
                        }

                    }

                }

                if (achou && !VerificarExistenciaCoordenada(listaRetorno, listaA[i].X, listaA[i].Y))
                    listaRetorno.Add(listaA[i]);

            }

            #endregion

            return listaRetorno;

        }

        #endregion

        #endregion

    }

    #endregion

    #region Classe auxiliar

    public class RetornoDescritor
    {
        public Image ImagemDestacada { get; set; }
        public int TotalPontos { get; set; }
    }

    public class CoordenadaGeral
    {
        public TipoDescritor Descritor { get; set; }
        public Point Coordenada { get; set; }
        public Color Cor { get; set; }
    }

    #endregion

}
