using System.Collections.Generic;

namespace ExamFinalCibertec.AccesoDatos
{
    public interface IAccesoDatos<T>
    {
        List<T> ObtenerListado();
        int Agregar(T entity);
        int Eliminar(T entity);
        int Modificar(T entity);
        int contar();
    }
}
