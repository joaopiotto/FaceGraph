using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Util;
using ValueObject;

namespace BLL
{

    /// <summary>
    /// Classe para detectar faces
    /// </summary>
    public class ClassificadorFaceBLL
    {

        #region Atributos da classe

        /// <summary>
        /// Variável "k" do k-NN
        /// </summary>
        public int k { get; set; }

        /// <summary>
        /// Quantidade mínima aceitavel para ser considerado ponto chave
        /// </summary>
        public int qtdeMinima { get; set; }

        /// <summary>
        /// Processador de imagem
        /// </summary>
        private ProcessadorImagem processadorImagem;

        /// <summary>
        /// Pontos chaves cadastrados
        /// </summary>
        private List<PontosChaveVO> listaPontoChaveBanco;

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="k">Variável "k" do k-NN</param>
        /// <param name="qtdeMinima">Quantidade mínima aceitavel para ser considerado ponto chave</param>
        public ClassificadorFaceBLL(int k, int qtdeMinima)
        {
            this.k = k;
            this.qtdeMinima = qtdeMinima;
            processadorImagem = new ProcessadorImagem();
            listaPontoChaveBanco = new PontosChaveBLL().Listar(new PontosChaveVO());
        }

        /// <summary>
        /// Método que retorna uma lista de probabilidades da imagem candidata (a ser reconhecida) pertencer
        /// a cada face cadastrada na base de dados
        /// </summary>
        /// <param name="faceCandidata">Imagem da face candidata a ser reconhecida</param>
        /// <param name="tipoDistancia">Tipo da distância utilizada no cálculo</param>
        /// <returns>Pessoa conhecida da base de dados</returns>
        public PessoasVO Reconhecer(String urlImagemCandidata, List<TipoCalculo> listaCalculo, TipoDescritor tipoDescritor, TipoMedida tipoDistancia, int raioVizinhanca, int tamanhoVetor, bool normalizar)
        {

            List<PointF> lista = new List<PointF>();
            List<PointF> listaIntermediaria;

            foreach (TipoCalculo item in listaCalculo)
            {
                listaIntermediaria = processadorImagem.AnalisarCaracteristicasTextura(urlImagemCandidata, item, tipoDescritor, raioVizinhanca, tamanhoVetor, false);
                foreach (PointF valor in listaIntermediaria)
                    lista.Add(valor);
            }

            PontosChaveVO pontoCandidato = new PontosChaveVO();
            foreach (PointF item in lista)
                pontoCandidato.vetorDeCaracteristicas.Add((double)item.Y);

            if (normalizar)
                NormalizarDados(pontoCandidato, listaPontoChaveBanco);

            // Classificador
            kNN knn = new kNN(k, tipoDistancia);
            List<DistanciaPonto> vizinhosMaisProximos = knn.CalcularVinhosMaisProximos(pontoCandidato, listaPontoChaveBanco);

            var pessoasDistintas = vizinhosMaisProximos.GroupBy(l => l.pontosChaveVO.pessoaVO.codPessoa)
                          .Select(lg =>
                                new
                                {
                                    CodigoPessoa = lg.Key,
                                    Total = lg.Count()
                                }).OrderByDescending(o => o.Total);

            if (pessoasDistintas.First().Total >= qtdeMinima)
                return new PessoasVO() { codPessoa = pessoasDistintas.First().CodigoPessoa };
            else
                throw new consisteException(listaMensagens.Consist005);

            /*if (pessoasDistintas.Count() < 2)
                return new PessoasVO() { codPessoa = pessoasDistintas.First().CodigoPessoa };

            List<PessoasVO> resultado = new List<PessoasVO>();

            // Faz o cálculo de maximização de entropia
            int controlador = 0, soma1 = 0, soma2 = 0;
            double maxEntropia = 0;
            for (int i = 0; i < pessoasDistintas.Count() - 1; i++)
            {

                soma1 = 0;
                soma2 = 0;
                controlador++;

                for (int j = 0; j < pessoasDistintas.Count(); j++)
                {
                    if (j < controlador)
                        soma1 += pessoasDistintas.ElementAt(j).Total;
                    else
                        soma2 += pessoasDistintas.ElementAt(j).Total;
                }

                maxEntropia = -((soma1 * (Math.Log(soma1))) + (soma2 * (Math.Log(soma2))));

                resultado.Add(new PessoasVO()
                {
                    codPessoa = pessoasDistintas.ElementAt(i).CodigoPessoa,
                    entropiaPessoa = maxEntropia
                });

            }

            // o primero valor do bi deve ser maior do que os demais (histograma ordenado)
            for (int i = 1; i < resultado.Count; i++)
            {
                if (resultado[i].entropiaPessoa >= resultado[0].entropiaPessoa)
                    throw new consisteException(listaMensagens.Consist005);
            }

            return resultado[0];*/

        }

        private void NormalizarDados(PontosChaveVO pontoClassificar, List<PontosChaveVO> conjuntoBase)
        {

            double[] media = new double[pontoClassificar.vetorDeCaracteristicas.Count];
            double[] desvio = new double[pontoClassificar.vetorDeCaracteristicas.Count];

            //exportar(pontoClassificar, conjuntoBase);

            for (int i = 0; i < media.Length; i++)
            {

                for (int j = 0; j < conjuntoBase.Count; j++)
                {
                    media[i] += conjuntoBase[j].vetorDeCaracteristicas[i];
                }

                media[i] += pontoClassificar.vetorDeCaracteristicas[i];

                media[i] = media[i] / (conjuntoBase.Count + 1);

            }

            for (int i = 0; i < desvio.Length; i++)
            {
                
                for (int j = 0; j < conjuntoBase.Count; j++)
                {
                    desvio[i] += Math.Pow((conjuntoBase[j].vetorDeCaracteristicas[i] - media[i]), 2);
                }

                desvio[i] += Math.Pow((pontoClassificar.vetorDeCaracteristicas[i] - media[i]), 2);

                desvio[i] = Math.Sqrt(desvio[i] / conjuntoBase.Count);

            }

            for (int i = 0; i < desvio.Length; i++)
            {

                for (int j = 0; j < conjuntoBase.Count; j++)
                {
                    conjuntoBase[j].vetorDeCaracteristicas[i] = (conjuntoBase[j].vetorDeCaracteristicas[i] - media[i]) / desvio[i];
                }

                pontoClassificar.vetorDeCaracteristicas[i] = (pontoClassificar.vetorDeCaracteristicas[i] - media[i]) / desvio[i];

            }

        }

        private void exportar(PontosChaveVO pontoClassificar, List<PontosChaveVO> conjuntoBase)
        {

            System.Text.StringBuilder strSaida = new System.Text.StringBuilder();

            for (int i = 0; i < pontoClassificar.vetorDeCaracteristicas.Count; i++)
            {
                strSaida.Append(pontoClassificar.vetorDeCaracteristicas[i] + ";");
            }

            strSaida.AppendLine();

            foreach (PontosChaveVO item in conjuntoBase)
            {
                for (int i = 0; i < item.vetorDeCaracteristicas.Count; i++)
                {
                    strSaida.Append(item.vetorDeCaracteristicas[i] + ";");
                }

                strSaida.AppendLine();

            }

            System.IO.StreamWriter gravador = new System.IO.StreamWriter(@"C:\SIFT\dados.csv");

            gravador.Write(strSaida.ToString());

            gravador.Close();

        }

        #endregion

    }

}
