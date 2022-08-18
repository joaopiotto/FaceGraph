
namespace AnaliseGrafo
{

    public class MatrizDefinicao
    {

        public double[][] matrizDistancia { get; set; }

        public double[][] matrizAdjacencia
        {
            get
            {
                
                double[][] mt = new double[matrizDistancia.Length][];

                for (int i = 0; i < mt.Length; i++)
			    {

                    mt[i] = new double[matrizDistancia.Length];

			        for (int j = 0; j < mt.Length; j++)
			            mt[i][j] = matrizDistancia[i][j] > 0 ? 1 : 0;
			        
			    }

                return mt;

            }
        }

        public double[,] matrizAdjacenciaFormatoR
        {
            get
            {

                double[,] mt = new double[matrizDistancia.Length, matrizDistancia.Length];

                for (int i = 0; i < matrizDistancia.Length; i++)
                {

                    for (int j = 0; j < matrizDistancia.Length; j++)
                        mt[i, j] = matrizDistancia[i][j] > 0 ? 1 : 0;

                }

                return mt;

            }
        }

    }

}
