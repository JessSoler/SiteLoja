using SiteLoja.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SiteLoja.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var usuario = banco.Usuarios
                .Where(x => x.ID == id).SingleOrDefault();

            return View(usuario);
        }
        [HttpGet]
        public ActionResult Create()
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            var usuario = banco.Usuarios.ToList();
            var lista = new List<SelectListItem>();
            foreach (var pro in usuario)
            {
                lista.Add(new SelectListItem
                {
                    Value = pro.ID.ToString(),
                    Text = pro.Nome
                });
            }

            ViewBag.IDUsuario = lista;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            banco.Usuarios.Add(usuario);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = usuario.ID });
        }
    }
}