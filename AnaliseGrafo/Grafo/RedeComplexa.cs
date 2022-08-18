using Classificadores;
using Emgu.CV;
using Emgu.CV.Structure;
using RDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AnaliseGrafo
{

    public class RedeComplexa
    {

        #region Atributos da classe

        REngine engine;

        public MatrizDefinicao matriz { get; set; }

        public List<Amostra> listaCoordenada { get; set; }

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public RedeComplexa()
        {

            // Criando a comunicação com o R
            REngine.SetEnvironmentVariables();
            engine = REngine.GetInstance();

            // Adicionando a biblioteca igraph na sessão
            engine.Evaluate("library(igraph)");

        }

        public List<double> CalcularVetorCaracteristicasDaRede(String file, List<Amostra> listaCoordenada, List<TipoCalculo> ListaCentralidade, int tamanhoVetor, bool OrdenarVetor, bool reescalarMedidas, bool gerarImagens)
        {

            if (reescalarMedidas)
                OrdenarVetor = true;

            List<double> VetorCaracteristica = new List<double>();
            this.listaCoordenada = listaCoordenada;

            CalcularMatrizDistancia();

            double decremento = (double)1 / tamanhoVetor;
            int contInteracao = 0;
            double threshold = (1 - decremento);

            #region Calculo das medidas

            while (threshold >= 0)
            {

                contInteracao++;

                foreach (TipoCalculo item in ListaCentralidade)
                {

                    switch (item)
                    {
                        case TipoCalculo.CentralidadeDeGrau:
                            VetorCaracteristica.Add(CalcularCentralidadeGrau());
                            break;
                        case TipoCalculo.CentralidadeDeProximidade:
                            VetorCaracteristica.Add(CalcularCentralidadeProximidade());
                            break;
                        case TipoCalculo.CentralidadeDeIntermediacao:
                            VetorCaracteristica.Add(CalcularCentralidadeIntermediacao());
                            break;
                        case TipoCalculo.CentralidadeEvcent:
                            VetorCaracteristica.Add(CalcularCentralidadeEvcent());
                            break;
                        case TipoCalculo.Densidade:
                            VetorCaracteristica.Add(CalcularDensidade());
                            break;
                        case TipoCalculo.Radius:
                            VetorCaracteristica.Add(CalcularRadius());
                            break;
                        case TipoCalculo.Diametro:
                            VetorCaracteristica.Add(CalcularDiametro());
                            break;
                        case TipoCalculo.TriangulosAdjacentes:
                            VetorCaracteristica.Add(CalcularTriangulosAdjacentes());
                            break;
                        case TipoCalculo.CentralidadeAlpha:
                            VetorCaracteristica.Add(CalcularCentralidadeAlpha());
                            break;
                        case TipoCalculo.Assortatividade:
                            VetorCaracteristica.Add(CalcularAssortatividade());
                            break;
                        case TipoCalculo.AssortatividadeGrau:
                            VetorCaracteristica.Add(CalcularAssortatividadeGrau());
                            break;
                        case TipoCalculo.AssortatividadeNominal:
                            VetorCaracteristica.Add(CalcularAssortatividadeNominal());
                            break;
                        case TipoCalculo.AuthorityScore:
                            VetorCaracteristica.Add(CalcularAuthorityScore());
                            break;
                        case TipoCalculo.CaminhoMinimoMedio:
                            VetorCaracteristica.Add(CalcularCaminhoMinimoMedio());
                            break;
                        case TipoCalculo.Cliques:
                            VetorCaracteristica.Add(CalcularCliques());
                            break;
                        case TipoCalculo.IndiceCluster:
                            VetorCaracteristica.Add(CalcularIndiceCluster());
                            break;
                        case TipoCalculo.Ecentricidade:
                            VetorCaracteristica.Add(CalcularEcentricidade());
                            break;
                        case TipoCalculo.NosMaisDistantes:
                            VetorCaracteristica.Add(CalcularNosMaisDistantes());
                            break;
                        case TipoCalculo.HubScore:
                            VetorCaracteristica.Add(CalcularHubScore());
                            break;
                        case TipoCalculo.Transitividade:
                            VetorCaracteristica.Add(CalcularTransitividade());
                            break;
                    }

                }

                if (gerarImagens)
                    DesenharGrafoImagem(new Image<Bgr, Byte>(file)).Save(@"C:\SIFT\Saida\" + String.Format("{0:000}", contInteracao) + ".png", System.Drawing.Imaging.ImageFormat.Png);

                AplicarThreshold(threshold);

                threshold = (double)Math.Round((decimal)(threshold - decremento), 2);

            }

            #endregion

            #region Ordenação

            if (OrdenarVetor)
            {

                List<double> VetorOrdenado = new List<double>(VetorCaracteristica.Count);

                for (int i = 0; i < ListaCentralidade.Count; i++)
                {

                    for (int j = i; j < VetorCaracteristica.Count; j += ListaCentralidade.Count)
                    {
                        VetorOrdenado.Add(VetorCaracteristica[j]);
                    }

                }

                VetorCaracteristica = VetorOrdenado;

            }

            #endregion

            #region Reescalar medidas

            if (reescalarMedidas)
            {

                List<double>[] matrizMedidas = new List<double>[ListaCentralidade.Count];

                for (int i = 0; i < matrizMedidas.Length; i++)
                {

                    matrizMedidas[i] = new List<double>();

                    for (int j = (i * tamanhoVetor); j < (i * tamanhoVetor) + tamanhoVetor; j++)
                    {
                        matrizMedidas[i].Add(VetorCaracteristica[j]);
                    }

                }

                VetorCaracteristica.Clear();

                for (int i = 0; i <  matrizMedidas.Length; i++)
                    VetorCaracteristica.AddRange(Util.TransformarDados(matrizMedidas[i], TipoTranformacao.TransformacaoDeEscala));
                
            }

            #endregion

            return VetorCaracteristica;

        }

        #region Métodos de manipulação do grafo

        private void AplicarThreshold(double threshold)
        {

            for (int i = 0; i < matriz.matrizDistancia.Length; i++)
            {
                for (int j = 0; j < matriz.matrizDistancia.Length; j++)
                {
                    if (matriz.matrizDistancia[i][j] > threshold)
                        matriz.matrizDistancia[i][j] = 0;
                }
            }

        }

        private void CalcularMatrizDistancia()
        {

            matriz = new MatrizDefinicao();
            matriz.matrizDistancia = new double[listaCoordenada.Count][];
            double[] distancia;

            double maxDist = double.MinValue;
            double minDist = double.MaxValue;
            for (int i = 0; i < listaCoordenada.Count; i++)
            {

                distancia = new double[listaCoordenada.Count];

                for (int j = 0; j < listaCoordenada.Count; j++)
                {
                    
                    distancia[j] = Classificadores.Util.CalcularDistanciaEuclidiana(listaCoordenada[i].Caracteristicas,
                        listaCoordenada[j].Caracteristicas);

                    // desconsiderar a diagonal principal
                    if (i != j)
                    {

                        if (distancia[j] > maxDist)
                            maxDist = distancia[j];

                        if (distancia[j] < minDist)
                            minDist = distancia[j];

                    }

                }

                matriz.matrizDistancia[i] = distancia;

            }

            // Re-escalando a matriz de distância
            for (int i = 0; i < listaCoordenada.Count; i++)
                for (int j = 0; j < listaCoordenada.Count; j++)
                    if (i != j) // desconsiderar a diagonal principal
                        if (maxDist - minDist != 0)
                            matriz.matrizDistancia[i][j] = (matriz.matrizDistancia[i][j] - minDist) / (maxDist - minDist);
                        else
                            matriz.matrizDistancia[i][j] = 0;
                
        }

        private Bitmap DesenharGrafoImagem(Image<Bgr, Byte> imagem)
        {

            for (int i = 0; i < matriz.matrizDistancia.Count(); i++)
            {
                for (int j = 0; j < i; j++)
                {

                    if (matriz.matrizDistancia[i][j] > 0)
                        imagem = GrafoUtil.DesenharRetaCoordenadas(
                            imagem,
                            new Point((int)listaCoordenada[i].Classe, (int)listaCoordenada[i].EntropiaAmostra),
                            new Point((int)listaCoordenada[j].Classe, (int)listaCoordenada[j].EntropiaAmostra)
                        );                    
                }

            }

            Bitmap map = imagem.ToBitmap();

            for (int i = 0; i < listaCoordenada.Count; i++)
            {
                CoordenadaPontoChave ponto = new CoordenadaPontoChave(2, (int)listaCoordenada[i].Classe, (int)listaCoordenada[i].EntropiaAmostra);

                for (int k = 0; k < ponto.VetorIndices.Length; k++)
                {
                    map.SetPixel(
                        ponto.VetorIndices[k].X,
                        ponto.VetorIndices[k].Y,
                        Color.Blue
                        );
                }
            }

            return map;

        } 

        #endregion

        #region Métodos para cálculo de estimativas de grafos

        private double CalcularCentralidadeGrau()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("centralization.degree(g1, loops = FALSE)$centralization").AsNumeric().First();

        }

        private double CalcularCentralidadeProximidade()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("centralization.closeness(g1)$centralization").AsNumeric().First();

        }

        private double CalcularCentralidadeIntermediacao()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("centralization.betweenness(g1)$centralization").AsNumeric().First();

        }

        private double CalcularCentralidadeEvcent()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("centralization.evcent(g1)$centralization").AsNumeric().First();

        }

        private double CalcularDensidade()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("graph.density(g1, loops=FALSE)").AsNumeric().First();

        }

        private double CalcularRadius()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("radius(g1)").AsNumeric().First();

        }

        private double CalcularDiametro()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("diameter(g1, directed = FALSE)").AsNumeric().First();

        }

        private double CalcularTriangulosAdjacentes()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("adjacent.triangles(g1)").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularCentralidadeAlpha()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("alpha.centrality(g1)").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularAssortatividade()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");
            engine.Evaluate("types <- rep(c(\"odd\", \"even\"), length.out=vcount(g1))");

            return (double)engine.Evaluate("assortativity(g1, factor(types))").AsNumeric().First();

        }

        private double CalcularAssortatividadeGrau()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("assortativity.degree(g1)").AsNumeric().First();

        }

        private double CalcularAssortatividadeNominal()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");
            engine.Evaluate("types <- rep(c(\"odd\", \"even\"), length.out=vcount(g1))");

            return (double)engine.Evaluate("assortativity.nominal(g1, factor(types))").AsNumeric().First();

        }

        private double CalcularAuthorityScore()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("authority.score(g1)$vector").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularCaminhoMinimoMedio()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("average.path.length(g1)").AsNumeric().First();

        }

        private double CalcularCliques()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("clique.number(g1)").AsNumeric().First();

        }

        private double CalcularIndiceCluster()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("clusters(g1)$no").AsNumeric().First();

        }

        private double CalcularEcentricidade()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("eccentricity(g1)").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularNosMaisDistantes()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("farthest.nodes (g1, directed = FALSE, unconnected = TRUE)").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularHubScore()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            // Recebendo a lista de retorno
            GenericVector lista = engine.Evaluate("hub.score(g1, scale = FALSE)$vector").AsList();

            double soma = 0;
            for (int i = 0; i < lista.Count(); i++)
                soma += (double)lista.AsNumeric()[i];

            return soma / listaCoordenada.Count;

        }

        private double CalcularTransitividade()
        {

            // Criando a matriz no na sessão do R
            NumericMatrix Rmatriz = engine.CreateNumericMatrix(matriz.matrizAdjacenciaFormatoR);
            engine.SetSymbol("matrizAdjacente", Rmatriz);

            // Criando o grafo
            engine.Evaluate("g1 <- graph.adjacency( matrizAdjacente, mode=\"undirected\")");

            return (double)engine.Evaluate("transitivity(g1)").AsNumeric().First();

        }

        #endregion

        #endregion

    }

}
