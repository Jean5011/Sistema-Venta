using LibreriaDLL;
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
    public partial class ConsultaClientes : Consulta
    {
        public ConsultaClientes()
        {
            InitializeComponent();
        }

        private void ConsultaClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MostrarInFoDG("Clientes").Tables[0];
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string buscar = "Select * from Clientes where nombre_cliente LIKE ('%" + textBox1.Text.Trim() + "%')";
                DataSet ds = Biblioteca.Herramientas(buscar);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar, error", ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
