using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_de_Vendas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Uteis;
using Microsoft.AspNetCore.Http;

namespace Sistema_de_Vendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(int? id)
        {
            //Para realizar o logout
            if(id != null)
            {
                if(id==0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu","Home");
                }
                else
                {
                    TempData["ErroLogin"] = "E-mail ou Senha estão incorretos!";
                    
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
