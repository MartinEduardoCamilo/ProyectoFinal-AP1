namespace FotosCopias.UI.Reportes
{
    partial class ArticuloReport
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
            this.ArticuloView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ArticuloView
            // 
            this.ArticuloView.ActiveViewIndex = -1;
            this.ArticuloView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArticuloView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ArticuloView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArticuloView.Location = new System.Drawing.Point(0, 0);
            this.ArticuloView.Name = "ArticuloView";
            this.ArticuloView.Size = new System.Drawing.Size(800, 450);
            this.ArticuloView.TabIndex = 0;
            // 
            // ArticuloReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ArticuloView);
            this.Name = "ArticuloReport";
            this.Text = "Reporte de Articulos";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ArticuloView;
    }
}