using Classificadores;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AnaliseGrafo
{
    public class ProcessadorImagem
    {

        #region Atributos da classe

        private RedeComplexa redeComplexa;

        #endregion

        #region Método da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public ProcessadorImagem()
        {
            redeComplexa = new RedeComplexa();
        }

        /// <summary>
        /// Método que calcula o descritor da face
        /// </summary>
        /// <returns></returns>
        public Amostra CalcularDescritorDaFace(String urlImagem, List<TipoCalculo> ListaCentralidade, TipoDescritor tipoDescritor, int raioVizinhanca, int tamanhoVetor, bool OrdenarVetor, bool reescalarMedidas, bool gerarImagens)
        {

            Image<Gray, Byte> imagemTonsCinza = new Image<Gray, Byte>(urlImagem);

            //List<Amostra> listaProcessar = ListarRegiaoCentralIntensidade(imagemTonsCinza, raioVizinhanca, tipoDescritor);
            //List<Amostra> listaProcessar = ListarRegiaoCentralCoordenadaCartesiana(imagemTonsCinza, tipoDescritor);
            //List<Amostra> listaProcessar = PontosPorRegiaoInteresse.DetectarCaracteristicas(imagemTonsCinza, tipoDescritor);
            List<Amostra> listaProcessar = ListarPontosIntensidadeFiltroDoCentroide(imagemTonsCinza, tipoDescritor, raioVizinhanca);

            Amostra amostra = new Amostra();

            amostra.Caracteristicas = redeComplexa.CalcularVetorCaracteristicasDaRede(urlImagem, listaProcessar, ListaCentralidade, tamanhoVetor, OrdenarVetor, reescalarMedidas, gerarImagens);
            amostra.Classe = FuncoesUteis.ExtrairClasseNomeArquivo(urlImagem);

            return amostra;

        }

        #region Métodos de tratamento identificadores dos nós

        /// <summary>
        /// Lista os pontos representados pela intensidade dos pixels vizinhos
        /// </summary>
        /// <param name="listaPontoChaveFloat">Pontos chave do descritor</param>
        /// <param name="raioVizinhanca">Raio da vizinhança</param>
        /// <returns></returns>
        private List<Amostra> ListarPontosIntensidade(Image<Gray, Byte> imagemTonsCinza, TipoDescritor tipo, int raioVizinhanca)
        {

            List<Point> listaPontos = Descritores.ListarPontos(imagemTonsCinza, tipo, 5.7);
            return ListarPontosChaveRepresentadosPorIntensidadeDosVizinhos(raioVizinhanca, listaPontos, imagemTonsCinza);

        }

        /// <summary>
        /// Lista os pontos representados pela intensidade dos pixels vizinhos utilizando o filtro do centróide
        /// </summary>
        /// <param name="listaPontoChaveFloat">Pontos chave do descritor</param>
        /// <param name="raioVizinhanca">Raio da vizinhança</param>
        /// <returns></returns>
        private List<Amostra> ListarPontosIntensidadeFiltroDoCentroide(Image<Gray, Byte> imagemTonsCinza, TipoDescritor tipo, int raioVizinhanca)
        {

            List<Point> listaPontos = Descritores.ListarPontos(imagemTonsCinza, tipo, 1.5);
            List<Point> listaFiltrada = Descritores.AplicarFiltroMedia(listaPontos);
            return ListarPontosChaveRepresentadosPorIntensidadeDosVizinhos(raioVizinhanca, listaFiltrada, imagemTonsCinza);

        }

        /// <summary>
        /// Lista os pontos da regiao central da face representados pela intensidade dos pixels vizinhos
        /// </summary>
        /// <param name="raioVizinhanca">Raio da vizinhança</param>
        /// <param name="tipo">Tipo de descritor utilizado</param>
        /// <returns></returns>
        private List<Amostra> ListarRegiaoCentralIntensidade(Image<Gray, Byte> imagemTonsCinza, int raioVizinhanca, TipoDescritor tipo)
        {

            List<Point> listaPontos = PontosPorRegiaoInteresse.ListarPontos(imagemTonsCinza, tipo, 0);
            return ListarPontosChaveRepresentadosPorIntensidadeDosVizinhos(raioVizinhanca, listaPontos, imagemTonsCinza);

        }

        /// <summary>
        /// Lista os pontos da regiao central da face representados por sua coordenada cartesiana
        /// </summary>
        /// <param name="raioVizinhanca">Raio da vizinhança</param>
        /// <param name="tipo">Tipo de descritor utilizado</param>
        /// <returns></returns>
        private List<Amostra> ListarRegiaoCentralCoordenadaCartesiana(Image<Gray, Byte> imagemTonsCinza, TipoDescritor tipo)
        {

            List<Point> listaPontos = PontosPorRegiaoInteresse.ListarPontos(imagemTonsCinza, tipo, 0);
            return ListarPontosChaveRepresentadosPorSuaCoordenadaCartesiana(listaPontos);

        }

        #endregion

        #region Métodos comuns

        /// <summary>
        /// Método que lista os pontos chaves representados pela intensidade dos pixels vizinhos
        /// </summary>
        /// <param name="raioVizinhanca">Raio da vizinhança analisada</param>
        /// <param name="listaPonto">Lista dos pontos encontrados pelo descrito</param>
        /// <param name="imagem">Imagem da face para recuperação das intensidades</param>
        /// <returns>Lista de amostras</returns>
        private List<Amostra> ListarPontosChaveRepresentadosPorIntensidadeDosVizinhos(int raioVizinhanca, List<Point> listaPonto, Image<Gray, Byte> imagem)
        {

            List<Amostra> listaAmostra = new List<Amostra>();
            Amostra amostra;

            foreach (Point item in listaPonto)
            {

                amostra = new Amostra();

                for (int i = -raioVizinhanca; i <= raioVizinhanca; i++)
                    for (int j = -raioVizinhanca; j <= raioVizinhanca; j++)
                        amostra.Caracteristicas.Add(imagem[new Point((item.X + j), (item.Y + i))].Intensity);

                amostra.Classe = item.X;
                amostra.EntropiaAmostra = item.Y;

                listaAmostra.Add(amostra);

            }

            return listaAmostra;

        }

        /// <summary>
        /// Método que lista os pontos chaves representados por sua coordenada cartesiana
        /// </summary>
        /// <param name="listaPonto"></param>
        /// <returns></returns>
        private List<Amostra> ListarPontosChaveRepresentadosPorSuaCoordenadaCartesiana(List<Point> listaPonto)
        {

            List<Amostra> retorno = new List<Amostra>(listaPonto.Count);

            Amostra amostra;
            foreach (Point item in listaPonto)
            {
                amostra = new Amostra();
                amostra.Caracteristicas.Add(item.X);
                amostra.Caracteristicas.Add(item.Y);
                retorno.Add(amostra);
            }

            return retorno;

        }

        #endregion

        #endregion

    }
}
