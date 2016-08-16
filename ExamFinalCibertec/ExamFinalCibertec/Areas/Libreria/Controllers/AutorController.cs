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
    public class AutorController : Controller
    {
        private readonly AutorRepositorio _autorRepositorio;
        public AutorController(AutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            return View(_autorRepositorio.ObtenerListadoDto());
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(Autor autor)
        {
            if (!ModelState.IsValid) return View(autor);
            _autorRepositorio.Agregar(autor);
            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Modificar(int id)
        {
            var autor = _autorRepositorio.ObtenerPorId(id);
            if (autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View("Modificar", autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Modificar(Autor autor)
        {
            if (!ModelState.IsValid) return View("Modificar", autor);
            _autorRepositorio.Modificar(autor);
            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var autor = _autorRepositorio.ObtenerPorId(id);
            _autorRepositorio.Eliminar(autor);
            return RedirectToAction("Index");
        }
        private int TotalPages(int? size)
        {
            var rows = _autorRepositorio.contar();
            var totalPages = rows / size.Value;
            return totalPages;
        }
    }
}