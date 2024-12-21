using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagenBD_PB
{
    public partial class FrmInicial : Form
    {
        SqlConnection conexion;

        public FrmInicial()
        {
            InitializeComponent();
        }
        
        // Método asociado al evento de carga del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "Server=ADTSERVER; DATABASE=adtjoaquinBDImagenes; Trusted_Connection=yes;";

            // Creamos el objeto conexión, pasándole la cadena de conexión
            conexion = new SqlConnection(cadenaConexion);

            try
            {
                // Intentamos la conexión
                conexion.Open();

                // Cargamos el ListBox con los id de las imágenes
                cargarListBox();
            }
            catch
            {
                MessageBox.Show("Imposible realizar la conexión con la base de datos. Se cancela el programa", "Error de Aplicacion", MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSalir.PerformClick();
            }
        }

        // Método asociado al botón btnSalir. Finaliza la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (conexion != null) conexion.Close();     // Si la conexión está abierta, la cerramos
            this.Close();                               // Cerramos el formulario
        }

        // Método asociado a seleccionar un Item en el ListBox
        private void lbxIdImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametroImagen;
            SqlDataReader lector;
            SqlBinary imagen = new SqlBinary();     // Requiere using System.Data.SqlTypes;    
            MemoryStream ms = new MemoryStream();   // Requiere using System.IO;
            Bitmap mapaBits;

            // Establecemos el parámetro de la conexión
            comando.Connection = conexion;

            // Establecemos la orden, con parámetros
            comando.CommandText = "SELECT Imagen FROM TImagenes WHERE idImagen = @pImagen";

            // Definimos los parámetros con su tipo de dato
            parametroImagen = new SqlParameter("pImagen", SqlDbType.Int);

            // Damos valor al parámetro
            parametroImagen.Value = lbxIdImagenes.SelectedItem;

            // Añado el parámetro al comando
            comando.Parameters.Add(parametroImagen);

            try
            {
                // Ejecutamos el comando y recogemos un apuntador a los datos leidos
                lector = comando.ExecuteReader();

                // Leemos la fila, que será única, no puede haber dos imágenes con el mismo identificador
                lector.Read();

                // Cargamos los datos
                imagen = lector.GetSqlBinary(0);

                // La pasamos al Memory Stream
                ms.Write(imagen.Value, 0, imagen.Length);

                // Generamos el mapa de bits
                mapaBits = new Bitmap(ms);

                // Lo pasamos al PictureBox
                pbxImagen.Image = mapaBits;

                // Cerramos el lector
                lector.Close();
            }
            catch
            {
                MessageBox.Show("No se pueden mostrar los datos", "Error de Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }              
        } 
    
            // Carga el ListBox con los identificadores de las imágenes
        private void cargarListBox()
        {
            SqlDataReader lector;
            SqlCommand comando = new SqlCommand();
            
            // Establecemos el parámetro de la conexión
            comando.Connection = conexion;

            // Establecemos la orden, con parámetros
            comando.CommandText = "SELECT idImagen FROM TImagenes";
          
            try
            {
                // Ejecutamos el comando y recogemos un apuntador a los datos leidos
                lector = comando.ExecuteReader();
                
                // Si el lector ha leido datos
                if (lector.HasRows)
                {
                    // Leemos todas las filas de la tabla
                    while (lector.Read())
                    {
                        // Cargamos los datos en el ListBox
                        lbxIdImagenes.Items.Add(lector.GetInt32(0));
                    }

                    // Cerramos el lector
                    lector.Close();

                    // Seleccionamos el primer elemento del ListBox: Evento SelectedIndezChanged
                    lbxIdImagenes.SetSelected(0, true);
                }
                else MessageBox.Show("No se pueden encontrar datos", "Aviso de Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch
            {
                MessageBox.Show("No se pueden mostrar los datos", "Error de Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                   
        }
    }
}
