using Periodico2.Negocio.Delegados;
using Periodico2.Negocio.General;
using Periodico2.Persistencia.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Periodico2.Negocio.Controllers
{
    public class NoticiaController : ApiController
    {
        [HttpGet]
        [Route("noticias/todas")]
        public Respuesta ConsultarNoticias() {
            var respuesta = new Respuesta();
            try
            {
                using (var cnn = new PeriodicoEntities())
                {
                    respuesta.AsignarRespuestaConsultaLista(new NoticiaDelegado(cnn).ConsultarTodos().ToList());
                }
            }
            catch (PeriodicoException ex)
            {
                respuesta.AsignarRespuestaError(ex);
            }
            return respuesta;
        }


    }
}
