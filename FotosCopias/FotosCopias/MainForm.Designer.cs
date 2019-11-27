namespace FotoStudio
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeArticuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nivellabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userpanel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.userpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.consutasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroDeArticuloToolStripMenuItem,
            this.facturaToolStripMenuItem,
            this.registroClienteToolStripMenuItem,
            this.registroEventosToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.registroToolStripMenuItem.Text = "Registro";
            this.registroToolStripMenuItem.Click += new System.EventHandler(this.registroToolStripMenuItem_Click);
            // 
            // registroDeArticuloToolStripMenuItem
            // 
            this.registroDeArticuloToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroDeArticuloToolStripMenuItem.Image")));
            this.registroDeArticuloToolStripMenuItem.Name = "registroDeArticuloToolStripMenuItem";
            this.registroDeArticuloToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registroDeArticuloToolStripMenuItem.Text = "Articulo";
            this.registroDeArticuloToolStripMenuItem.Click += new System.EventHandler(this.registroDeArticuloToolStripMenuItem_Click);
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("facturaToolStripMenuItem.Image")));
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.facturaToolStripMenuItem.Text = "Factura";
            this.facturaToolStripMenuItem.Click += new System.EventHandler(this.facturaToolStripMenuItem_Click);
            // 
            // registroClienteToolStripMenuItem
            // 
            this.registroClienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroClienteToolStripMenuItem.Image")));
            this.registroClienteToolStripMenuItem.Name = "registroClienteToolStripMenuItem";
            this.registroClienteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registroClienteToolStripMenuItem.Text = "Cliente";
            this.registroClienteToolStripMenuItem.Click += new System.EventHandler(this.registroClienteToolStripMenuItem_Click);
            // 
            // registroEventosToolStripMenuItem
            // 
            this.registroEventosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroEventosToolStripMenuItem.Image")));
            this.registroEventosToolStripMenuItem.Name = "registroEventosToolStripMenuItem";
            this.registroEventosToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registroEventosToolStripMenuItem.Text = "Eventos";
            this.registroEventosToolStripMenuItem.Click += new System.EventHandler(this.registroEventosToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuarioToolStripMenuItem.Image")));
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // consutasToolStripMenuItem
            // 
            this.consutasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarClienteToolStripMenuItem,
            this.consultarArticulosToolStripMenuItem,
            this.consultarEventosToolStripMenuItem,
            this.facturaToolStripMenuItem1});
            this.consutasToolStripMenuItem.Name = "consutasToolStripMenuItem";
            this.consutasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.consutasToolStripMenuItem.Text = "Consutar";
            // 
            // consultarClienteToolStripMenuItem
            // 
            this.consultarClienteToolStripMenuItem.Name = "consultarClienteToolStripMenuItem";
            this.consultarClienteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.consultarClienteToolStripMenuItem.Text = "Cliente";
            this.consultarClienteToolStripMenuItem.Click += new System.EventHandler(this.consultarClienteToolStripMenuItem_Click);
            // 
            // consultarArticulosToolStripMenuItem
            // 
            this.consultarArticulosToolStripMenuItem.Name = "consultarArticulosToolStripMenuItem";
            this.consultarArticulosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.consultarArticulosToolStripMenuItem.Text = "Articulos";
            this.consultarArticulosToolStripMenuItem.Click += new System.EventHandler(this.consultarArticulosToolStripMenuItem_Click);
            // 
            // consultarEventosToolStripMenuItem
            // 
            this.consultarEventosToolStripMenuItem.Name = "consultarEventosToolStripMenuItem";
            this.consultarEventosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.consultarEventosToolStripMenuItem.Text = "Eventos";
            this.consultarEventosToolStripMenuItem.Click += new System.EventHandler(this.consultarEventosToolStripMenuItem_Click);
            // 
            // facturaToolStripMenuItem1
            // 
            this.facturaToolStripMenuItem1.Name = "facturaToolStripMenuItem1";
            this.facturaToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.facturaToolStripMenuItem1.Text = "Factura";
            this.facturaToolStripMenuItem1.Click += new System.EventHandler(this.facturaToolStripMenuItem1_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.reportesToolStripMenuItem.Text = "Salida";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // Nivellabel
            // 
            this.Nivellabel.AutoSize = true;
            this.Nivellabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Nivellabel.Location = new System.Drawing.Point(12, 586);
            this.Nivellabel.Name = "Nivellabel";
            this.Nivellabel.Size = new System.Drawing.Size(0, 13);
            this.Nivellabel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(952, 582);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // userpanel1
            // 
            this.userpanel1.Controls.Add(this.label1);
            this.userpanel1.Location = new System.Drawing.Point(0, 586);
            this.userpanel1.Name = "userpanel1";
            this.userpanel1.Size = new System.Drawing.Size(182, 22);
            this.userpanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(952, 608);
            this.Controls.Add(this.userpanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Nivellabel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.userpanel1.ResumeLayout(false);
            this.userpanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeArticuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarEventosToolStripMenuItem;
        private System.Windows.Forms.Label Nivellabel;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel userpanel1;
        private System.Windows.Forms.Label label1;
    }
}

