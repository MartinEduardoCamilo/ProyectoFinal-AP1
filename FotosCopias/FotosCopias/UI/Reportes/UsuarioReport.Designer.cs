namespace FotosCopias.UI.Reportes
{
    partial class UsuarioReport
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
            this.UsuarioView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // UsuarioView
            // 
            this.UsuarioView.ActiveViewIndex = -1;
            this.UsuarioView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsuarioView.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsuarioView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuarioView.Location = new System.Drawing.Point(0, 0);
            this.UsuarioView.Name = "UsuarioView";
            this.UsuarioView.Size = new System.Drawing.Size(800, 450);
            this.UsuarioView.TabIndex = 0;
            // 
            // UsuarioReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsuarioView);
            this.Name = "UsuarioReport";
            this.Text = "Reporte de Usuario";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer UsuarioView;
    }
}