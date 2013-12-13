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
        public UILClientes()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //metodo para cargar los datos de la bd
        public static List<Cliente> Datos()
        {
            List<Cliente> _lista = new List<Cliente>();
            MySqlConnection conexion = DALdbcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT IdCliente, Nombre, Apellido, Cedula, Clave FROM clientes  where Nombre ='{0}' or Apellido='{1}'"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Cedula = _reader.GetString(3);
                pCliente.Clave = _reader.GetString(4);


                _lista.Add(pCliente);
            }

            return _lista;
        }

        //metodo para cargar la coleccion de datos para el autocomplete
        public static AutoCompleteStringCollection Autocomplete()
        {
            DataTable dt = Datos();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["pais"]));
            }

            return coleccion;
        }
    }
}
