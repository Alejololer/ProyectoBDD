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
    public class VentaModel
    {
        VentaDAO ventaDAO = new VentaDAO();
        public bool Check(int IdPedido)
        {
            return ventaDAO.Check(IdPedido);
        }
        public Venta consultarDatosVenta(string cedula, int idpedido, int IVA)
        {
            return ventaDAO.consultarDatosVenta(cedula, idpedido, IVA);
        }

        public void registrarVenta(Venta venta)
        {
            ventaDAO.registrarVenta(venta);
        }

        public void registrarVentaMod(Venta venta, decimal mod)
        {
            ventaDAO.registrarVenta(venta, mod);
        }

        public BindingList<Venta> ObtenerVentasCI(string CI)
        {
            return ventaDAO.ObtenerVentasCI(CI);
        }

        public void AnularVenta(int id)
        {
            ventaDAO.AnularVenta(id);
        }
    }
}
