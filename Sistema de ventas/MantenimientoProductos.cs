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
            try
            {
                String inserter = string.Format("EXEC ActualizaProductos '{0}','{1}','{2}'", textIdProducto.Text.Trim(), textDescripcion.Text.Trim(), textPrecio.Text.Trim());
                Biblioteca.Herramientas(inserter);
                MessageBox.Show("Se a guardado correctamente");
                return true;
            }catch(Exception error)
            {
                MessageBox.Show("Ha ocurrido un error");
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                String eleminar = String.Format("EXEC EliminarProducto '{0}'", textIdProducto.Text.Trim());
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
