using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagenPB_BD
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;

        public Form1()
        {
            InitializeComponent();
        }
        
        // Método asociado al evento de carga del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "Server=DESKTOP-6CDGDQT\\SQLEXPRESS; DATABASE=TImagenes; Uid=sa; Pwd=1234";

            // Creamos el objeto conexión, pasándole la cadena de conexión
            conexion = new SqlConnection(cadenaConexion);

            try
            {
                // Intentamos la conexión
                conexion.Open();
            }
            catch
            {
                MessageBox.Show("Imposible realizar la conexión con la base de datos. Se cancela el programa", "Error de Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSalir.PerformClick();
            }
        }

        // Método asociado al botón btnSalir. Finaliza la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (conexion != null) conexion.Close();     // Si la conexión está abierta, la cerramos
            this.Close();                               // Cerramos el formulario
        }

        // Método asociado al botón LeerFichero. Lee una imagen grabada en disco
        private void btnLeerFichero_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFichero = new OpenFileDialog();

            // Establecemos un filtro para buscar sólo imágenes
            ofdFichero.Filter = "Images (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            // Lanzamos la navegación por el disco para la lectura del fichero de imágenes
            if (ofdFichero.ShowDialog() == DialogResult.OK) pbxImagen.Image = new System.Drawing.Bitmap(ofdFichero.FileName);
        }

        // Método asociado al botón btnGrabar. Graba la imagen del PictureBox en una base de datos
        private void btnGrabarBD_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametroImagen;
            MemoryStream stream = new MemoryStream();
            byte[] imagen = null;

            // Comprobamos si hay una imagen en el PictureBox
            if (pbxImagen.Image != null)
            {
                // Pasamos la imagen del PictureBox a un stream en memoria
                pbxImagen.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Volvamos el stream a un array de bytes
                imagen = stream.ToArray();

                // Establecemos el parámetro de la conexión
                comando.Connection = conexion;

                // Establecemos la orden, con parámetros
                comando.CommandText = "INSERT INTO TImagenes VALUES (@pImagen)";

                // Definimos el parámetro con su tipo de dato
                parametroImagen = new SqlParameter("pImagen", SqlDbType.Image);

                // Damos valor al parámetro
                parametroImagen.Value = imagen;

                // Añado el parámetro al comando
                comando.Parameters.Add(parametroImagen);

                // Ejecutamos la orden SQL
                try
                {
                    comando.ExecuteNonQuery();
                    pbxImagen.Image = null;
                }
                catch
                {
                    MessageBox.Show("No se pueden insertar los datos", "Error de Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  
        }      
    }
}
