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
    public partial class MantenimientoCliente : Mantenimiento
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }

        private void MantenimientoCliente_Load(object sender, EventArgs e)
        { 
        
        }

        public override Boolean Guardar()
        {
            try
            {
                String inserter = string.Format("EXEC ActualizaClientes '{0}','{1}','{2}'", textIdCliente.Text.Trim(), textNombre.Text.Trim(), textApellido.Text.Trim());
                Biblioteca.Herramientas(inserter);
                MessageBox.Show("Se a guardado correctamente");
                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error");
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                String eleminar = String.Format("EXEC EliminarCliente '{0}'", textIdCliente.Text.Trim());
                Biblioteca.Herramientas(eleminar);
                MessageBox.Show("Se a eliminado correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }


    }
}
