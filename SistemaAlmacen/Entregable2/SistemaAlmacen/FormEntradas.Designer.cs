namespace SistemaAlmacen
{
    partial class FormEntradas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntradas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbIdProveedor = new System.Windows.Forms.ComboBox();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFactEntrada = new System.Windows.Forms.TextBox();
            this.txtCantidadRecibida = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIdProducto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.cmbIdProveedor);
            this.panel1.Controls.Add(this.cmbIdProducto);
            this.panel1.Controls.Add(this.dtpHoraEntrada);
            this.panel1.Controls.Add(this.dtpFechaEntrada);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNumeroFactEntrada);
            this.panel1.Controls.Add(this.txtCantidadRecibida);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(66, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 456);
            this.panel1.TabIndex = 3;
            // 
            // cmbIdProveedor
            // 
            this.cmbIdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdProveedor.FormattingEnabled = true;
            this.cmbIdProveedor.Location = new System.Drawing.Point(494, 243);
            this.cmbIdProveedor.Name = "cmbIdProveedor";
            this.cmbIdProveedor.Size = new System.Drawing.Size(141, 24);
            this.cmbIdProveedor.TabIndex = 30;
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.Location = new System.Drawing.Point(487, 169);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.Size = new System.Drawing.Size(166, 22);
            this.dtpHoraEntrada.TabIndex = 28;
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaEntrada.Location = new System.Drawing.Point(162, 322);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(141, 22);
            this.dtpFechaEntrada.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 71);
            this.label4.TabIndex = 23;
            this.label4.Text = "Registro de entrada de Productos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumeroFactEntrada
            // 
            this.txtNumeroFactEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFactEntrada.Location = new System.Drawing.Point(494, 314);
            this.txtNumeroFactEntrada.Name = "txtNumeroFactEntrada";
            this.txtNumeroFactEntrada.Size = new System.Drawing.Size(141, 22);
            this.txtNumeroFactEntrada.TabIndex = 22;
            // 
            // txtCantidadRecibida
            // 
            this.txtCantidadRecibida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadRecibida.Location = new System.Drawing.Point(162, 245);
            this.txtCantidadRecibida.Name = "txtCantidadRecibida";
            this.txtCantidadRecibida.Size = new System.Drawing.Size(141, 22);
            this.txtCantidadRecibida.TabIndex = 17;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Teal;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(549, 400);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 42);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Añadir";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label8.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(353, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 40);
            this.label8.TabIndex = 12;
            this.label8.Text = "Número de factura:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(114, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 40);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cantidad Recibida";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 40);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha de Entrada:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(353, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hora Entrada:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID Proveedor:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID producto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbIdProducto
            // 
            this.cmbIdProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdProducto.FormattingEnabled = true;
            this.cmbIdProducto.Location = new System.Drawing.Point(162, 163);
            this.cmbIdProducto.Name = "cmbIdProducto";
            this.cmbIdProducto.Size = new System.Drawing.Size(141, 24);
            this.cmbIdProducto.TabIndex = 29;
            // 
            // FormEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormEntradas";
            this.Text = "FormEntradas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFactEntrada;
        private System.Windows.Forms.TextBox txtCantidadRecibida;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.ComboBox cmbIdProveedor;
        private System.Windows.Forms.ComboBox cmbIdProducto;
    }
}