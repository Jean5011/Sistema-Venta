using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL;


namespace Sistema_de_ventas
{
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            string vandedor = "select * from Usuarios where id_usuario=" + Login.codigo;
            DataSet ds;
            ds = Biblioteca.Herramientas(vandedor);
            lbVendedor.Text = ds.Tables[0].Rows[0]["username"].ToString().Trim();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()) == false)
                {
                    string cmd = string.Format("select nombre_cliente from Clientes where id_cliente='{0}'", txtCodigoCliente.Text.Trim());
                    DataSet ds;
                    ds = Biblioteca.Herramientas(cmd);
                    txtCliente.Text = ds.Tables[0].Rows[0]["nombre_cliente"].ToString().Trim();
                    TxtCodigoProducto.Focus();
                }
            }
            catch (exeption error)
            {
                MessageBox.Show("Ha ocurrido un error:" + error.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private static int ContadorFila = 0;
        public static double total;
        private void btnColocar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Biblioteca.ValidarFormulario(this, errorProvider1) == 1)
                {
                    bool Exite = false;
                    int numeroFila = 0;
                    if (ContadorFila == 0)
                    {
                        dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);

                        double importe = Convert.ToDouble(dataGridView1.Rows[ContadorFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[ContadorFila].Cells[3].Value);
                        dataGridView1.Rows[ContadorFila].Cells[4].Value = importe;
                        ContadorFila++;
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (!fila.IsNewRow && fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == TxtCodigoProducto.Text)
                            {
                                Exite = true;
                                numeroFila = fila.Index;
                            }
                        }
                        if (Exite == true)
                        {
                            dataGridView1.Rows[numeroFila].Cells[3].Value = (Convert.ToDouble(TxtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value)).ToString();
                            double importe = Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value);
                            dataGridView1.Rows[numeroFila].Cells[4].Value = importe;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);

                            double importe = Convert.ToDouble(dataGridView1.Rows[ContadorFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[ContadorFila].Cells[3].Value);
                            dataGridView1.Rows[ContadorFila].Cells[4].Value = importe;
                            ContadorFila++;
                        }
                    }
                }


                total = 0;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    total += Convert.ToDouble(fila.Cells[4].Value);
                }
                LbTotal.Text = "$" + total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ContadorFila > 0)
            {
                total -= (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
                LbTotal.Text = "$" + total.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                ContadorFila--;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConsultaClientes consultaClientes = new ConsultaClientes();
            consultaClientes.ShowDialog();
            if (consultaClientes.DialogResult == DialogResult.OK)
            {
                txtCodigoCliente.Text = consultaClientes.dataGridView1.Rows[consultaClientes.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtCliente.Text = consultaClientes.dataGridView1.Rows[consultaClientes.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

                TxtCodigoProducto.Focus();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ConsultaProductos consultaProductos = new ConsultaProductos();
            consultaProductos.ShowDialog();
            if (consultaProductos.DialogResult == DialogResult.OK)
            {
                TxtCodigoProducto.Text = consultaProductos.dataGridView1.Rows[consultaProductos.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtDescripcion.Text = consultaProductos.dataGridView1.Rows[consultaProductos.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                TxtPrecio.Text = consultaProductos.dataGridView1.Rows[consultaProductos.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

                TxtCantidad.Focus();
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        public override void Nuevo()
        {
            txtCliente.Text = "";
            txtCodigoCliente.Text = "";
            TxtCodigoProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            LbTotal.Text = "$0";
            dataGridView1.Rows.Clear();
            ContadorFila = 0;
            total = 0;
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (ContadorFila != 0)
            {
                try
                {
                    string cmd = string.Format("Exec ActualizarFacturas '{0}'", txtCodigoCliente.Text.Trim());
                    DataSet DS = Biblioteca.Herramientas(cmd);

                    if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                    {
                        if (DS.Tables[0].Columns.Contains("NumeroFactura"))
                        {
                            string NumeroFactura = DS.Tables[0].Rows[0]["NumeroFactura"].ToString().Trim();

                            foreach (DataGridViewRow Fila in dataGridView1.Rows)
                            {
                                if (!Fila.IsNewRow)
                                {
                                    cmd = string.Format("Exec ActualizarDetalles '{0}','{1}','{2}','{3}'",
                                                      NumeroFactura,
                                                      Fila.Cells[0].Value?.ToString() ?? "",
                                                      Fila.Cells[2].Value?.ToString() ?? "",
                                                      Fila.Cells[3].Value?.ToString() ?? "");
                                    DS = Biblioteca.Herramientas(cmd);
                                }
                            }

                            // SOLUCIÓN: Agregar comillas alrededor del parámetro
                            cmd = string.Format("Exec DatosFactura '{0}'", NumeroFactura);
                            DS = Biblioteca.Herramientas(cmd);

                            if (DS.Tables.Count > 0)
                            {
                                Factura fac = new Factura();
                                fac.reportViewer1.LocalReport.DataSources[0].Value = DS.Tables[0];
                                fac.ShowDialog();
                                Nuevo();
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
            /*if (ContadorFila != 0)
            {
                try
                {
                    string cmd = string.Format("Exac ActualizarFacturas '{0}'", txtCodigoCliente.Text.Trim());
                    DataSet ds = Biblioteca.Herramientas(cmd);
                    string NumeroFactura = ds.Tables[0].Rows[0]["NumeroFactura"].ToString().Trim();
                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        cmd = string.Format("Exac ActualizarDetalles '{0}','{1}','{2}','{3}'", NumeroFactura, Fila.Cells[0].Value.ToString(), Fila.Cells[2].Value.ToString(), Fila.Cells[3].Value.ToString());
                        ds = Biblioteca.Herramientas(cmd);
                    }
                    cmd = "Exec DatosFactura '" + NumeroFactura + "'";
                    ds = Biblioteca.Herramientas(cmd);

                    Factura fac = new Factura();
                    fac.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                    fac.ShowDialog();
                    Nuevo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }*/

            /*******//*
            if (ContadorFila >= 0)
            {
                try
                {
                    string cmd = string.Format("Exec ActualizarFacturas '{0}'", txtCodigoCliente.Text.Trim());

                    DataSet DS = Biblioteca.Herramientas(cmd);

                    string NumeroFactura = DS.Tables[0].Rows[0]["NumeroFactura"].ToString().Trim();

                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        cmd = string.Format("Exec ActualizarDetalles '{0}','{1}','{2}','{3}'", NumeroFactura, Fila.Cells[0].Value.ToString(), Fila.Cells[2].Value.ToString(), Fila.Cells[3].Value.ToString());
                        DS = Biblioteca.Herramientas(cmd);
                    }
                    cmd = "Exec DatosFactura " + NumeroFactura;

                    DS = Biblioteca.Herramientas(cmd);

                    Factura fac = new Factura();
                    fac.reportViewer1.LocalReport.DataSources[0].Value = DS.Tables[0];
                    fac.ShowDialog();

                    Nuevo();

                }

                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }*/

        }
    }
}
