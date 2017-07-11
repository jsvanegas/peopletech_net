using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Negocio.Util
{
    public class Validacion
    {

        public static bool ValidarSrtrings(params string[] parametros) {
            for (int i = 0; i < parametros.Length; i++)
            {
                if (string.IsNullOrEmpty(parametros[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}