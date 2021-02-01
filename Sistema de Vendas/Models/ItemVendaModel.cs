using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Vendas.Models
{
    public class ItemVendaModel
    {
        //Todas as propriedades devem ser string pois estamos lidando com JSON
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string QuantidadeProduto { get; set; }
        public string PrecoUnitario { get; set; }
        public string Total { get; set; }
    }
}
