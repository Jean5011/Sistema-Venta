
namespace Sistema_de_ventas
{
    partial class MantenimientoProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textIdProducto = new System.Windows.Forms.TextBox();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(144, 28);
            this.label1.Text = "Id producto:";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(142, 28);
            this.label2.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(133, 298);
            this.label3.Size = new System.Drawing.Size(84, 28);
            this.label3.Text = "Precio:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(292, 209);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(237, 83);
            this.textDescripcion.TabIndex = 13;
            // 
            // textIdProducto
            // 
            this.textIdProducto.Location = new System.Drawing.Point(292, 152);
            this.textIdProducto.Name = "textIdProducto";
            this.textIdProducto.Size = new System.Drawing.Size(237, 22);
            this.textIdProducto.TabIndex = 12;
            // 
            // textPrecio
            // 
            this.textPrecio.Location = new System.Drawing.Point(292, 298);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(237, 22);
            this.textPrecio.TabIndex = 14;
            // 
            // MantenimientoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.textPrecio);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.textIdProducto);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MantenimientoProductos";
            this.Text = "MantenimientoProductos";
            this.Load += new System.EventHandler(this.MantenimientoProductos_Load);
            this.Controls.SetChildIndex(this.btnConsulta, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.textIdProducto, 0);
            this.Controls.SetChildIndex(this.textDescripcion, 0);
            this.Controls.SetChildIndex(this.textPrecio, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.TextBox textIdProducto;
        private System.Windows.Forms.TextBox textPrecio;
    }
}