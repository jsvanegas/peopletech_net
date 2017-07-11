using Periodico2.Persistencia.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Persistencia.DAO
{
    public class GenericoDAO
    {
        protected PeriodicoEntities cnn;

        public GenericoDAO(PeriodicoEntities cnn)
        {
            this.cnn = cnn;
        }
    }
}