﻿using Sistema_de_Vendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Sistema_de_Vendas.Models
{
    public class RelatorioModel
    {

        public DateTime DataDe { get; set; }
        public DateTime DataAte { get; set; }
        
    }

    public class GraficoProdutos
    {
        public double QuantidadeVendida { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }

        public List<GraficoProdutos> RetornarGrafico()
        {
            DAL objDal = new DAL();
            string sql = "select sum(qtde_produto) as qtde, p.nome as produto from itens_venda i inner join produto p on i.produto_id = p.id group by p.nome";
            DataTable dt = objDal.RetDataTable(sql);

            List<GraficoProdutos> lista = new List<GraficoProdutos>();
            GraficoProdutos item;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GraficoProdutos();
                item.QuantidadeVendida = double.Parse(dt.Rows[i]["qtde"].ToString());
                item.DescricaoProduto = dt.Rows[i]["produto"].ToString();
               
                lista.Add(item);
            }
            return lista;
        }
    }
}
