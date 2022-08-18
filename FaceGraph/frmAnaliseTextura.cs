using AnaliseGrafo;
using Classificadores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{

    public partial class frmAnaliseTextura : Form
    {

        #region Atributos da classe


        /// <summary>
        /// Lista de centralidades selecionadas no combo
        /// </summary>
        List<TipoCalculo> listaCentralidadesSelecionadas;

        #endregion

        #region Eventos da classe

        /// <summary>
        /// Ação do botão Selecionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (fbdAbrir.ShowDialog() == DialogResult.OK)
            {

                double[] ts = new double[int.Parse(txtTamanhoVetor.Text)];
                double r = (double)(1 / (double)int.Parse(txtTamanhoVetor.Text));
                double v = 1 - r;
                for (int i = 0; i < ts.Length; i++)
                {
                    ts[i] = v;
                    v = (double)Math.Round((decimal)(v - r), 2);
                }

                foreach (String item in System.IO.Directory.GetFiles(fbdAbrir.SelectedPath))
                {
                    CoordenadasParalelas(item, ts);
                }

                MessageBox.Show("Processamento efetuado com sucesso.");

            }
        }

        /// <summary>
        /// Ação do botão Limpar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            chtResultado.Series.Clear();
        }

        /// <summary>
        /// Ação do botão Adicionar medida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncluirMedida_Click(object sender, EventArgs e)
        {
            listaCentralidadesSelecionadas.Add((TipoCalculo)cmbCentralidade.SelectedIndex);
        }

        /// <summary>
        /// Ação do botão Limpar medidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMedidas_Click(object sender, EventArgs e)
        {
            listaCentralidadesSelecionadas.Clear();
        }

        /// <summary>
        /// Ação do botão Exportar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (fbdAbrir.ShowDialog() != DialogResult.OK)
                return;

            ProcessadorImagem process = new ProcessadorImagem();
            List<Amostra> listaExportar = new List<Amostra>();

            foreach (String arquivo in System.IO.Directory.GetFiles(fbdAbrir.SelectedPath))
            {

                listaExportar.Add(process.CalcularDescritorDaFace(
                        arquivo,
                        listaCentralidadesSelecionadas,
                        (TipoDescritor)cmbDescritor.SelectedIndex,
                        int.Parse(txtRaio.Text),
                        int.Parse(txtTamanhoVetor.Text),
                        ckbOrdenar.Checked,
                        ckbReescalar.Checked,
                        ckbGerarImagens.Checked));

            }

            if (sfdSalvar.ShowDialog() != DialogResult.OK)
                return;

            new frmExportar(listaExportar, sfdSalvar.FileName).ShowDialog();

        }

        /// <summary>
        /// Evento para remover a legenda do gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chtResultado_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            e.LegendItems.Clear();
        }

        #endregion

        #region Métodos da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public frmAnaliseTextura()
        {
            
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(TipoDescritor)))
            {
                cmbDescritor.Items.Add(item);
            }

            cmbCentralidade.SelectedIndex = 0;
            cmbDescritor.SelectedIndex = 1;
            listaCentralidadesSelecionadas = new List<TipoCalculo>();
            
            listaCentralidadesSelecionadas.Add(TipoCalculo.CentralidadeDeGrau);           // red
            listaCentralidadesSelecionadas.Add(TipoCalculo.CentralidadeDeProximidade);    // blue
            listaCentralidadesSelecionadas.Add(TipoCalculo.CentralidadeDeIntermediacao);  // green
            listaCentralidadesSelecionadas.Add(TipoCalculo.CentralidadeEvcent);           // orange
            listaCentralidadesSelecionadas.Add(TipoCalculo.TriangulosAdjacentes);         // yellow
            listaCentralidadesSelecionadas.Add(TipoCalculo.Assortatividade);              // violet
            listaCentralidadesSelecionadas.Add(TipoCalculo.Cliques);                      // black
            listaCentralidadesSelecionadas.Add(TipoCalculo.NosMaisDistantes);             // brown
            listaCentralidadesSelecionadas.Add(TipoCalculo.HubScore);                     // silver

        }

        /// <summary>
        /// Método qu define uma cor aleatória
        /// </summary>
        /// <returns>Cor aleatória</returns>
        public Color DefinirCor(TipoCalculo itr)
        {

            switch (itr)
            {

                case TipoCalculo.CentralidadeDeGrau: return Color.Red;
                case TipoCalculo.CentralidadeDeProximidade: return Color.Blue;
                case TipoCalculo.CentralidadeDeIntermediacao: return Color.Green;
                case TipoCalculo.CentralidadeEvcent: return Color.Orange;
                case TipoCalculo.TriangulosAdjacentes: return Color.Yellow;
                case TipoCalculo.Assortatividade: return Color.Violet;
                case TipoCalculo.Cliques: return Color.Black;
                case TipoCalculo.NosMaisDistantes: return Color.Brown;
                case TipoCalculo.HubScore: return Color.Silver;
                default: return Color.White;

            }

        }

        /// <summary>
        /// Monta o gráfico de coordenadas paralelas
        /// </summary>
        /// <param name="arquivo">Nome do arquivo a ser usado na geração</param>
        private void CoordenadasParalelas(String arquivo, double[] ts)
        {
            
            ProcessadorImagem process = new ProcessadorImagem();

            Amostra amostra = process.CalcularDescritorDaFace(
                    arquivo,
                    listaCentralidadesSelecionadas,
                    (TipoDescritor)cmbDescritor.SelectedIndex,
                    int.Parse(txtRaio.Text),
                    int.Parse(txtTamanhoVetor.Text),
                    ckbOrdenar.Checked,
                    ckbReescalar.Checked,
                    ckbGerarImagens.Checked);

            Amostra reesc = new Amostra();

            for (int i = 0; i < listaCentralidadesSelecionadas.Count; i++)
            {

                Series serie = new Series();

                serie.ChartArea = "ChartArea1";
                serie.ChartType = SeriesChartType.FastPoint;
                serie.MarkerStyle = MarkerStyle.Star4;
                serie.Name = "Medida " + (chtResultado.Series.Count + 1).ToString();
                serie.Color = DefinirCor(listaCentralidadesSelecionadas[i]);
                serie.BorderWidth = 2;

                int inicio = int.Parse(txtTamanhoVetor.Text) * i;
                int fim = inicio + int.Parse(txtTamanhoVetor.Text);

                reesc.Caracteristicas.Clear();
                for (int j = inicio; j < fim; j++)
                {
                    reesc.Caracteristicas.Add(amostra.Caracteristicas[j]);
                }

                for (int j = 0; j < ts.Length; j++)
                {
                    serie.Points.Add(new DataPoint(ts[j], reesc.Caracteristicas[j]));
                }

                chtResultado.Series.Add(serie);

            }

        }

        #endregion
     
    }

}
