using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL;

namespace Sistema_de_ventas
{
    public partial class Consulta : FormBase
    {
        public Consulta()
        {
            InitializeComponent();
        }

        public DataSet MostrarInFoDG(String Tabla)
        { 
            String cmd = String.Format("select * from " + Tabla);
            DataSet ds = Biblioteca.Herramientas(cmd); 
            return ds;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult=DialogResult.OK;
                Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
