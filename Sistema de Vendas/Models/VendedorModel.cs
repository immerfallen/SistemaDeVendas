using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sistema_de_Vendas.Uteis;
using System.Data;

namespace Sistema_de_Vendas.Models
{
    public class VendedorModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Informe a porra do Nome do Vendedor")]
        public string Nome { get; set; }
                

        [Required(ErrorMessage = "Informe o E-mail do Vendedor")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string  Email { get; set; }
        public string Senha { get; set; }



        public List<VendedorModel> ListarTodosVendedores()
        {
            List<VendedorModel> lista = new List<VendedorModel>();
            VendedorModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, email, senha FROM Vendedor ORDER BY nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendedorModel()
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Senha = dt.Rows[i]["Senha"].ToString()
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
                sql = $"INSERT INTO Vendedor(nome, email, senha) VALUES ('{Nome}', '{Email}', '123456') ";
               
            }
            else
            {
                sql = $"UPDATE Vendedor SET nome = '{Nome}', email = '{Email}' WHERE id = '{Id}' ";
                
            }
            objDAL.ExecutarComandoSQL(sql);
        }

        public VendedorModel RetornarVendedor(int? id)
        {
            
            VendedorModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, email, senha FROM Vendedor WHERE id='{id}'";
            DataTable dt = objDAL.RetDataTable(sql);
            
                item = new VendedorModel()
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Nome = dt.Rows[0]["Nome"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Senha = dt.Rows[0]["Senha"].ToString()
                };              
                        
            return item;
        }
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

                sql = $"DELETE FROM Vendedor WHERE id = '{id}'";            
            
            objDAL.ExecutarComandoSQL(sql);
        }

    }
}
