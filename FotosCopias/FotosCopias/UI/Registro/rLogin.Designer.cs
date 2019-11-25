namespace FotosCopias.UI.Registro
{
    partial class rLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rLogin));
            this.userlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuariotextBox = new System.Windows.Forms.TextBox();
            this.contraseñatextBox = new System.Windows.Forms.TextBox();
            this.Limpiarbutton = new System.Windows.Forms.Button();
            this.Ingresarbutton = new System.Windows.Forms.Button();
            this.Myerror = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Myerror)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Location = new System.Drawing.Point(13, 13);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(43, 13);
            this.userlabel.TabIndex = 0;
            this.userlabel.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Constraseña";
            // 
            // usuariotextBox
            // 
            this.usuariotextBox.Location = new System.Drawing.Point(62, 6);
            this.usuariotextBox.Name = "usuariotextBox";
            this.usuariotextBox.Size = new System.Drawing.Size(137, 20);
            this.usuariotextBox.TabIndex = 2;
            // 
            // contraseñatextBox
            // 
            this.contraseñatextBox.Location = new System.Drawing.Point(85, 45);
            this.contraseñatextBox.Name = "contraseñatextBox";
            this.contraseñatextBox.Size = new System.Drawing.Size(114, 20);
            this.contraseñatextBox.TabIndex = 3;
            this.contraseñatextBox.UseSystemPasswordChar = true;
            // 
            // Limpiarbutton
            // 
            this.Limpiarbutton.Location = new System.Drawing.Point(16, 82);
            this.Limpiarbutton.Name = "Limpiarbutton";
            this.Limpiarbutton.Size = new System.Drawing.Size(75, 23);
            this.Limpiarbutton.TabIndex = 4;
            this.Limpiarbutton.Text = "Limpiar";
            this.Limpiarbutton.UseVisualStyleBackColor = true;
            this.Limpiarbutton.Click += new System.EventHandler(this.Limpiarbutton_Click);
            // 
            // Ingresarbutton
            // 
            this.Ingresarbutton.Location = new System.Drawing.Point(124, 82);
            this.Ingresarbutton.Name = "Ingresarbutton";
            this.Ingresarbutton.Size = new System.Drawing.Size(75, 23);
            this.Ingresarbutton.TabIndex = 5;
            this.Ingresarbutton.Text = "Ingresar";
            this.Ingresarbutton.UseVisualStyleBackColor = true;
            this.Ingresarbutton.Click += new System.EventHandler(this.Ingresarbutton_Click);
            // 
            // Myerror
            // 
            this.Myerror.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(236, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 68);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // rLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(348, 119);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Ingresarbutton);
            this.Controls.Add(this.Limpiarbutton);
            this.Controls.Add(this.contraseñatextBox);
            this.Controls.Add(this.usuariotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rLogin";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.Myerror)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuariotextBox;
        private System.Windows.Forms.TextBox contraseñatextBox;
        private System.Windows.Forms.Button Limpiarbutton;
        private System.Windows.Forms.Button Ingresarbutton;
        private System.Windows.Forms.ErrorProvider Myerror;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}