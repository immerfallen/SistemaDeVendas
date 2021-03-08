using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sistema_de_Vendas.Uteis;
using System.Data;

namespace Sistema_de_Vendas.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Informe o Nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do cliente")]
        public string CPF_CNPJ { get; set; }

        [Required(ErrorMessage = "Informe o E-mail do cliente")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string  Email { get; set; }
        public string Senha { get; set; }



        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM cliente ORDER BY nome ASC";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    CPF_CNPJ = dt.Rows[i]["CPF_CNPJ"].ToString(),
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
                sql = $"INSERT INTO cliente(nome, cpf_cnpj, email, senha) VALUES ('{Nome}', '{CPF_CNPJ}', '{Email}', '123456') ";
               
            }
            else
            {
                sql = $"UPDATE cliente SET nome = '{Nome}', cpf_cnpj = '{CPF_CNPJ}', email = '{Email}' WHERE id = '{Id}' ";                
            }
            objDAL.ExecutarComandoSQL(sql);
        }

        public ClienteModel RetornarCliente(int? id)
        {
            
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, cpf_cnpj, email, senha FROM cliente WHERE id='{id}'";
            DataTable dt = objDAL.RetDataTable(sql);
            
                item = new ClienteModel()
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Nome = dt.Rows[0]["Nome"].ToString(),
                    CPF_CNPJ = dt.Rows[0]["CPF_CNPJ"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Senha = dt.Rows[0]["Senha"].ToString()
                };              
                        
            return item;
        }
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();
            string sql = string.Empty;

                sql = $"DELETE FROM cliente WHERE id = '{id}'";            
            
            objDAL.ExecutarComandoSQL(sql);
        }

    }
}
