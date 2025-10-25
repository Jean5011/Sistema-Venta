using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas
{
    public partial class GenerarFactura : Form
    {
        public GenerarFactura()
        {
            InitializeComponent();
        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {

            this.Reporte.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void DatosFacturaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
