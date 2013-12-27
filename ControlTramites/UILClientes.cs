using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControlTramites
{
    public partial class UILClientes : Form
    {
        bool loaded;

        public UILClientes(MySqlConnection conexion)
        {
            InitializeComponent();
            // esto deberia estar en el load o algo asi, o correrse cada vez que abre la ventana / show
            //cargar los datos para el autocomplete del textbox
            textBox1.AutoCompleteCustomSource = UILClientes.Autocomplete(conexion);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        //metodo para cargar los datos de la bd
        public static DataTable CacheDatos(MySqlConnection conexion)
        {
            DataTable dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT IdCliente, Nombre, Apellido, Cedula, Clave FROM clientes", conexion);
                cmd.Prepare();
                //cmd.ExecuteNonQuery(); // este no es necesario debido a que el fill ejecuta las querys

                MySqlDataAdapter adr = new MySqlDataAdapter(cmd);
                adr.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{oops - {0}", ex.Message);
            }
            finally
            {
                conexion.Dispose(); // return connection to pool
            }

            return dt;
        }

        //metodo para cargar la coleccion de datos para el autocomplete
        public static AutoCompleteStringCollection Autocomplete(MySqlConnection conexion)
        {
            DataTable dt = CacheDatos(conexion);

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                string item = Convert.ToString(row["Apellido"]) + " " + Convert.ToString(row["Nombre"]);
                // MessageBox.Show(item); // debug de items
                coleccion.Add(item);
                string item2 = Convert.ToString(row["Nombre"]) + " " + Convert.ToString(row["Apellido"]);
                // MessageBox.Show(item2); // debug de items
                coleccion.Add(item2);
            }

            return coleccion;
        }
    }
}
