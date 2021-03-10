using System;
using Xunit;
using Sistema_de_Vendas.Models;
using System.Collections.Generic;

namespace TestesSistemaDeVendas
{
    public class UnitTest1Models
    {
        [Fact]
        public void TestLogin()
        {
            LoginModel objLogin = new LoginModel();
            objLogin.Email = "maro_fis@hotmail.com";
            objLogin.Senha = "123456";
            bool result = objLogin.ValidarLogin();
            Assert.True(result);            

        }
        [Fact]
        public void CheckListProdutos()
        {
            ProdutoModel objProduto = new ProdutoModel();
            var lista = objProduto.ListarTodosProdutos();
            Assert.IsType<List<ProdutoModel>>(lista);
        }
    }
}
