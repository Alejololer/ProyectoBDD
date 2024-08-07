using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TipoExamen
    {
        public int Id { get; set; }
        public string nombreTipoExamen { get; set; }
        public decimal costoTipoExamen { get; set; }

        public TipoExamen(int id, string nombreTipoExamen, decimal costoTipoExamen)
        {
            Id = id;
            this.nombreTipoExamen = nombreTipoExamen;
            this.costoTipoExamen = costoTipoExamen;
        }

    }
}
