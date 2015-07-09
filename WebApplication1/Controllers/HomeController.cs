using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Infra;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Repositorio repositorio = new Repositorio();

        public ActionResult Index()
        {
            var letras = repositorio.Letras.ToList();
            return View(letras);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var entidade = Get(id);
                return View(entidade);
            }

            return View(new Letra());
        }

        [HttpPost]
        public ActionResult Edit(Letra entidade)
        {
            if (entidade.Id == 0) // insert
            {
                repositorio.Letras.Add(entidade);
            }
            else // update
            {
                repositorio.Entry(entidade).State = EntityState.Modified;  
            }

            repositorio.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var letra = Get(id);
            repositorio.Entry(letra).State = EntityState.Deleted;
            repositorio.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sample()
        {
            return View();
        }

        private Letra Get(int? id)
        {
            var letra = repositorio.Letras.FirstOrDefault(e => e.Id == id);
            return letra;
        }
    }
}