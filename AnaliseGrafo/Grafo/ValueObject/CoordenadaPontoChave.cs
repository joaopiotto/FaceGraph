
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
namespace AnaliseGrafo
{
    public class CoordenadaPontoChave
    {

        private int tamVetor;

        public Point[] VetorIndices { get; set; }

        public CoordenadaPontoChave(int raioVizinhanca, int x, int y)
        {


            if (raioVizinhanca == 0)
            {

                tamVetor = 5;
                VetorIndices = new Point[tamVetor];
                
                VetorIndices[0] = new Point(x, y - 1);
                VetorIndices[1] = new Point(x - 1, y);
                VetorIndices[2] = new Point(x, y);
                VetorIndices[3] = new Point(x + 1, y);
                VetorIndices[4] = new Point(x, y + 1);

            }
            else
            {

                tamVetor = (int)Math.Pow(((2 * raioVizinhanca) + 1), 2);
                VetorIndices = new Point[tamVetor];
                
                int cont = 0;

                for (int i = -raioVizinhanca; i <= raioVizinhanca; i++)
                {

                    for (int j = -raioVizinhanca; j <= raioVizinhanca; j++)
                    {
                        VetorIndices[cont] = new Point((x + j), (y + i));
                        cont++;
                    }

                }

            }

        }

    }
}
