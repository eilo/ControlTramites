using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlTramites
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Clave { get; set; }

        public Cliente() { }

        public Cliente(int pId, string pNombre, string pApellido, string pCedula, string pClave)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Cedula = pCedula;
            this.Clave = pClave;
        }
    }
}
