using Periodico2.Persistencia.Conexion;
using Periodico2.Persistencia.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodico2.Persistencia.DAO
{
    public class NoticiaDAO : GenericoDAO, IDAO<NOTICIA, NoticiaVO>
    {
        public NoticiaDAO(PeriodicoEntities cnn) : base(cnn)
        {
        }

        public int Actualizar(NOTICIA entidad)
        {
            throw new NotImplementedException();
        }

        public NoticiaVO ConsultarPorId(int idEntidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoticiaVO> ConsultarTodos()
        {
            return (from n in cnn.NOTICIA
                    join t in cnn.TEMA on n.ID_TEMA equals t.ID_TEMA
                    select new NoticiaVO
                    {
                        ID_NOTICIA = n.ID_NOTICIA,
                        TITULO = n.TITULO,
                        CONTENIDO = n.CONTENIDO,
                        FOTO = n.FOTO,
                        FECHA = n.FECHA,
                        TEMA = new TemaVO
                        {
                            ID_TEMA = t.ID_TEMA,
                            TEMA1 = t.TEMA1,
                            ICONO = t.ICONO
                        }
                    }).ToList();
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