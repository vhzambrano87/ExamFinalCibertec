using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExamFinalCibertec.AccesoDatos
{
    public class AccesoDatosBase<T> : IAccesoDatos<T> where T : class
    {
        public int Agregar(T entity)
        {
            using (var dbContext = new WebContextDb())
            {
                dbContext.Entry(entity).State = EntityState.Added;
                return dbContext.SaveChanges();
            }
        }

        public int Eliminar(T entity)
        {
            using (var dbContext = new WebContextDb())
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
                return dbContext.SaveChanges();
            }
        }

        public List<T> ObtenerListado()
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Set<T>().ToList();
            }
        }

        public int Modificar(T entity)
        {
            using (var dbContext = new WebContextDb())
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }

        public int contar()
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Set<T>().Count();
            }
        }
    }
}
