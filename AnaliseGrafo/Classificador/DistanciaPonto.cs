using ValueObject;

namespace BLL
{

    /// <summary>
    /// Classe para auxiliar cálulo de pontos vizinhos
    /// </summary>
    public class DistanciaPonto
    {

        #region Propriedades da classe

        /// <summary>
        /// Distância entre o ponto a ser classificado e um ponto do conjunto já conhecido
        /// </summary>
        public double distancia { get; set; }

        /// <summary>
        /// Ponto chave conhecido
        /// </summary>
        public PontosChaveVO pontosChaveVO { get; set; }

        #endregion

    }

}
