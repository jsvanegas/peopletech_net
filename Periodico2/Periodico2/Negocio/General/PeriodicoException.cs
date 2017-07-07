using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Negocio.General
{
    public class PeriodicoException : Exception
    {
        public PeriodicoException(string message, Exception ex) : base(message, ex)
        {
            //GUARDAR EN LOG
        }
    }
}