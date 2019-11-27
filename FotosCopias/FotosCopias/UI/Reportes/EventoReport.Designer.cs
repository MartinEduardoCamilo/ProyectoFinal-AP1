namespace FotosCopias.UI.Reportes
{
    partial class EventoReport
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
            this.EventoView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // EventoView
            // 
            this.EventoView.ActiveViewIndex = -1;
            this.EventoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.EventoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventoView.Location = new System.Drawing.Point(0, 0);
            this.EventoView.Name = "EventoView";
            this.EventoView.Size = new System.Drawing.Size(800, 450);
            this.EventoView.TabIndex = 0;
            // 
            // EventoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EventoView);
            this.Name = "EventoReport";
            this.Text = "Reporte de Eventos";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer EventoView;
    }
}