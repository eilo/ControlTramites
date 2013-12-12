using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ControlTramites
{
    public class DALCliente
    {
        public static int Agregar(Cliente pCliente)
        {

            int retorno = 0;
            MySqlConnection conexion = DALdbcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into clientes (Nombre, Apellido, Cedula, Clave) values ('{0}','{1}','{2}','{3}')",
                pCliente.Nombre, pCliente.Apellido, pCliente.Cedula, pCliente.Clave), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<Cliente> Buscar(string pNombre, string pApellido)
        {
            List<Cliente> _lista = new List<Cliente>();
            MySqlConnection conexion = DALdbcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT IdCliente, Nombre, Apellido, Cedula, Clave FROM clientes  where Nombre ='{0}' or Apellido='{1}'",
                pNombre, pApellido), conexion);
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

        public static Cliente ObtenerCliente(int pId)
        {
            Cliente pCliente = new Cliente();
            MySqlConnection conexion = DALdbcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT IdCliente, Nombre, Apellido, Cedula, Clave FROM clientes where IdCliente={0}",
                pId), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Cedula = _reader.GetString(3);
                pCliente.Clave = _reader.GetString(4);

            }

            conexion.Close();
            return pCliente;

        }

        public static int Actualizar(Cliente pCliente)
        {
            int retorno = 0;
            MySqlConnection conexion = DALdbcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update clientes set Nombre='{0}', Apellido='{1}', Cedula='{2}', Clave='{3}' where IdCliente={4}",
                pCliente.Nombre, pCliente.Apellido, pCliente.Cedula, pCliente.Clave, pCliente.Id), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }
    }
}
