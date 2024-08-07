using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class IVA
    {
        public int valor { get; set; }
        public string fecha { get; set; }

        public IVA(int valor)
        {
            this.valor = valor;
        }
    }
}
