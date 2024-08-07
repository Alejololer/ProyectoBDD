using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Examen
    {
        public int Id { get; set; }
        public int IdTipoExamen { get; set; }
        public int IdPedido { get; set; }
        public string estadoExamen { get; set; }
        public string nombreTipoExamen { get; set; }
        public decimal costoTipoExamen { get; set; }


        public Examen(int id, int idTipoExamen, int idPedido, string estadoExamen)
        {
            Id = id;
            IdTipoExamen = idTipoExamen;
            IdPedido = idPedido;
            this.estadoExamen = estadoExamen;
        }

        public Examen(int id, string nombreTipoExamen, decimal costoTipoExamen, string estadoExamen)
        {
            Id = id;
            this.nombreTipoExamen = nombreTipoExamen;
            this.costoTipoExamen = costoTipoExamen;
            this.estadoExamen = estadoExamen;
        }
    }
}
