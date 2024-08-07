using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public Producto(int id, string nombre, float precio)
        {
            Nombre = nombre;
            Precio = precio;
            Id = id;
        }
        public Producto(int id, string nombre, float precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
