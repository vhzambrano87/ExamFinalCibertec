using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExamFinalCibertec.AccesoDatos;
using ExamFinalCibertec.Model;

namespace ExamFinalCibertec.Areas.Libreria.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private LibroRepositorio _libroRepositorio;
        public LibroController(LibroRepositorio libroRepositorio)
        {
            _libroRepositorio = libroRepositorio;
        }

        public ActionResult Index()
        {
            return View(_libroRepositorio.ObtenerListadoDto());
        }

        public ActionResult Listar()
        {
            return PartialView("_Listar", _libroRepositorio.ObtenerListadoDto());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(Libro libro)
        {
            if (!ModelState.IsValid) return PartialView("_Registrar", libro);
            _libroRepositorio.Agregar(libro);
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Modificar(int id)
        {
            var libro = _libroRepositorio.ObtenerPorId(id);
            if (libro == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Modificar", libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Modificar(Libro libro)
        {
            if (!ModelState.IsValid) return PartialView("_Modificar", libro);
            _libroRepositorio.Modificar(libro);
            return RedirectToRoute("Libreria_default");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var libro = _libroRepositorio.ObtenerPorId(id);
            if (libro == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Eliminar", libro);
        }
        private int TotalPages(int? size)
        {
            var rows = _libroRepositorio.contar();
            var totalPages = rows / size.Value;
            return totalPages;
        }
    }
}