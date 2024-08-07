using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class IVAModel
    {
        IVADAO ivadao = new DataAccess.IVADAO();
        public IVA getIVA()
        {
            return ivadao.getIVA();
        }

        public bool registrarIVA(int valor)
        {
            return ivadao.registrarIVA(valor);
        }
    }
}
