using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ParametroTipoExamenModel
    {
        ParametroTipoExamenDOA parametroTipoExamenDOA = new ParametroTipoExamenDOA(); 
        public void registrarParTipoExamenNull(int IDTipoExamen, string nombre)
        {
            parametroTipoExamenDOA.registrarParTipoExamenNull(IDTipoExamen, nombre);
        }

        public void registrarParTipoExamen(int IDTipoExamen, string nombre, float min, float max, string unidades)
        {
            parametroTipoExamenDOA.registrarParTipoExamen(IDTipoExamen, nombre, min, max, unidades);
        }

        public void registrarParTipoExamenRango(int IDTipoExamen, string nombre, float min, float max)
        {
            parametroTipoExamenDOA.registrarParTipoExamenRango(IDTipoExamen, nombre, min, max);
        }

        public void registrarParTipoExamenUnidad(int IDTipoExamen, string nombre, string unidades)
        {
            parametroTipoExamenDOA.registrarParTipoExamenUnidad(IDTipoExamen , nombre, unidades);   
        }
    }
}
