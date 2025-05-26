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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           // this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnInicial_Click(object sender, EventArgs e)
        {
            try
            {
                String validar = String.Format("select * from Usuarios where account='{0}' AND password = '{1}'", textUsuario.Text.Trim(), textPassword.Text.Trim());

                DataSet conectar = Biblioteca.Herramientas(validar);
                string cuenta = conectar.Tables[0].Rows[0]["account"].ToString().Trim();
                string contasena = conectar.Tables[0].Rows[0]["password"].ToString().Trim();
                if(cuenta == textUsuario.Text.Trim() && contasena == textPassword.Text.Trim())
                {
                    //MessageBox.Show("Se pudo conectar");
                    if (Convert.ToBoolean(conectar.Tables[0].Rows[0]["validar_admin"].ToString().Trim()))
                    {
                        Administrador admin = new Administrador();
                        this.Hide();
                        admin.Show();
                    }
                    else
                    {
                        Usuario user = new Usuario();
                        this.Hide();
                        user.Show();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo conectar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
