using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DetalleFactura
    {
        public int numero_factura { get; set; }
        public int id_producto { get; set; }
        public int unidades { get; set; }
        public float precio_unitario { get; set; }
        public string nombre_producto { get; set; }

        public DetalleFactura(string nombre, int id_producto, int unidades, float precio_unitario)
        {
            nombre_producto = nombre;
            this.id_producto = id_producto;
            this.unidades = unidades;
            this.precio_unitario = precio_unitario;
        }

    }
}
