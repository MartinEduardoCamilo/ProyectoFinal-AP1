namespace FotosCopias.UI.Reportes
{
    partial class ClientesReports
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
            this.ClienteView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ClienteView
            // 
            this.ClienteView.ActiveViewIndex = -1;
            this.ClienteView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClienteView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClienteView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClienteView.Location = new System.Drawing.Point(0, 0);
            this.ClienteView.Name = "ClienteView";
            this.ClienteView.Size = new System.Drawing.Size(800, 450);
            this.ClienteView.TabIndex = 0;
            // 
            // ClientesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClienteView);
            this.Name = "ClientesReports";
            this.Text = "Reporte de Clientes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ClienteView;
    }
}