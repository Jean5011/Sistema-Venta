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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            string consulta = "select * from Usuarios where id_usuario=" + Login.codigo;
            DataSet data = Biblioteca.Herramientas(consulta);

            lAdminUser.Text = data.Tables[0].Rows[0]["account"].ToString();
            lAdminNombre.Text = data.Tables[0].Rows[0]["username"].ToString();
            lAdminCodigo.Text = data.Tables[0].Rows[0]["id_usuario"].ToString();
            try 
            {
                string img = data.Tables[0].Rows[0]["Imagen"].ToString();
                AdminImagen.Image = Image.FromFile(img);
                AdminImagen.SizeMode = PictureBoxSizeMode.StretchImage; 
            }
            catch (Exception error) { }

        }

        private void AdminImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
