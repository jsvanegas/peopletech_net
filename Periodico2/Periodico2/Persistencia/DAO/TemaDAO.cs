using Periodico2.Persistencia.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Persistencia.DAO
{
    public class TemaDAO : IDAO<TEMA>
    {
        private PeriodicoEntities cnn;

        public TemaDAO(PeriodicoEntities cnn) {
            this.cnn = cnn;
        }
        
        public int Actualizar(TEMA entidad)
        {
            var temaAnterior = this.ConsultarPorId(entidad.ID_TEMA);
            temaAnterior.TEMA1 = entidad.TEMA1;
            temaAnterior.ICONO = entidad.ICONO;
            return cnn.SaveChanges();
        }

        public TEMA ConsultarPorId(int idEntidad)
        {
            return cnn.TEMA.SingleOrDefault(t => t.ID_TEMA.Equals(idEntidad));
        }

        public IEnumerable<TEMA> ConsultarTodos()
        {
            return cnn.TEMA.ToList();
        }

        public int Eliminar(int idEntidad)
        {
            var entidad = this.ConsultarPorId(idEntidad);
            cnn.TEMA.Remove(entidad);
            return cnn.SaveChanges();
        }

        /// <summary>
        /// Inserta un nuevo tema en la tabla de temas 
        /// </summary>
        /// <param name="entidad">Objeto de la clase Tema</param>
        /// <returns>Id del tema insertado</returns>
        public int Insertar(TEMA entidad)
        {
            cnn.TEMA.Add(entidad);
            cnn.SaveChanges();
            return entidad.ID_TEMA;
        }
        
    }
}