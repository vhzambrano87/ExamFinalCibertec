using System;
using System.Collections.Generic;
using AutoMapper;
using ExamFinalCibertec.Model;
using ExamFinalCibertec.Model.DTO;

namespace ExamFinalCibertec.AccesoDatos
{
    public class Automapper
    {
        private static readonly MapperConfiguration _config = null;
        private static readonly object padlock = new object();

        static Automapper()
        {
            _config = SetAutomapperConfig();
        }

        private static MapperConfiguration SetAutomapperConfig()
        {
            lock (padlock)
            {
                return _config ?? new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Autor, AutorModelView>()
                        .IgnoreAllPropertiesWithAnInaccessibleSetter();

                    cfg.CreateMap<Libro, LibroModelView>();
                });
            }
        }


        public static IEnumerable<R> GetGeneric<T, R>(IEnumerable<T> objectList)
        {
            var mapper = _config.CreateMapper();
            return mapper.Map<IEnumerable<T>, List<R>>(objectList);
        }

        public static R GetGeneric<T, R>(T keyDocumentParent)
        {
            var mapper = _config.CreateMapper();
            return mapper.Map<T, R>(keyDocumentParent);
        }
    }
}
