namespace wsqEncodeDecode
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Decode = new System.Windows.Forms.Button();
            this.Encode = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pathWSQ = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pathImage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Decode
            // 
            this.Decode.Location = new System.Drawing.Point(140, 161);
            this.Decode.Name = "Decode";
            this.Decode.Size = new System.Drawing.Size(75, 23);
            this.Decode.TabIndex = 0;
            this.Decode.Text = "Decode";
            this.Decode.UseVisualStyleBackColor = true;
            this.Decode.Click += new System.EventHandler(this.Decode_Click);
            // 
            // Encode
            // 
            this.Encode.Location = new System.Drawing.Point(31, 161);
            this.Encode.Name = "Encode";
            this.Encode.Size = new System.Drawing.Size(75, 23);
            this.Encode.TabIndex = 1;
            this.Encode.Text = "Encode";
            this.Encode.UseVisualStyleBackColor = true;
            this.Encode.Click += new System.EventHandler(this.Encode_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selecciona WSQ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SeleccionaArchivoWSQ_Click);
            // 
            // pathWSQ
            // 
            this.pathWSQ.Enabled = false;
            this.pathWSQ.Location = new System.Drawing.Point(31, 41);
            this.pathWSQ.Name = "pathWSQ";
            this.pathWSQ.Size = new System.Drawing.Size(184, 20);
            this.pathWSQ.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Seleciona BMP/TIFF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SeleccionaArchivoImagen_Click);
            // 
            // pathImage
            // 
            this.pathImage.Enabled = false;
            this.pathImage.Location = new System.Drawing.Point(31, 105);
            this.pathImage.Name = "pathImage";
            this.pathImage.Size = new System.Drawing.Size(184, 20);
            this.pathImage.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 220);
            this.Controls.Add(this.pathImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pathWSQ);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Encode);
            this.Controls.Add(this.Decode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Decode;
        private System.Windows.Forms.Button Encode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pathWSQ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox pathImage;
    }
}

