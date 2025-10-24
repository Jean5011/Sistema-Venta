
namespace Sistema_de_ventas
{
    partial class MantenimientoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoCliente));
            this.textIdCliente = new LibreriaDLL.errorTextBox();
            this.textNombre = new LibreriaDLL.errorTextBox();
            this.textApellido = new LibreriaDLL.errorTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsulta
            // 
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(133, 154);
            this.label1.Size = new System.Drawing.Size(118, 28);
            this.label1.Text = "Id Cliente:";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(133, 264);
            this.label3.Size = new System.Drawing.Size(106, 28);
            this.label3.Text = "Apellido:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            this.errorProvider1.RightToLeft = true;
            // 
            // textIdCliente
            // 
            this.textIdCliente.Location = new System.Drawing.Point(291, 154);
            this.textIdCliente.Name = "textIdCliente";
            this.textIdCliente.Size = new System.Drawing.Size(237, 22);
            this.textIdCliente.TabIndex = 12;
            this.textIdCliente.Validar = true;
            this.textIdCliente.ValidarNumeros = true;
            this.textIdCliente.TextChanged += new System.EventHandler(this.textIdCliente_TextChanged);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(291, 216);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(237, 22);
            this.textNombre.TabIndex = 13;
            this.textNombre.Validar = true;
            this.textNombre.ValidarNumeros = false;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(291, 270);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(237, 22);
            this.textApellido.TabIndex = 14;
            this.textApellido.Validar = true;
            this.textApellido.ValidarNumeros = false;
            // 
            // MantenimientoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textIdCliente);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MantenimientoCliente";
            this.Text = "MantenimientoCliente";
            this.Load += new System.EventHandler(this.MantenimientoCliente_Load);
            this.Controls.SetChildIndex(this.btnConsulta, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.textIdCliente, 0);
            this.Controls.SetChildIndex(this.textNombre, 0);
            this.Controls.SetChildIndex(this.textApellido, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LibreriaDLL.errorTextBox textIdCliente;
        private LibreriaDLL.errorTextBox textNombre;
        private LibreriaDLL.errorTextBox textApellido;
    }
}