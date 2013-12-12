using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ControlTramites
{
    public class DALdbcomun
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=controltramites; Uid=root; pwd=mimamamemima1987;");

            conectar.Open();
            return conectar;
        }
    }
}
