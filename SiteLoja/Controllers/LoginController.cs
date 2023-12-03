using SiteLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteLoja.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(string username, string senha) 
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            {
                // Verifique as credenciais do usuário no banco de dados
                var usuario = banco.Usuarios.FirstOrDefault(u => u.Nome == username && u.Password == senha);

                if (usuario != null)
                {
                    // Usuário autenticado com sucesso
                    return Json(new { success = true, message = "Login bem-sucedido!" });
                }
                else
                {
                    // Falha na autenticação
                    return Json(new { success = false, message = "Credenciais inválidas." });
                }
            }

        //public IActionResult FazLogin(string usuario, string senha)
        //{
        //    LojaRoupasEntities2 banco = new LojaRoupasEntities2();
        //    UsuarioViewModel usuarioModel = dao.Consultar(usuario, senha);

        //    if (usuarioModel == null)
        //    {
        //        ViewBag.Erro = "Usuário ou senha inválidos!";
        //        return View("Index");

        //    }
        //    else
        //    {
        //        HttpContext.Session.SetString("Logado", "true");
        //        HttpContext.Session.SetString("IdUsuario", usuarioModel.Id.ToString());
        //        HttpContext.Session.SetString("Nickname", usuarioModel.Nickname);
        //        HttpContext.Session.SetString("Administrador", usuarioModel.Administrador.ToString());

        //        if (usuarioModel.Administrador)
        //        {
        //            return RedirectToAction("Administradores", "Home");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Loja", "Home");
        //        }
        //    }
        //}
        //public IActionResult LogOff()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Loja", "Home");
        //}
    }
}
}