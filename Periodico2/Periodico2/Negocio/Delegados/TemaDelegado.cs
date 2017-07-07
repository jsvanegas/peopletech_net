using Periodico2.Negocio.General;
using Periodico2.Persistencia.Conexion;
using Periodico2.Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Negocio.Delegados
{
    public class TemaDelegado : IDelegadoDatos<TEMA>
    {
        private TemaDAO temaDAO;

        public TemaDelegado(PeriodicoEntities cnn) {
            this.temaDAO = new TemaDAO(cnn);
        }

        public int Actualizar(TEMA entidad)
        {
            throw new NotImplementedException();
        }

        public TEMA ConsultarPorId(int idEntidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEMA> ConsultarTodos()
        {
            try
            {
                return temaDAO.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw new PeriodicoException("Error al consultar", ex);
            }
        }

        public int Eliminar(int idEntidad)
        {
            throw new NotImplementedException();
        }

        public int Insertar(TEMA entidad)
        {
            try
            {
                //validar la entidad
                return temaDAO.Insertar(entidad);
            }
            catch (Exception ex)
            {
                throw new PeriodicoException(Mensajes.Errores.ERROR_INSERTAR_TEMA, ex);
            }
        }
    }
}