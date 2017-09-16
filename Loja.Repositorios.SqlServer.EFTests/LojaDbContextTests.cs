using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using Loja.Modelo;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _dbContext = new LojaDbContext();

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            _dbContext.Database.Log = LogarQuery;
        }

        private static void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void LojaDbContextTest()
        {
          //using (var dbContext = new LojaDbContext())
            //{
                var produtos = _dbContext.Produtos.ToList();
            //}
        }

        [TestMethod]
        public void InserirCategoriaTeste()
        {
            
            _dbContext.Categorias.Add(new Categoria { Nome = "Cozinha"});
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();
            produto.Estoque = 3;
            produto.Nome = "Colher";
            produto.Preco = 16.03m;
            produto.Categoria = _dbContext.Categorias.Single(c => c.Nome == "Cozinha");


            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var produto = new Produto();
            produto.Estoque = 14;
            produto.Nome = "Barbeador";
            produto.Preco = 16.14m;
            produto.Categoria = new Categoria { Nome = "Perfumaria" };


            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void EditarProduto()
        {
            var colher = _dbContext.Produtos.First(p => p.Nome == "Colher" );
            colher.Preco = 16.25m;
            _dbContext.SaveChanges();
            colher = _dbContext.Produtos.First(p => p.Nome == "Colher");

            Assert.AreEqual(colher.Preco, 16.25m);
        }

        [TestMethod]
        public void ExcluirProduto()
        {
            var colher = _dbContext.Produtos.First(p => p.Nome == "Colher");           
            _dbContext.Produtos.Remove(colher);
            _dbContext.SaveChanges();

            Assert.IsFalse(_dbContext.Produtos.Any(p => p.Nome == "Colher"));           
        }

        [TestMethod]
        public void ObterPrecoMedioPerfumaria()
        {
            var media = _dbContext.Produtos
                .Where(p => p.Categoria.Nome == "Perfumaria")
                .Average(p => p.Preco);

            Console.WriteLine($"Valor medio: {media}");
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var barbeador = _dbContext.Produtos.First(p => p.Nome == "Barbeador");
            Assert.IsNull(barbeador.Categoria);              
        }

        [TestMethod]
        public void LazyLoadLigadoTeste()
        {
            var barbeador = _dbContext.Produtos.First(p => p.Nome == "Barbeador");
            Assert.IsTrue(barbeador.Categoria.Nome == "Perfumaria");
        }

        [TestMethod]
        public void IncludeTest()
        {
            var barbeador = _dbContext.Produtos
                .Include(p => p.Categoria)
                .First(p => p.Nome == "Barbeador");
                Assert.IsTrue(barbeador.Categoria.Nome == "Perfumaria");
        }

        [TestMethod]
        public void QueryTeste()
        {
            var query = _dbContext.Produtos.Where(p => p.Preco > 10);
            query.OrderBy(p => p.Preco);

            var primeiro = query.First();
            var ultimo = query.Last();
            var unico = query.Single();
        }

        [ClassCleanup]
        public static void DescartarContexto()
        {
            _dbContext.Dispose();
        }
    }
}