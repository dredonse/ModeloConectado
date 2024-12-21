namespace ImagenPB_BD
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
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.btnLeerFichero = new System.Windows.Forms.Button();
            this.btnGrabarBD = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxImagen
            // 
            this.pbxImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxImagen.Location = new System.Drawing.Point(39, 38);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(220, 219);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 0;
            this.pbxImagen.TabStop = false;
            // 
            // btnLeerFichero
            // 
            this.btnLeerFichero.Location = new System.Drawing.Point(300, 55);
            this.btnLeerFichero.Name = "btnLeerFichero";
            this.btnLeerFichero.Size = new System.Drawing.Size(249, 37);
            this.btnLeerFichero.TabIndex = 1;
            this.btnLeerFichero.Text = "Leer Imagen desde Fichero";
            this.btnLeerFichero.UseVisualStyleBackColor = true;
            this.btnLeerFichero.Click += new System.EventHandler(this.btnLeerFichero_Click);
            // 
            // btnGrabarBD
            // 
            this.btnGrabarBD.Location = new System.Drawing.Point(300, 128);
            this.btnGrabarBD.Name = "btnGrabarBD";
            this.btnGrabarBD.Size = new System.Drawing.Size(249, 37);
            this.btnGrabarBD.TabIndex = 2;
            this.btnGrabarBD.Text = "Grabar en Base de datos";
            this.btnGrabarBD.UseVisualStyleBackColor = true;
            this.btnGrabarBD.Click += new System.EventHandler(this.btnGrabarBD_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(300, 199);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(249, 37);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir de la aplicación";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 293);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabarBD);
            this.Controls.Add(this.btnLeerFichero);
            this.Controls.Add(this.pbxImagen);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grabar Imagen en Base de Datos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Button btnLeerFichero;
        private System.Windows.Forms.Button btnGrabarBD;
        private System.Windows.Forms.Button btnSalir;
    }
}

