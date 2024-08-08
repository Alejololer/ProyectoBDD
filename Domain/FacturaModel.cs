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
    public class FacturaModel
    {
        FacturaDAO facturaDAO = new FacturaDAO();

        public bool registrarFactura(decimal total, string cedula_empleado, string cedula_cliente, BindingList<DetalleFactura> detalles)
        {
            return facturaDAO.ExecuteInsertFacturaSP(total, cedula_empleado, cedula_cliente, detalles);
        }

        public bool Check (int id)
        {
            return facturaDAO.Check(id);
        }
    }
}
