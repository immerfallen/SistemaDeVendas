using Newtonsoft.Json;
using Sistema_de_Vendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Vendas.Models
{
    public class VendaModel
    {
        public string Id { get; set; }

        public string ClienteId { get; set; }
        public string ListaProdutos { get; set; }

        
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
        public void Inserir()
        {
            DAL objDAL = new DAL();

            string dataVenda = DateTime.Now.Date.ToString("yyyy/MM/dd");
            
            string sql = $"INSERT INTO venda(data, total, Vendedor_id, Cliente_id) VALUES ('{dataVenda}', {Total.ToString().Replace(",",".")}, {VendedorId}, {ClienteId})";

            objDAL.ExecutarComandoSQL(sql);

            // Recuperar o ID da venda
            sql = $"SELECT id FROM venda WHERE data='{dataVenda}' AND Vendedor_id={VendedorId} AND Cliente_id={ClienteId} ORDER BY id DESC LIMIT 1";
            DataTable dt = objDAL.RetDataTable(sql);
            string id_venda = dt.Rows[0]["id"].ToString();


            //Desserializar o JSON da lista de produtos selecionados e gravá-los na tabela itens_venda --->> Será feito através da classe ItemVendaModel onde será criado uma classe com as mesmas propriedadas do JSON
            List<ItemVendaModel> lista_produtos = JsonConvert.DeserializeObject<List<ItemVendaModel>>(ListaProdutos); // Desserializar é receber o JSON -> coloca ele em um objeto
            for (int i = 0; i < lista_produtos.Count; i++)
            {
                sql = $"INSERT INTO itens_venda(Venda_id, Produto_id,  qtde_produto, preco_produto) VALUES ({id_venda},{lista_produtos[i].CodigoProduto.ToString()},{lista_produtos[i].QuantidadeProduto.ToString()},{lista_produtos[i].PrecoUnitario.ToString().Replace(",",".")})";
                objDAL.ExecutarComandoSQL(sql);
            }

        }

    }
}
