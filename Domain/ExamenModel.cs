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
    public class ExamenModel
    {
        ExamenDAO examenDAO = new ExamenDAO();
        public void registrarExamenesPedido(Pedido pedido, BindingList<TipoExamen> tipos)
        {
            examenDAO.registrarExamenesPedido(pedido, tipos);
        }


        public void EliminarExamenID(int idExamen)
        {
            examenDAO.EliminarExamenID(idExamen);
        }
        
        public void registrarExamenPedido(Pedido pedido, TipoExamen tipo)
        {
            examenDAO.registrarExamenPedido(pedido, tipo);
        }

        public BindingList<Examen> ObtenerExamenesPedido(int idPedido) { 
            return examenDAO.obtenerExamenesPedido(idPedido);
        }
    }
}
