using SiteLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteLoja.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [HttpGet]
        public ActionResult List()
        {
            var categorias = new LojaRoupasEntities2().Categorias.ToList();
            return View(categorias);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //estancia a classe do banco
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var categoria = banco.Categorias
                .Where(x => x.ID == id).SingleOrDefault();

            return View(categoria);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            var categoria = banco.Categorias
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Categorias.Remove(categoria);
            banco.SaveChanges();

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            banco.Categorias.Add(categoria);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = categoria.ID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var categoria = banco.Categorias.Where(
                w => w.ID == id).SingleOrDefault();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var categoriaNoBanco = banco.Categorias.Where(
                w => w.ID == categoria.ID).SingleOrDefault();

            categoriaNoBanco.Nome = categoria.Nome;

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = categoria.ID });
        }


     }
   

}
