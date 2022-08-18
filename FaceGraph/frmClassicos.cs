using AnaliseGrafo;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class frmClassicos : Form
    {

        FaceRecognizer recognizer;

        public frmClassicos()
        {
            InitializeComponent();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            List<Image<Gray, byte>> ListaImgTotal = new List<Image<Gray, byte>>();
            List<int> ListaClasseTotal = new List<int>();

            foreach (String item in System.IO.Directory.GetFiles(fbdAbrir.SelectedPath))
            {
                ListaImgTotal.Add(new Image<Gray, byte>(item));
                ListaClasseTotal.Add((int)FuncoesUteis.ExtrairClasseNomeArquivo(item));
            }

            List<Image<Gray, byte>> ListaImgTreinamento = new List<Image<Gray, byte>>();
            List<int> ListaClasseTreinamento = new List<int>();
            List<Image<Gray, byte>> ListaImgTeste = new List<Image<Gray, byte>>();
            List<int> ListaClasseTeste = new List<int>();
            int index;
            double[] acertos = new double[int.Parse(txtFolds.Text)];
            for (int i = 0; i < int.Parse(txtFolds.Text); i++)
            {

                ListaImgTreinamento.Clear();
                ListaClasseTreinamento.Clear();
                ListaImgTeste.Clear();
                ListaClasseTeste.Clear();

                index = i;

                for (int j = 0; j < ListaImgTotal.Count; j++)
                {

                    if (j == index)
                    {
                        ListaImgTeste.Add(ListaImgTotal[j]);
                        ListaClasseTeste.Add(ListaClasseTotal[j]);
                        index += int.Parse(txtFolds.Text);
                    }
                    else
                    {
                        ListaImgTreinamento.Add(ListaImgTotal[j]);
                        ListaClasseTreinamento.Add(ListaClasseTotal[j]);
                    }

                }

                if (recognizer != null)
                    recognizer.Dispose();

                if (cmbMetodo.SelectedIndex == 0)
                    recognizer = new EigenFaceRecognizer(80, int.Parse(txtParametro.Text)); // Melhores parâmetros: 80, 10000
                else if (cmbMetodo.SelectedIndex == 1)
                    recognizer = new FisherFaceRecognizer(0, int.Parse(txtParametro.Text)); // Melhores parâmetros: 0, 3000
                else
                    recognizer = new LBPHFaceRecognizer(1, 8, 8, 8, int.Parse(txtParametro.Text)); // Melhores parâmetros: 1, 8, 8, 8, 100

                recognizer.Train(ListaImgTreinamento.ToArray(), ListaClasseTreinamento.ToArray());

                for (int j = 0; j < ListaImgTeste.Count; j++)
                {

                    if (ListaClasseTeste[j] == recognizer.Predict(ListaImgTeste[j]).Label)
                        acertos[i]++;

                }

                acertos[i] = (double)((acertos[i] / ListaClasseTeste.Count) * 100);

            }

            MessageBox.Show("Média de acertos: " + acertos.Average().ToString() + " %");

        }

        private void btnTreinar_Click(object sender, EventArgs e)
        {
            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            Treinar(fbdAbrir.SelectedPath);
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            Testar(fbdAbrir.SelectedPath);
        }

        public void Treinar(String urlPath)
        {

            List<Image<Gray, byte>> lstImgTreinamento = new List<Image<Gray, byte>>();
            List<int> lstClasseTreinamento = new List<int>();

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {
                lstImgTreinamento.Add(new Image<Gray, byte>(item));
                lstClasseTreinamento.Add((int)FuncoesUteis.ExtrairClasseNomeArquivo(item));
            }

            if (cmbMetodo.SelectedIndex == 0)
                recognizer = new EigenFaceRecognizer(80, int.Parse(txtParametro.Text)); // Melhores parâmetros: 80, 10000
            else if (cmbMetodo.SelectedIndex == 1)
                recognizer = new FisherFaceRecognizer(0, int.Parse(txtParametro.Text)); // Melhores parâmetros: 0, 3000
            else
                recognizer = new LBPHFaceRecognizer(1, 8, 8, 8, int.Parse(txtParametro.Text)); // Melhores parâmetros: 1, 8, 8, 8, 100

            recognizer.Train(lstImgTreinamento.ToArray(), lstClasseTreinamento.ToArray());

            MessageBox.Show("Procedimento executado com sucesso.");

        }

        public void Testar(String urlPath)
        {

            int acertos = 0;

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {

                if (((int)FuncoesUteis.ExtrairClasseNomeArquivo(item)) == recognizer.Predict(new Image<Gray, byte>(item)).Label)
                    acertos++;

            }

            MessageBox.Show("Total de acertos: " + acertos);

        }

    }
}
