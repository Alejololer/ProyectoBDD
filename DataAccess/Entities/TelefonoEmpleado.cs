using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TelefonoEmpleado
    {
        public string cedula_empleado { get; set; }
        public string telefono { get; set; }
        public string tipo { get; set; }

        public TelefonoEmpleado(string telefono, string tipo)
        {
            this.telefono = telefono;
            this.tipo = tipo;
        }
    }
}
