using Periodico2.Negocio.Delegados;
using Periodico2.Persistencia.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Periodico2.Negocio
{
    public class TemaController : ApiController
    {
        [HttpPost, HttpGet]
        [Route("temas/todos")]
        public IEnumerable<TEMA> ConsultarTemas() {
            using (var cnn = new PeriodicoEntities())
            {
                TemaDelegado delegado = new TemaDelegado(cnn);
                return delegado.ConsultarTodos();
            }
        }

    }
}
