using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Vendas.Uteis
{
    //Criação do Data Access Layer - aqui será feita nossa string de conexão com o banco de dados - Parte da estrutura de sistema baseada em camadas
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string connectionString = $"Server={Server};Database={Database},User={User};Password={Password}; Sslmode=none; Chartset=utf8;";

        private static MySqlConnection Connection;


        public DAL()
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }




    }
}
