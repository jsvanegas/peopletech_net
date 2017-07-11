using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Negocio.General
{
    public class Respuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public void AsignarRespuestaConsultaLista(IList datos) {
            if (datos.Count>0)
            {
                this.Codigo = 1;
                this.Datos = datos;
                this.Mensaje = "Consulta Completa";
                return;
            }
            this.Codigo = 0;
            this.Mensaje = "No se encontraron resultados";
            this.Datos = null;
        }

        public void AsignarRespuestaError(PeriodicoException ex) {
            this.Codigo = -1;
            this.Mensaje = ex.Message;
        }

        public void AsignarRespuestaInsercion()
        {
            this.Codigo = 1;
            this.Mensaje = "Se registro correctamente";
        }
    }
}