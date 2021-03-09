using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Models;

namespace Sistema_de_Vendas.Controllers
{
    public class RelatoriosController : Controller
    {
        public IActionResult Index()
        {
            return View();
           
        }
        public IActionResult Vendas()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Vendas(RelatorioModel relatorio)
        {
            if(relatorio.DataDe.Year == 1)
            { 
            ViewBag.ListaVendas = new VendaModel().ListagemVendas();
            }
            else
            {
                string DataDe = relatorio.DataDe.ToString("yyyy/MM/dd");
                string DataAte = relatorio.DataAte.ToString("yyyy/MM/dd");
                ViewBag.ListaVendas = new VendaModel().ListagemVendas(DataDe, DataAte);

            }
            return View();
        }
        public IActionResult Grafico()
        {

            List<GraficoProdutos> lista = new GraficoProdutos().RetornarGrafico();
            string valores = "";
            string labels = "";
            string cores = "";

            var random = new Random();
            // Percorre a lista de itens para compor o gráfico
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].QuantidadeVendida.ToString() + ",";
                labels += "'"+lista[i].DescricaoProduto.ToString() + "',";
                //escolher aleatoriamente as cores para o gráfico
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;
            return View();
        }

        public IActionResult Comissao()
        {
            return View();
        }
    }
}
