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
        public string Data { get; set; }

        public string ClienteId { get; set; }
        public string ListaProdutos { get; set; }

        
        public double Total { get; set; }
        public string VendedorId { get; set; }
        public string ProdutoId { get; set; }
        
        public List<VendaModel> ListagemVendas()
        {
            List<VendaModel> lista = new List<VendaModel>();
            VendaModel item;
            DAL objDAL = new DAL();
            string sql = "select v1.id, v1.data, v1.total, v2.nome as vendedor, c.nome as cliente from venda v1 inner join vendedor v2 on  v1.vendedor_id = v2.id inner join cliente c on v1.cliente_id = c.id order by data, total";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendaModel()
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Data = DateTime.Parse(dt.Rows[i]["Data"].ToString()).ToString("dd/MM/yyyy"),
                    Total = double.Parse(dt.Rows[i]["Total"].ToString()),                    
                    ClienteId = dt.Rows[i]["Cliente"].ToString(),
                    VendedorId = dt.Rows[i]["Vendedor"].ToString(),                  
                };
                lista.Add(item);

            }
            return lista;
        }

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
