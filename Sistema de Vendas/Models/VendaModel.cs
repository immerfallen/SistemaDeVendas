using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Vendas.Models
{
    public class VendaModel
    {
        public string Id { get; set; }

        public string ClienteId { get; set; }

        public string Data { get; set; }

        public string Total { get; set; }
        public string VendedorId { get; set; }
        public string ProdutoId { get; set; }

        public List<ClienteModel> RetornarListaClientes()
        {
            return new ClienteModel().ListarTodosClientes();
        }

        public List<VendedorModel> RetornarListaVendedores()
        {
            return new VendedorModel().ListarTodosVendedores();
        }

        public List<ProdutoModel> RetornarListaProdutos()
        {
            return new ProdutoModel().ListarTodosProdutos();
        }

    }
}
