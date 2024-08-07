using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ParametroTipoExamen
    {
        public int Id { get; set; }
        public string nombreParametro { get; set;}
        public float minParametro {  get; set;}
        public float maxParametro { get; set;}
        public string unidad {  get; set;}

        public ParametroTipoExamen(string nombreParametro, float minParametro, float maxParametro, string unidad)
        {
            this.nombreParametro = nombreParametro;
            this.minParametro = minParametro;
            this.maxParametro = maxParametro;
            this.unidad = unidad;
        }
    }
}
