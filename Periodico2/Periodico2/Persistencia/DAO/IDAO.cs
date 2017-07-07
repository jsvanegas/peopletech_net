using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodico2.Persistencia.DAO
{
    interface IDAO<T>
    {
        int Insertar(T entidad);
        int Actualizar(T entidad);
        int Eliminar(int idEntidad);
        IEnumerable<T> ConsultarTodos();
        T ConsultarPorId(int idEntidad);
    }
}
