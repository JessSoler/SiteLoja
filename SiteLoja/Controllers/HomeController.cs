using SiteLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteLoja.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            ViewData["Titulo"] = "Roupas da Semana";
            ViewData["Data"] = DateTime.Now;

            // Criar uma instância do contexto do banco de dados


            var dbContext = new LojaRoupasEntities2();

            // Filtrar os produtos com o campo "RoupaDaSemana" definido como verdadeiro (1)
            var produtosDaSemana = dbContext.Produtos.Where(p => p.RoupaDaSemana == true).ToList();
            var totalProdutos = produtosDaSemana.Count;

            ViewBag.Total = "Total de Produtos :";
            ViewBag.TotalProdutos = totalProdutos;

            return View(produtosDaSemana);
        }
    }
}