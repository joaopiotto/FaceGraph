using Classificadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmExportar : Form
    {

        List<Amostra> listaExportacao;
        String nomeArquivo;

        public frmExportar(List<Amostra> listaExportacao, String nomeArquivo)
        {
            InitializeComponent();
            this.listaExportacao = listaExportacao;
            this.nomeArquivo = nomeArquivo;
            cmbFormato.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Util.ExportarDadosArquivo(listaExportacao, nomeArquivo, (TipoFormatoExportacao)cmbFormato.SelectedIndex, ckbCabec.Checked, ckbClasse.Checked);
            MessageBox.Show("Arquivo exportado com sucesso.");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
