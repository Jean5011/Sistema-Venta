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
    public partial class Usuario : FormBase
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            string consulta = "select * from Usuarios where id_usuario=" + Login.codigo;
            DataSet data = Biblioteca.Herramientas(consulta);

            lUser.Text= data.Tables[0].Rows[0]["account"].ToString();
            lnombre.Text = data.Tables[0].Rows[0]["username"].ToString();
            lcodigo.Text = data.Tables[0].Rows[0]["id_usuario"].ToString();
            try
            {
                string img = data.Tables[0].Rows[0]["Imagen"].ToString();
                UserImagen.Image = Image.FromFile(img);
                UserImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception error) { }
        }

        private void UserImagen_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal con = new ContenedorPrincipal();
            this.Hide();
            con.Show();
        }
    }
}
