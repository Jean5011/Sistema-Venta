using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibreriaDLL
{
    public class Biblioteca
    {
        public static DataSet Herramientas(string cmd)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DENJI5011\\SQLEXPRESS;Initial Catalog=sistema;Integrated Security=True");
            conexion.Open();

            DataSet dll = new DataSet();
            SqlDataAdapter dll1 = new SqlDataAdapter(cmd, conexion);
            dll1.Fill(dll);

            conexion.Close();

            return dll;
        }
        private static bool _validando = false;

        public static int ValidarFormulario(Control ObjetoError, ErrorProvider ErrorProvider)
        {
            int SiError = 0;
            foreach(Control campo in ObjetoError.Controls)
            {
                if(campo is errorTextBox)
                {
                    errorTextBox objeto = (errorTextBox)campo;
                    if(objeto.Validar == true)
                    {
                        if (String.IsNullOrEmpty(objeto.Text.Trim()))
                        {
                            ///ErrorProvider.SetError(objeto, "No se puede dejar en blanco");
                            SiError = 1;
                        }
                    }
                    if (objeto.ValidarNumeros == true)
                    {
                        int contador = 0, EncontrarLetras = 0;
                        foreach(char Letra in objeto.Text.Trim())
                        {
                            if (char.IsLetter(objeto.Text.Trim(), contador))
                            {
                                EncontrarLetras++;
                            }
                            contador++;
                        }
                        if (EncontrarLetras != 0)
                        {
                            SiError = 2;
                            //ErrorProvider.SetError(objeto,"Solo se acepta numeros");
                        }
                    }
                }
            }
            return SiError;
        }
    }
}
