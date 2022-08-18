using System.Collections.Generic;
using System.Linq;
using ValueObject;

namespace BLL
{

    /// <summary>
    /// Classe que representa o classificador k-NN
    /// </summary>
    public class kNN
    {

        #region Propriedades da classe

        /// <summary>
        /// Variável "k" do k-NN
        /// </summary>
        public int k { get; set; }

        /// <summary>
        /// Tipo de medida utilizada 
        /// </summary>
        public TipoMedida tipoMedida { get; set; }

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="k">Valor da variável "k"</param>
        /// <param name="tipoDistancia">Valor da variável "Tipo de distância utilizada"</param>
        public kNN(int k, TipoMedida tipoMedida)
        {
            this.k = k;
            this.tipoMedida = tipoMedida;
        }

        /// <summary>
        /// Método que calcula os "k" vizinhos mais próximos
        /// </summary>
        /// <param name="pontoClassificar">Ponto a ser classificado</param>
        /// <param name="conjuntoBase">Conjunto de dados já conhecidos</param>
        /// <returns>Retorna os "k" vizinhos mais próximos do ponto a ser classificado</returns>
        public List<DistanciaPonto> CalcularVinhosMaisProximos(PontosChaveVO pontoClassificar, List<PontosChaveVO> conjuntoBase)
        {

            List<DistanciaPonto> listaDistancias = new List<DistanciaPonto>(conjuntoBase.Count);

            DistanciaPonto distanciaPonto;
            foreach (PontosChaveVO ponto in conjuntoBase)
            {

                distanciaPonto = new DistanciaPonto();

                if (tipoMedida == TipoMedida.DistanciaEucliana)
                    distanciaPonto.distancia = Estatistica.CalcularDistanciaEuclidiana(
                        pontoClassificar.vetorDeCaracteristicas,
                        ponto.vetorDeCaracteristicas);
                else if (tipoMedida == TipoMedida.CorrelacaoPearson)
                    distanciaPonto.distancia = Estatistica.CalcularCorrelacaoPearson(
                        pontoClassificar.vetorDeCaracteristicas,
                        ponto.vetorDeCaracteristicas);
                else
                    distanciaPonto.distancia = Estatistica.CalcularSimilaridadeDeCosseno(
                        pontoClassificar.vetorDeCaracteristicas,
                        ponto.vetorDeCaracteristicas);

                distanciaPonto.pontosChaveVO = ponto;

                listaDistancias.Add(distanciaPonto);

            }

            if (tipoMedida == TipoMedida.DistanciaEucliana)
                listaDistancias = listaDistancias.OrderBy(o => o.distancia).ToList();
            else
                listaDistancias = listaDistancias.OrderByDescending(o => o.distancia).ToList();

            // Montando a lista com os "k" elementos mais próximos
            List<DistanciaPonto> listaRetorno = new List<DistanciaPonto>(k);
            for (int i = 0; i < k; i++)
                listaRetorno.Add(listaDistancias[i]);

            return listaRetorno;

        }

        #endregion

    }

}
