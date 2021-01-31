using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Models;

namespace Sistema_de_Vendas.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.ListaVendedores = new VendedorModel().ListarTodosVendedores();

            return View();
        }

       
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id!= null)
            {
                //Carregar o registro do Vendedor em uma ViewBag
                ViewBag.Vendedor = new VendedorModel().RetornarVendedor(id);
            }  

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedor)
        {

            if (ModelState.IsValid)
            {
                vendedor.Gravar();
                return RedirectToAction("Index", "Vendedor");
            }

            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;


            return View();
        }

        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().Excluir(id);
            return View();
        }
    }

}
