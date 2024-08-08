using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;

namespace Domain
{
    public class ProductoModel
    {
        ProductoDAO productoDAO = new ProductoDAO();

        public bool CheckLocal(int id)
        {
            return productoDAO.CheckLocal(id); 
        }

        public int CheckNombre(string Nombre)
        {
            return productoDAO.CheckNombre(Nombre);
        }
        public bool CheckStock(int id, int cantidad)
        {
            return productoDAO.CheckStock(id, cantidad);
        }
        public bool actualizarProductoStockExiste(int id, int stock)
        {
            return productoDAO.actualizarProductoStockExiste(id, stock);
        }
        public bool actualizarProductoStockNoExiste(int id, int stock)
        {
            return productoDAO.actualizarProductoStockNoExiste(id, stock);
        }
        public bool Check(string nombre)
        {
            return productoDAO.Check(nombre);
        }
        public bool registrarProductoNoStock(string nombre, float precio)
        {
            return productoDAO.registrarProductoNoStock(nombre, precio);
        }

        public bool registrarProductoStock(string nombre, float precio, int stock)
        {
            return productoDAO.registrarProductoStock(nombre, precio, stock);
        }
    }
}
