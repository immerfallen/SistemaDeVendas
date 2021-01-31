﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Cadastro(int? id)
        {
            if (id!= null)
            {
                //Carregar o registro do cliente em uma ViewBag
                ViewBag.Cliente = new ClienteModel().RetornarCliente(id);
            }  

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteModel cliente)
        {

            if (ModelState.IsValid)
            {
                cliente.Gravar();
                return RedirectToAction("Index", "Cliente");
            }

            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;


            return View();
        }

        public IActionResult ExcluirCliente(int id)
        {
            new ClienteModel().Excluir(id);
            return View();
        }
    }

}
