using SiteLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteLoja.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult List()
        {
            ViewData["Titulo"] = "Todas as Roupas";
            ViewData["Data"] = DateTime.Now;

            var produtos = new LojaRoupasEntities2().Produtos.ToList();
            var totalprodutos = produtos.Count();

            ViewBag.Total = "Total de Produtos :";
            ViewBag.TotalProdutos = totalprodutos;


            return View(produtos);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var produto = banco.Produtos
                .Where(x => x.ID == id).SingleOrDefault();

            return View(produto);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            var produto = banco.Produtos
                .Where(x => x.ID == id).SingleOrDefault();

            banco.Produtos.Remove(produto);

            banco.SaveChanges();

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Create()
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            var produto = banco.Produtos.ToList();
            var lista = new List<SelectListItem>();
            foreach (var pro in produto)
            {
                lista.Add(new SelectListItem
                {
                    Value = pro.ID.ToString(),
                    Text = pro.Nome
                });
            }

            ViewBag.IDProduto = lista;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            LojaRoupasEntities2 banco = new LojaRoupasEntities2();
            banco.Produtos.Add(produto);

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = produto.ID });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var produto = banco.Produtos.Where(
                w => w.ID == id).SingleOrDefault();

            var produtos = banco.Produtos.ToList();
            var lista = new List<SelectListItem>();
            foreach (var pro in produtos)
            {
                lista.Add(new SelectListItem
                {
                    Value = pro.ID.ToString(),
                    Text = pro.Nome,
                });
            }

            ViewBag.IDProduto = lista;

            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {

            LojaRoupasEntities2 banco = new LojaRoupasEntities2();

            var produtoNoBanco = banco.Produtos.Where(
                w => w.ID == produto.ID).SingleOrDefault();

            //altera os dados para o que veio 

            produtoNoBanco.IDCategoia=produto.IDCategoia;   
            produtoNoBanco.Nome = produto.Nome;
            produtoNoBanco.Descricao = produto.Descricao;
            produtoNoBanco.Preco= produto.Preco;
            produtoNoBanco.PrecoAtual= produto.PrecoAtual;
            produtoNoBanco.ImagemUrl = produto.ImagemUrl;
            produtoNoBanco.ImagemThumbnaiUrl = produto.ImagemThumbnaiUrl;
            produtoNoBanco.RoupaDaSemana = produto.RoupaDaSemana;
            produtoNoBanco.EmEstoque = produto.EmEstoque;  
   

            banco.SaveChanges();

            return RedirectToAction("Details", new { id = produto.ID });
        }
    }
}