using Periodico2.Negocio.Delegados;
using Periodico2.Negocio.General;
using Periodico2.Negocio.Util;
using Periodico2.Persistencia.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Periodico2.Negocio.Controllers
{
    public class TemaController : ApiController
    {
        [HttpPost, HttpGet]
        [Route("temas/todos")]
        public Respuesta ConsultarTemas() {
            var respuesta = new Respuesta();
            try
            {
                using (var cnn = new PeriodicoEntities())
                {
                    TemaDelegado delegado = new TemaDelegado(cnn);
                    var listaTemas = delegado.ConsultarTodos();
                    respuesta.AsignarRespuestaConsultaLista(listaTemas.ToList());
                }
            }
            catch (PeriodicoException ex)
            {
                respuesta.AsignarRespuestaError(ex);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("temas/registrar")]
        public Respuesta InsertarTema(FormDataCollection data) {
            var respuesta = new Respuesta();
            try
            {
                using (var cnn = new PeriodicoEntities())
                {
                    var delegado = new TemaDelegado(cnn);
                    delegado.Insertar(obtenerEntidad(data));
                    respuesta.AsignarRespuestaInsercion();
                }
            }
            catch (PeriodicoException ex)
            {
                respuesta.AsignarRespuestaError(ex);
            }
            return respuesta;
        }

        private TEMA obtenerEntidad(FormDataCollection data)
        {
            if (Validacion.ValidarSrtrings(data["tema"], data["icono"]))
            {
                throw new PeriodicoException("La informacion del tema esta incompleta", null);
            }
            return new TEMA() { TEMA1 = data["tema"], ICONO = data["icono"] };
        }
    }
}
