using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmpleadoModel
    {
        EmpleadoDAO EmpleadoDAO = new EmpleadoDAO();
        public bool Check(string CI)
        {
            return EmpleadoDAO.Check(CI);
        }
        public bool registrarEmpleado(string cedula, string nombres, string apellidos, BindingList<TelefonoEmpleado> telefonos)
        {
            return EmpleadoDAO.registrarEmpleado(cedula, nombres, apellidos, telefonos);
        }
    }
}
