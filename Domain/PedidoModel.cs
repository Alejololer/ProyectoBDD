using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PedidoModel
    {
        PedidoDAO pedidoDAO = new PedidoDAO();
        public void RegistrarPedido(string CI)
        {
            pedidoDAO.registrarPedido(CI);
        }

        public bool Check(string CI)
        {
            return pedidoDAO.Check(CI);
        }

        public Pedido ObtenerPedido(string CI)
        {
            return pedidoDAO.ObtenerPedidoCI(CI);
        }

        public void EliminarPedido(string CI)
        {
            pedidoDAO.eliminarPedido(CI);
        }
    }
}
