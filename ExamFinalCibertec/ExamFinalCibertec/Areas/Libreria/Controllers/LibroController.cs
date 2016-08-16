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
using ExamFinalCibertec.Model.DTO;

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

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(Libro libro)
        {
            if (!ModelState.IsValid)
                return View(libro);
            _libroRepositorio.Agregar(libro);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
           return RedirectToAction("Index");
        }
        
        public ActionResult Modificar(int id)
        {           
           return View(_libroRepositorio.ObtenerPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Modificar(Libro libro)
        {
            if (!ModelState.IsValid) return View("Modificar", libro);
            _libroRepositorio.Modificar(libro);
            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var libro = _libroRepositorio.ObtenerPorId(id);
            _libroRepositorio.Eliminar(libro);
            return RedirectToAction("Index");
        }
        private int TotalPages(int? size)
        {
            var rows = _libroRepositorio.contar();
            var totalPages = rows / size.Value;
            return totalPages;
        }
    }
}