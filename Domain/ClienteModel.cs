using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;

namespace Domain
{
    public class ClienteModel
    {
        ClienteDAO ClienteDAO = new ClienteDAO();

        public bool registrarCliente(string cedula, string nombres, string telefono, string direccion)
        {
            return ClienteDAO.registrarCliente(cedula, nombres, telefono, direccion);
        }

        public bool Check(string cedula)
        {
            return ClienteDAO.Check(cedula);
        }

        public Cliente obtenerClienteCI(string cedula)
        {
            return ClienteDAO.ObtenerClienteCI(cedula) ;
        }
        
        public void actualizarCliente(string cedula, string telefono, string direccion)
        {
            ClienteDAO.actualizarCliente(cedula, telefono, direccion);
        }
    }

}
