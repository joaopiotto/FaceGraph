using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace AnaliseGrafo
{
    public class GrafoUtil
    {

        public static Bitmap DesenharRetaCoordenadas(Image imagem, Point coordenada1, Point coordenada2)
        {
            return DesenharRetaCoordenadas(new Image<Bgr, Byte>((Bitmap)imagem), coordenada1, coordenada2).Bitmap;
        }

        public static Image<Bgr, Byte> DesenharRetaCoordenadas(Image<Bgr, Byte> imagem, Point coordenada1, Point coordenada2)
        {

            Point[] pontos = new Point[2];

            pontos[0] = coordenada1;
            pontos[1] = coordenada2;

            imagem.DrawPolyline(pontos, true, new Bgr(0, 0, 255), 1);

            return imagem;

        }

    }
}
