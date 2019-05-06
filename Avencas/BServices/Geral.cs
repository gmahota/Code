using Interop.ErpBS900;
using Interop.StdBE900;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BServices
{
    public class Geral
    {
        public ErpBS bso { get; set; }

        public Geral(ErpBS bso)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            this.bso = bso;
        }

        public Geral(string userPrimavera, string passUserPrimavera, string empresa, int tipoEmpPRI)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AbrirMotorPrimavera(userPrimavera, passUserPrimavera, empresa, tipoEmpPRI);
        }

        public Boolean AbrirMotorPrimavera(string userPrimavera, string passUserPrimavera, string empresa, int tipoEmpPRI)
        {
            try
            {
                bso = new ErpBS();

                bso.AbreEmpresaTrabalho(tipoEmpPRI == 0 ? EnumTipoPlataforma.tpEmpresarial : EnumTipoPlataforma.tpProfissional,
                        ref empresa, ref userPrimavera, ref passUserPrimavera);

                //AbrePlataforma(bso);

                return bso.Contexto.EmpresaAberta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        #region Resolução de Assemblies
        /// <summary>
        /// Método para resolução das assemblies.
        /// </summary>
        /// <param name="sender">Application</param>
        /// <param name="args">Resolving Assembly Name</param>
        /// <returns>Assembly</returns>
        public static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;
            System.Reflection.AssemblyName assemblyName;
            string PRIMAVERA_COMMON_FILES_FOLDER = "PRIMAVERA\\SG900";//pasta dos ficheiros comuns especifica da versão do ERP PRIMAVERA utilizada.
            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86), PRIMAVERA_COMMON_FILES_FOLDER), assemblyName.Name + ".dll");
            if (System.IO.File.Exists(assemblyFullName))
                return System.Reflection.Assembly.LoadFile(assemblyFullName);
            else
                return null;
        }
        #endregion


    }
}
