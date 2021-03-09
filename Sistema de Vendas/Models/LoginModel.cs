using Sistema_de_Vendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Sistema_de_Vendas.Models
{
    public class LoginModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }


       
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE email=@email AND senha=@senha";
            MySqlCommand Command = new MySqlCommand();
            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@senha", Senha);

            DAL objDAL = new DAL();

            DataTable dt = objDAL.RetDataTable(Command);
            if (dt.Rows.Count==1)
            {
                Id = dt.Rows[0]["Id"].ToString();
                Nome = dt.Rows[0]["Nome"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
