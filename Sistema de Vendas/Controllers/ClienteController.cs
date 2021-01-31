using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Models;

namespace Sistema_de_Vendas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.ListaClientes = new ClienteModel().ListarTodosClientes();

            return View();
        }

       
        [HttpGet]
        public IActionResult Cadastro()
        {
                    

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {

            if (ModelState.IsValid)
            {
                cliente.Inserir();
                return RedirectToAction("Index", "Cliente");
            }

            return View();
        }
    }

}
