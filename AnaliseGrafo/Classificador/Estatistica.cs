using System;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Classe com métodos matemáticos e estatísticos
    /// </summary>
    public class Estatistica
    {

        #region Métodos de estatística básica

        /// <summary>
        /// Calcula a média dos dados passados no parâmetro
        /// </summary>
        /// <param name="dados">Dados</param>
        /// <returns>Media</returns>
        public static double CalcularMedia(List<double> dados)
        {

            double soma = 0;

            for (int i = 0; i < dados.Count; i++)
                soma += dados[i];

            return soma / dados.Count;

        }

        /// <summary>
        /// Calcula o desvio padrão dos dados passados no parâmetro
        /// </summary>
        /// <param name="dados">Dados</param>
        /// <returns>Desvio padrão</returns>
        public static double CalcularDesvioPadrao(List<double> dados)
        {

            double media = CalcularMedia(dados);
            double somatoria = 0;

            for (int i = 0; i < dados.Count; i++)
            {
                somatoria += Math.Pow(dados[i] - media, 2);
            }

            return Math.Sqrt(somatoria / (dados.Count - 1));

        }

        /// <summary>
        /// Calcula o desvio padrão dos dados passados no parâmetro
        /// </summary>
        /// <param name="dados">Dados</param>
        /// <param name="media">Média dos dados</param>
        /// <returns>Desvio padrão</returns>
        public static double CalcularDesvioPadrao(List<double> dados, double media)
        {

            double somatoria = 0;

            for (int i = 0; i < dados.Count; i++)
            {
                somatoria += Math.Pow(dados[i] - media, 2);
            }

            return Math.Sqrt(somatoria / (dados.Count - 1));

        }

        /// <summary>
        /// Método que calcula a distância euclidiana entre duas coordenadas xy no espaço cartesiano
        /// </summary>
        /// <param name="x1">Valor da coordenada x1</param>
        /// <param name="y1">Valor da coordenada y1</param>
        /// <param name="x2">Valor da coordenada x2</param>
        /// <param name="y2">Valor da coordenada y2</param>
        /// <returns>Distância euclidiana entre pontos</returns>
        public static double CalcularDistanciaEuclidiana(double x1, double y1, double x2, double y2)
        {

            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

        }

        /// <summary>
        /// Método que calcula a distância euclidiana entre dois vetores
        /// </summary>
        /// <param name="vetorA">Vetor A</param>
        /// <param name="vetorB">Vetor B</param>
        /// <returns>Distância euclidiana entre os vetores A e B</returns>
        public static double CalcularDistanciaEuclidiana(List<double> vetorA, List<double> vetorB)
        {

            double distanciaEuclidiana = 0;
            for (int i = 0; i < vetorA.Count; i++)
            {
                distanciaEuclidiana += Math.Pow((vetorA[i] - vetorB[i]), 2);
            }

            return Math.Sqrt(distanciaEuclidiana);

        }

        /// <summary>
        /// Método que calcula a similaridade de cosseno entre dois vetores
        /// </summary>
        /// <param name="vetorA">Vetor A</param>
        /// <param name="vetorB">Vetor B</param>
        /// <returns>Similaridade de cosseno entre os vetores A e B</returns>
        public static double CalcularSimilaridadeDeCosseno(List<double> vetorA, List<double> vetorB)
        {

            double dot = 0;
            double d1 = 0, d2 = 0;
            for (int i = 0; i < vetorA.Count; i++)
            {
                dot += vetorA[i] * vetorB[i];
                d1 += Math.Pow(vetorA[i], 2);
                d2 += Math.Pow(vetorB[i], 2);
            }

            return dot / (Math.Sqrt(d1) * Math.Sqrt(d2));

        }

        /// <summary>
        /// Método que calcula a correlação de pearson
        /// </summary>
        /// <param name="vetorA">Curva A</param>
        /// <param name="vetorB">Curva B</param>
        /// <returns>Similaridade de cosseno entre os vetores A e B</returns>
        public static double CalcularCorrelacaoPearson(List<double> curvaA, List<double> curvaB)
        {

            double mediaA = 0, mediaB = 0, numerador = 0, somaQuadA = 0, somaQuadB = 0;

            for (int i = 0; i < curvaA.Count; i++)
            {
                mediaA += curvaA[i];
                mediaB += curvaB[i];
            }

            mediaA = mediaA / curvaA.Count;
            mediaB = mediaB / curvaB.Count;

            for (int i = 0; i < curvaA.Count; i++)
            {
                numerador += (curvaA[i] - mediaA) * (curvaB[i] - mediaB);
                somaQuadA += Math.Pow(curvaA[i] - mediaA, 2);
                somaQuadB += Math.Pow(curvaB[i] - mediaB, 2);
            }

            return numerador / (Math.Sqrt(somaQuadA * somaQuadB));
            
        }

        #endregion

        #region Métodos matemáticos para normalização de dados

        /// <summary>
        /// Método que normaliza os dados passados no parâmetro
        /// </summary>
        /// <param name="dados">Lista de dados a ser normalizado</param>
        /// <returns>Dados normalizados</returns>
        public static List<double> NormalizarDados(List<double> dados)
        {

            double media = CalcularMedia(dados);
            double desvioPadrao = CalcularDesvioPadrao(dados, media);
            List<double> listaRetorno = new List<double>(dados.Count);

            for (int i = 0; i < dados.Count; i++)
                listaRetorno.Add((dados[i] - media) / desvioPadrao);

            return dados;

        }

        #endregion

    }
}
