using System.Collections.Generic;
using System.Linq;
using ExamFinalCibertec.Model;
using ExamFinalCibertec.Model.DTO;
using System.Data.Entity;

namespace ExamFinalCibertec.AccesoDatos
{
    public class LibroRepositorio : AccesoDatosBase<Libro>
    {
        public List<LibroModelView> ObtenerListadoDto()
        {
            using (var db = new WebContextDb())
            {
                return Automapper.GetGeneric<List<Libro>,
                                             List<LibroModelView>>(
                                            db.Libro.Take(10).ToList()
                                            );
            }
        }

        public Libro ObtenerPorId(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.LibroPorId(id);
            }
        }
    }
    public static class LibroExtensions
    {
        public static Libro LibroPorId(this WebContextDb context, int id)
        {
            return context.Libro
                .FirstOrDefault(c => c.libroId == id);
        }

    }
}
