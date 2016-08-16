using System.Collections.Generic;
using System.Linq;
using ExamFinalCibertec.Model;
using ExamFinalCibertec.Model.DTO;
using System.Data.Entity;

namespace ExamFinalCibertec.AccesoDatos
{
    public class AutorRepositorio : AccesoDatosBase<Autor>
    {
        public List<AutorModelView> ObtenerListadoDto()
        {
            using (var db = new WebContextDb())
            {
                return Automapper.GetGeneric<List<Autor>,
                                             List<AutorModelView>>(
                                            db.Autor.Take(10).ToList()
                                            );
            }
        }
        public Autor ObtenerPorId(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.AutorPorId(id);
            }
        }

        
    }
    public static class AutorExtensions
    {
        public static Autor AutorPorId(this WebContextDb context, int id)
        {
            return context.Autor
               .FirstOrDefault(c => c.autorId == id);
        }

    }
}
