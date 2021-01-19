using Sistema_de_Vendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Vendas.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }


        // Existe um problema grave de segurança com essa abordagem => SQL Injection
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID FROM VENDEDOR WHERE EMAIL='{Email}' AND SENHA='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            if (dt.Rows.Count>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
