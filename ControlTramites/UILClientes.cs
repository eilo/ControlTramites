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

        public UILClientes()
        {
            InitializeComponent();
            // esto deberia estar en el load o algo asi, o correrse cada vez que abre la ventana / show
            //cargar los datos para el autocomplete del textbox
            textBox1.AutoCompleteCustomSource = UILClientes.Autocomplete();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        //metodo para cargar los datos de la bd
        public static DataTable CacheDatos()
        {
            DataTable dt = new DataTable();
            MySqlConnection cn = new MySqlConnection("server=127.0.0.1; database=controltramites; Uid=root; pwd=mimamamemima1987;");

            try
            {
                string sqlCmd = "SELECT IdCliente, Nombre, Apellido, Cedula, Clave FROM clientes";

                MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
                adr.SelectCommand.CommandType = CommandType.Text;

                adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)
            }
            catch (Exception ex)
            {
                Console.WriteLine("{oops - {0}", ex.Message);
            }
            finally
            {
                cn.Dispose(); // return connection to pool
            }

            return dt;
        }

        //metodo para cargar la coleccion de datos para el autocomplete
        public static AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = CacheDatos();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                string item = Convert.ToString(row["Apellido"]) + " " + Convert.ToString(row["Nombre"]);
                MessageBox.Show(item);
                coleccion.Add(item);
            }

            return coleccion;
        }
    }
}
