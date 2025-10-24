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
    public partial class MantenimientoProductos : Mantenimiento
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void MantenimientoProductos_Load(object sender, EventArgs e)
        {

        }
        public override Boolean Guardar()
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == 0)
            {
                try
                {
                    String inserter = string.Format("EXEC ActualizaProductos '{0}','{1}','{2}'", textIdProducto.Text.Trim(), textDescripcion.Text.Trim(), textPrecio.Text.Trim());
                    Biblioteca.Herramientas(inserter);
                    MessageBox.Show("Se a guardado correctamente");
                    textIdProducto.Clear();
                    textDescripcion.Clear();
                    textPrecio.Clear();
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    return false;
                }
            }
            else if (Biblioteca.ValidarFormulario(this, errorProvider1) == 1)
            {
                ///MessageBox.Show("Ha ocurrido un error pe causa"); 
                MessageBox.Show("No se puede dejar en blanco");
                textIdProducto.Clear();
                textDescripcion.Clear();
                textPrecio.Clear();

            }
            else if (Biblioteca.ValidarFormulario(this, errorProvider1) == 2)
            {
                textIdProducto.Clear();
                textDescripcion.Clear();
                textPrecio.Clear();
                MessageBox.Show("No se puede ingresar letras como id");
            }
            return false;
        }

        public override void Eliminar()
        {
            try
            {
                String eleminar = String.Format("EXEC EliminarProducto '{0}'", textIdProducto.Text.Trim());
                Biblioteca.Herramientas(eleminar);
                MessageBox.Show("Se a eliminado correctamente");
                textIdProducto.Clear();
                textDescripcion.Clear();
                textPrecio.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void textIdProducto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            ConsultaProductos consulta = new ConsultaProductos();
            consulta.Show();
        }
    }
}
