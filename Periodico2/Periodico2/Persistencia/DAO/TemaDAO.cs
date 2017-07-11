using Periodico2.Persistencia.Conexion;
using Periodico2.Persistencia.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Persistencia.DAO
{
    public class TemaDAO : GenericoDAO, IDAO<TEMA, TemaVO>
    {
        public TemaDAO(PeriodicoEntities cnn) : base(cnn)
        {
        }

        public int Actualizar(TEMA entidad)
        {
            var temaAnterior = this.ConsultarPorId(entidad.ID_TEMA);
            temaAnterior.TEMA1 = entidad.TEMA1;
            temaAnterior.ICONO = entidad.ICONO;
            return cnn.SaveChanges();
        }

        public TemaVO ConsultarPorId(int idEntidad)
        {
            var tema = cnn.TEMA.SingleOrDefault(t => t.ID_TEMA.Equals(idEntidad));
            return new TemaVO() {
                ID_TEMA = tema.ID_TEMA,
                TEMA1 = tema.TEMA1,
                ICONO = tema.ICONO
            };
        }

        public IEnumerable<TemaVO> ConsultarTodos()
        {
            return cnn.TEMA.Select(t=>new TemaVO {
                ID_TEMA = t.ID_TEMA,
                TEMA1 = t.TEMA1,
                ICONO = t.ICONO
            });
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