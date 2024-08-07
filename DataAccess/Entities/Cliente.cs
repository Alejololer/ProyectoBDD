using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Cliente
    {
        public string CICliente { get; set; }
        public string nombresCliente { get; set; }
        public string telefonoCliente { get; set; }
        public string direccionClientee { get; set; }
        public int idSucursalCliente { get; set; }

        public Cliente() { }

        public Cliente(string cedula, string nombre, string telefono, string direccion, int idSucursal)
        {
            CICliente= cedula;
            nombresCliente = nombre;
            telefonoCliente = telefono;
            direccionClientee = direccion;
            idSucursalCliente = idSucursal;
        }
    }
}
