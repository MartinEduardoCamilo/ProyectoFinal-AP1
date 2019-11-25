namespace FotosCopias.UI.Reportes
{
    partial class EventoReports
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
            this.Eventoview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Eventoview
            // 
            this.Eventoview.ActiveViewIndex = -1;
            this.Eventoview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Eventoview.Cursor = System.Windows.Forms.Cursors.Default;
            this.Eventoview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eventoview.Location = new System.Drawing.Point(0, 0);
            this.Eventoview.Name = "Eventoview";
            this.Eventoview.Size = new System.Drawing.Size(800, 450);
            this.Eventoview.TabIndex = 0;
            // 
            // EventoReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Eventoview);
            this.Name = "EventoReports";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Eventoview;
    }
}