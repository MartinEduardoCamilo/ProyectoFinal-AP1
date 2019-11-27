namespace FotosCopias.UI.Consulta
{
    partial class cUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cUsuarios));
            this.Imprimirbutton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Consultarbutton = new System.Windows.Forms.Button();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.desdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Imprimirbutton
            // 
            this.Imprimirbutton.Image = ((System.Drawing.Image)(resources.GetObject("Imprimirbutton.Image")));
            this.Imprimirbutton.Location = new System.Drawing.Point(355, 318);
            this.Imprimirbutton.Name = "Imprimirbutton";
            this.Imprimirbutton.Size = new System.Drawing.Size(75, 63);
            this.Imprimirbutton.TabIndex = 5;
            this.Imprimirbutton.Text = "Imprimir";
            this.Imprimirbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Imprimirbutton.UseVisualStyleBackColor = true;
            this.Imprimirbutton.Click += new System.EventHandler(this.Imprimirbutton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 63);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(788, 218);
            this.dataGridView.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Consultarbutton);
            this.panel1.Controls.Add(this.CriteriotextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.FiltrocomboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.hastadateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.desdedateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 45);
            this.panel1.TabIndex = 3;
            // 
            // Consultarbutton
            // 
            this.Consultarbutton.Location = new System.Drawing.Point(687, 9);
            this.Consultarbutton.Name = "Consultarbutton";
            this.Consultarbutton.Size = new System.Drawing.Size(75, 23);
            this.Consultarbutton.TabIndex = 8;
            this.Consultarbutton.Text = "Consultar";
            this.Consultarbutton.UseVisualStyleBackColor = true;
            this.Consultarbutton.Click += new System.EventHandler(this.Consultarbutton_Click);
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(515, 9);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(144, 20);
            this.CriteriotextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Criterio";
            // 
            // FiltrocomboBox
            // 
            this.FiltrocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FiltrocomboBox.FormattingEnabled = true;
            this.FiltrocomboBox.Items.AddRange(new object[] {
            "Todo",
            "ID",
            "Nombre"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(332, 8);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(121, 21);
            this.FiltrocomboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtro";
            // 
            // hastadateTimePicker
            // 
            this.hastadateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.hastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastadateTimePicker.Location = new System.Drawing.Point(186, 9);
            this.hastadateTimePicker.Name = "hastadateTimePicker";
            this.hastadateTimePicker.Size = new System.Drawing.Size(93, 20);
            this.hastadateTimePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta";
            // 
            // desdedateTimePicker
            // 
            this.desdedateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.desdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdedateTimePicker.Location = new System.Drawing.Point(48, 10);
            this.desdedateTimePicker.Name = "desdedateTimePicker";
            this.desdedateTimePicker.Size = new System.Drawing.Size(91, 20);
            this.desdedateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // cUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 400);
            this.Controls.Add(this.Imprimirbutton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "cUsuarios";
            this.Text = "cUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Imprimirbutton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Consultarbutton;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hastadateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker desdedateTimePicker;
        private System.Windows.Forms.Label label1;
    }
}