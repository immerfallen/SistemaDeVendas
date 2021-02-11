using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Models;

namespace Sistema_de_Vendas.Controllers
{
    public class VendaController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListaVendas = new VendaModel().ListagemVendas();
            return View();
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            venda.Inserir();
            CarregarDados(); // necessário colocar aqui o método pois caso contrário ao renderizar as View as ViewBags estarão vazias
            return View();
        }

        private void CarregarDados()
        {
            ViewBag.ListaClientes = new VendaModel().RetornarListaClientes();
            ViewBag.ListaVendedores = new VendaModel().RetornarListaVendedores();
            ViewBag.ListaProdutos = new VendaModel().RetornarListaProdutos();
        }

    }
}
