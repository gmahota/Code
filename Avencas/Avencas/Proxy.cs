using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BServices;

namespace Avencas
{
    [ComVisible(true)]
    [Guid("384A53F1-FEAC-4CFA-ABB8-D100A2E75195")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Proxy
    {
        public string daNomeEmpresa(string empresa, string userName, string password, int tipoPlataforma)
        {
            ClsAvenca avenca = new ClsAvenca(userName, password, empresa, tipoPlataforma);

            return avenca.daNomeEmpresa();
        }
    }

    [ComVisible(true)]
    [Guid("CB9CDA01-4581-4B9F-B77E-D7F5ACC7F3D1")]
    public interface IProxy
    {
        string daNomeEmpresa(string empresa, string userName, string password, int tipoPlataforma);
    }
}
