using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Vendas.Uteis;

namespace Sistema_de_Vendas.Models
{
    public class ProdutoModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Descricao do Produto")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Informe o Preço Unitário do Produto")]
        public decimal? PrecoUnitario { get; set; }

        [Required(ErrorMessage = "Informe Quantidade em Estoque do Produto")]
        public decimal? QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Informe a Unidade de Medida do Produto")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "Informe o Link da Foto do Produto")]

        public string LinkFoto { get; set; } 

        public List<ProdutoModel> ListarTodosProdutos()
        {
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto ORDER BY nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel()
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Descricao = dt.Rows[i]["Descricao"].ToString(),
                    PrecoUnitario = decimal.Parse(dt.Rows[i]["preco_unitario"].ToString()),
                    QuantidadeEstoque = decimal.Parse(dt.Rows[i]["quantidade_estoque"].ToString()),
                    UnidadeMedida = dt.Rows[i]["unidade_medida"].ToString(),
                    LinkFoto = dt.Rows[i]["link_foto"].ToString(),

                };
                lista.Add(item);

            }
            return lista;
        }

        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            if (Id == null)
            {
                sql = $"INSERT INTO Produto(nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto) VALUES ('{Nome}', '{Descricao}' , '{PrecoUnitario}', '{QuantidadeEstoque}', '{UnidadeMedida}', '{LinkFoto}') ";

            }
            else
            {
                sql = $"UPDATE Produto SET nome = '{Nome}', descricao  = '{Descricao}', preco_unitario  = {PrecoUnitario}, quantidade_estoque  = '{QuantidadeEstoque}', unidade_medida  = '{UnidadeMedida}', link_foto  = '{LinkFoto}' WHERE id = '{Id}' ";

            }
            objDAL.ExecutarComandoSQL(sql);
        }

        public ProdutoModel RetornarProduto(int? id)
        {

            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, descricao, preco_unitario, quantidade_estoque, unidade_medida, link_foto FROM Produto WHERE id='{id}'";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ProdutoModel()
            {
                Id = dt.Rows[0]["Id"].ToString(),
                Nome = dt.Rows[0]["Nome"].ToString(),
                Descricao = dt.Rows[0]["Descricao"].ToString(),
                PrecoUnitario = decimal.Parse(dt.Rows[0]["preco_unitario"].ToString().Replace(",", ".")),
                QuantidadeEstoque = decimal.Parse(dt.Rows[0]["quantidade_estoque"].ToString().Replace(",", ".")),
                UnidadeMedida = dt.Rows[0]["unidade_medida"].ToString(),
                LinkFoto = dt.Rows[0]["link_foto"].ToString(),
               
                
            };

            return item;
        }
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

            sql = $"DELETE FROM Produto WHERE id = '{id}'";

            objDAL.ExecutarComandoSQL(sql);
        }

    }
}
