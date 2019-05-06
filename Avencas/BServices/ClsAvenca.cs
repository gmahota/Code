using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BServices
{
    public class ClsAvenca : Geral
    {
        public ClsAvenca(string userPrimavera, string passUserPrimavera, string empresa, int tipoEmpPRI):
            base(userPrimavera,  passUserPrimavera,  empresa, tipoEmpPRI)
        {

        }

        public string daNomeEmpresa()
        {
            return bso.Contexto.IDNome;
        }
    }
}
