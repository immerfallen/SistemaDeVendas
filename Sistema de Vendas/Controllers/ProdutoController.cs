using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Models;

namespace Sistema_de_Vendas.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.ListaProdutos = new ProdutoModel().ListarTodosProdutos();

            return View();
        }


        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar o registro do Produto em uma ViewBag
                ViewBag.Produto = new ProdutoModel().RetornarProduto(id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoModel produto)
        {

            if (ModelState.IsValid)
            {
                produto.Gravar();
                return RedirectToAction("Index", "Produto");
            }

            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;


            return View();
        }

        public IActionResult ExcluirProduto(int id)
        {
            new ProdutoModel().Excluir(id);
            return View();
        }
    }
}

