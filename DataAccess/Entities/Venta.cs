using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int idPedido { get; set; }
        public string CIPaciente { get; set; }
        public decimal precioFinalNoIVA { get; set; }
        public decimal precioFinalIVA { get; set; }
        public decimal ventaIVA { get; set; }

        public decimal precioFinalMod {  get; set; }
        public string fechaVenta { get; set; }
        
        public Venta(int id, int idPedido, string CIPaciente, decimal precioFinalNoIVA, decimal precioFinalIVA, decimal ventaIVA)
        {
            this.Id = id;
            this.idPedido = idPedido;
            this.CIPaciente = CIPaciente;
            this.precioFinalNoIVA = precioFinalNoIVA;
            this.precioFinalIVA = precioFinalIVA;
            this.ventaIVA = ventaIVA;
        }

        public Venta( int idPedido, string CIPaciente, decimal precioFinalNoIVA, decimal precioFinalIVA, decimal ventaIVA)
        {
            this.idPedido = idPedido;
            this.CIPaciente = CIPaciente;
            this.precioFinalNoIVA = precioFinalNoIVA;
            this.precioFinalIVA = precioFinalIVA;
            this.ventaIVA = ventaIVA;
        }

        public Venta(int Id, int idPedido, string CIPaciente, decimal precioTotal, decimal precioFInal, string fecha)
        {
            this.Id = Id;
            this.idPedido= idPedido;
            this.CIPaciente= CIPaciente;
            precioFinalIVA = precioTotal;
            precioFinalMod = precioFInal;
            fechaVenta = fecha; 
        }
    }
}
