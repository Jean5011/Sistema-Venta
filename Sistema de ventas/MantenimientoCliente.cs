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
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == 0)
            {
                try
                {
                    String inserter = string.Format("EXEC ActualizaClientes '{0}','{1}','{2}'", textIdCliente.Text.Trim(), textNombre.Text.Trim(), textApellido.Text.Trim());
                    Biblioteca.Herramientas(inserter);
                    MessageBox.Show("Se a guardado correctamente");
                    textIdCliente.Clear();
                    textNombre.Clear();
                    textApellido.Clear();
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    return false;
                }
            }
            else if(Biblioteca.ValidarFormulario(this, errorProvider1)==1)
            {
                ///MessageBox.Show("Ha ocurrido un error pe causa"); 
                MessageBox.Show("No se puede dejar en blanco");
                textIdCliente.Clear();
                textNombre.Clear();
                textApellido.Clear();

            }
            else if (Biblioteca.ValidarFormulario(this, errorProvider1) == 2)
            {
                MessageBox.Show("No se puede ingresar letras como id");
                textIdCliente.Clear();
                textNombre.Clear();
                textApellido.Clear();

            }
            return false;

        }

        public override void Eliminar()
        {
            try
            {
                String eleminar = String.Format("EXEC EliminarCliente '{0}'", textIdCliente.Text.Trim());
                Biblioteca.Herramientas(eleminar);
                MessageBox.Show("Se a eliminado correctamente");
                textIdCliente.Clear();
                textNombre.Clear();
                textApellido.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void textIdCliente_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            ConsultaClientes consulta = new ConsultaClientes();
            consulta.Show();
        }
    }
}
