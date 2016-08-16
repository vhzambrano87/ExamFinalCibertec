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
            ViewBag.Count = TotalPages(10);
            return View();
        }

        [OutputCache(Duration = 0)]
        public ActionResult Listar()
        {            
            return PartialView("_Listar", _autorRepositorio.ObtenerListadoDto());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(Autor autor)
        {
            if (!ModelState.IsValid) return PartialView("_Registrar", autor);
            _autorRepositorio.Agregar(autor);
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Modificar(int id)
        {
            var autor = _autorRepositorio.ObtenerPorId(id);
            if (autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Modificar", autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Modificar(Autor autor)
        {
            if (!ModelState.IsValid) return PartialView("_Modificar", autor);
            _autorRepositorio.Modificar(autor);
            return RedirectToRoute("Libreria_default");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var autor = _autorRepositorio.ObtenerPorId(id);
            if (autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Eliminar", autor);
        }
        private int TotalPages(int? size)
        {
            var rows = _autorRepositorio.contar();
            var totalPages = rows / size.Value;
            return totalPages;
        }
    }
}