using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CIPedido { get; set; }
        public string EstadoPedido { get; set; }

        public Pedido(int id, string cIPedido, string estadoPedido)
        {
            Id = id;
            CIPedido = cIPedido;
            EstadoPedido = estadoPedido;
        }

        public Pedido(string cIPedido)
        {
            CIPedido = cIPedido;
        }
    }
}
