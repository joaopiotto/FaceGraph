using AnaliseGrafo;
using Classificadores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class frmDestacarPontosChave : Form
    {

        #region Atributos da classe

        #endregion

        #region Eventos da classe

        /// <summary>
        /// Ação do botão Selecionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelecionar_Click(object sender, EventArgs e)
        {

            if (ofdArquivo.ShowDialog() == DialogResult.OK)
            {
                imgFigura.Image = Image.FromFile(ofdArquivo.FileName);
                btnDetectar.Enabled = true;
                btnRegiaoInteresse.Enabled = true;
            }

        }

        /// <summary>
        /// Ação do botão Detectar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetectar_Click(object sender, EventArgs e)
        {
            RetornoDescritor retorno = Descritores.DesenharPontosChave(ofdArquivo.FileName, (TipoDescritor)cmbDescritor.SelectedIndex, double.Parse(txtRaio.Text), ckbFiltro.Checked);
            imgFigura.Image = retorno.ImagemDestacada;
            lblTotal.Text = "Total de pontos encontrados: " + retorno.TotalPontos;
        }

        /// <summary>
        /// Ação do botão exportar em lote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportarLote_Click(object sender, EventArgs e)
        {
            if (fbdAbrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                List<Amostra> lista = new List<Amostra>();

                foreach (String arquivo in System.IO.Directory.GetFiles(fbdAbrir.SelectedPath))
                    lista.AddRange(Descritores.DetectarCaracteristicas(arquivo, (TipoDescritor)cmbDescritor.SelectedIndex, ckbFiltro.Checked));
                
                if (sfdSalvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    new frmExportar(lista, sfdSalvar.FileName).ShowDialog();
                
            }
        }

        /// <summary>
        /// Ação do botão detectar por região de interesse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegiaoInteresse_Click(object sender, EventArgs e)
        {
            RetornoDescritor retorno = PontosPorRegiaoInteresse.DesenharPontosChave(ofdArquivo.FileName, (TipoDescritor)cmbDescritor.SelectedIndex, double.Parse(txtRaio.Text), ckbFiltro.Checked);
            imgFigura.Image = retorno.ImagemDestacada;
            lblTotal.Text = "Total de pontos encontrados: " + retorno.TotalPontos;
        }

        #endregion

        #region Métodos  da classe

        /// <summary>
        /// Método construtor
        /// </summary>
        public frmDestacarPontosChave()
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(TipoDescritor)))
            {
                cmbDescritor.Items.Add(item);
            }

        }

        #endregion

    }

}