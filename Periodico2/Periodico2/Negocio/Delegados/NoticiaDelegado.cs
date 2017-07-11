using Periodico2.Negocio.General;
using Periodico2.Persistencia.Conexion;
using Periodico2.Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Negocio.Delegados
{
    public class NoticiaDelegado : IDelegadoDatos<NOTICIA>
    {

        private NoticiaDAO noticiaDAO;
        public NoticiaDelegado(PeriodicoEntities cnn)
        {
            this.noticiaDAO = new NoticiaDAO(cnn);
        }

        public int Actualizar(NOTICIA entidad)
        {
            throw new NotImplementedException();
        }

        public NOTICIA ConsultarPorId(int idEntidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NOTICIA> ConsultarTodos()
        {
            try
            {
                return this.noticiaDAO.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw new PeriodicoException("Error al consultar las noticias", ex);
            }
        }

        public int Eliminar(int idEntidad)
        {
            throw new NotImplementedException();
        }

        public int Insertar(NOTICIA entidad)
        {
            throw new NotImplementedException();
        }
    }
}