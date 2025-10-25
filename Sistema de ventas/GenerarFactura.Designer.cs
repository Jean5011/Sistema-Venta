
namespace Sistema_de_ventas
{
    partial class GenerarFactura
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Reporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Reporte
            // 
            this.Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            this.Reporte.LocalReport.DataSources.Add(reportDataSource1);
            this.Reporte.LocalReport.ReportEmbeddedResource = "Sistema_de_ventas.InformeFactura.rdlc";
            this.Reporte.Location = new System.Drawing.Point(0, 0);
            this.Reporte.Name = "Reporte";
            this.Reporte.ServerReport.BearerToken = null;
            this.Reporte.Size = new System.Drawing.Size(800, 450);
            this.Reporte.TabIndex = 0;
            this.Reporte.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // GenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reporte);
            this.Name = "GenerarFactura";
            this.Text = "GenerarFactura";
            this.Load += new System.EventHandler(this.GenerarFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer Reporte;
    }
}