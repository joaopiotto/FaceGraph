using AnaliseGrafo;
using Classificadores;
using Classificadores.kNearestNeighbors;
using Classificadores.MaximizacaoEntropia;
using Classificadores.RandomForest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{

    public partial class frmKNNEntropia : Form
    {

        #region Atributos da classe

        List<Amostra> lstTreinamento;
        RandomForest rForest;

        #endregion

        #region Eventos da classe

        private void btnValidacaoCruzada_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            if (cmbClassificador.SelectedIndex == 0)
                ValidacaoCruzadaKNN(fbdAbrir.SelectedPath);
            else
                ValidacaoCruzadaRandomForest(fbdAbrir.SelectedPath);

        }

        private void btnTreinar_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            if (cmbClassificador.SelectedIndex == 0)
                TreinarKNN(fbdAbrir.SelectedPath);
            else
                TreinarRandomForest(fbdAbrir.SelectedPath);

        }

        private void btnTestar_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            if (cmbClassificador.SelectedIndex == 0)
                TestarKNN(fbdAbrir.SelectedPath);
            else
                TestarRandomForest(fbdAbrir.SelectedPath);

        }

        #endregion

        #region Métodos da classe

        public frmKNNEntropia()
        {

            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(TipoDescritor)))
            {
                cmbMetodo.Items.Add(item);
            }

        }

        public void ValidacaoCruzadaKNN(String urlPath)
        {

            List<Amostra> listaTreinamento;
            List<String> listaTeste;
            int index;
            double[] acertos = new double[int.Parse(txtFolds.Text)];
            String[] arquivos = System.IO.Directory.GetFiles(urlPath);
            double classe;
            kNN KNN = new kNN(5, TipoMedida.DistanciaEucliana);
            MaximizacaoEntropia entropia = new MaximizacaoEntropia();

            for (int i = 0; i < int.Parse(txtFolds.Text); i++)
            {
                
                listaTreinamento = new List<Amostra>();
                listaTeste = new List<String>();

                index = i;

                for (int j = 0; j < arquivos.Length; j++)
                {

                    if (j == index)
                    {
                        listaTeste.Add(arquivos[j]);
                        index += int.Parse(txtFolds.Text);
                    }
                    else
                    {
                        listaTreinamento.AddRange(Descritores.DetectarCaracteristicas(arquivos[j], (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked));
                    }

                }

                for (int j = 0; j < listaTeste.Count; j++)
                {

                    classe = FuncoesUteis.ExtrairClasseNomeArquivo(listaTeste[j]);

                    List<Amostra> pontosAmostra = Descritores.DetectarCaracteristicas(listaTeste[j], (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked);
                    List<Amostra> hist = new List<Amostra>();

                    foreach (Amostra item in pontosAmostra)
                    {

                        try
                        {
                            hist.Add(new Amostra(KNN.ClassificarPorClasseMaisRecorrente(item, listaTreinamento, 3).Classe));
                        }
                        catch { }

                    }

                    try
                    {
                        if (entropia.Classificar(hist).Classe == classe)
                            acertos[i]++;

                    }
                    catch { }

                }

                acertos[i] = (double)((acertos[i] / listaTeste.Count) * 100);

            }

            MessageBox.Show("Média de acertos: " + acertos.Average().ToString() + " %");

        }

        public void TreinarKNN(String urlPath)
        {

            lstTreinamento = new List<Amostra>();

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {
                lstTreinamento.AddRange(Descritores.DetectarCaracteristicas(item, (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked));
            }

            MessageBox.Show("Procedimento executado com sucesso.");

        }

        public void TestarKNN(String urlPath)
        {

            kNN KNN = new kNN(5, TipoMedida.DistanciaEucliana);
            MaximizacaoEntropia entropia = new MaximizacaoEntropia();
            double classe = 0;
            int acertos = 0;

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {

                List<Amostra> pontosAmostra = Descritores.DetectarCaracteristicas(item, (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked);
                List<Amostra> hist = new List<Amostra>();
                classe = FuncoesUteis.ExtrairClasseNomeArquivo(item);

                foreach (Amostra ponto in pontosAmostra)
                {

                    try
                    {
                        hist.Add(new Amostra(KNN.ClassificarPorClasseMaisRecorrente(ponto, lstTreinamento, 3).Classe));
                    }
                    catch { }

                }

                try
                {
                    if (entropia.Classificar(hist).Classe == classe)
                        acertos++;

                }
                catch { }

            }

            MessageBox.Show("Percentual de acertos: " + (((double)(acertos / System.IO.Directory.GetFiles(urlPath).Length)) * 100) + "%");

        }

        public void ValidacaoCruzadaRandomForest(String urlPath)
        {

            List<Amostra> listaTreinamento;
            List<String> listaTeste;
            int index;
            double[] acertos = new double[int.Parse(txtFolds.Text)];
            String[] arquivos = System.IO.Directory.GetFiles(urlPath);
            double classe;

            RandomForest randomForest;
            MaximizacaoEntropia entropia = new MaximizacaoEntropia();

            for (int i = 0; i < int.Parse(txtFolds.Text); i++)
            {

                listaTreinamento = new List<Amostra>();
                listaTeste = new List<String>();

                index = i;

                for (int j = 0; j < arquivos.Length; j++)
                {

                    if (j == index)
                    {
                        listaTeste.Add(arquivos[j]);
                        index += int.Parse(txtFolds.Text);
                    }
                    else
                    {
                        listaTreinamento.AddRange(Descritores.DetectarCaracteristicas(arquivos[j], (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked));
                    }

                }

                randomForest = new RandomForest();
                randomForest.ExecutarTreinamento(listaTreinamento, 100, 0.2);

                for (int j = 0; j < listaTeste.Count; j++)
                {

                    classe = FuncoesUteis.ExtrairClasseNomeArquivo(listaTeste[j]);

                    List<Amostra> pontosAmostra = Descritores.DetectarCaracteristicas(listaTeste[j], (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked);
                    List<Amostra> hist = new List<Amostra>();

                    foreach (Amostra item in pontosAmostra)
                    {

                        try
                        {
                            hist.Add(new Amostra(randomForest.Classificar(item).Classe));
                        }
                        catch { }

                    }

                    try
                    {
                        if (entropia.Classificar(hist).Classe == classe)
                            acertos[i]++;

                    }
                    catch { }

                }

                acertos[i] = (double)((acertos[i] / listaTeste.Count) * 100);

            }

            MessageBox.Show("Média de acertos: " + acertos.Average().ToString() + " %");

        }

        public void TreinarRandomForest(String urlPath)
        {

            lstTreinamento = new List<Amostra>();

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {
                lstTreinamento.AddRange(Descritores.DetectarCaracteristicas(item, (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked));
            }

            rForest = new RandomForest();
            rForest.ExecutarTreinamento(lstTreinamento, 100, 0.2);

            MessageBox.Show("Procedimento executado com sucesso.");

        }

        public void TestarRandomForest(String urlPath)
        {
                        
            MaximizacaoEntropia entropia = new MaximizacaoEntropia();
            double classe = 0;
            int acertos = 0;

            foreach (String item in System.IO.Directory.GetFiles(urlPath))
            {

                List<Amostra> pontosAmostra = Descritores.DetectarCaracteristicas(item, (TipoDescritor)cmbMetodo.SelectedIndex, ckbFiltro.Checked);
                List<Amostra> hist = new List<Amostra>();
                classe = FuncoesUteis.ExtrairClasseNomeArquivo(item);

                foreach (Amostra ponto in pontosAmostra)
                {

                    try
                    {
                        hist.Add(new Amostra(rForest.Classificar(ponto).Classe));
                    }
                    catch { }

                }

                try
                {
                    if (entropia.Classificar(hist).Classe == classe)
                        acertos++;

                }
                catch { }

            }

            MessageBox.Show("Percentual de acertos: " + (((double)(acertos / System.IO.Directory.GetFiles(urlPath).Length)) * 100) + "%");

        }

        #endregion

    }

}
