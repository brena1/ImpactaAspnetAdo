using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Wcf.teste.PordutosServiceReference;
using System.Linq;

namespace AdventureWorks.Wcf.teste
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestMethod]
        public void GetTeste()
        {
            using (var cliente = new ProdutosClient())
            {
                var produto = cliente.Get(316);

                Assert.AreEqual(produto.Name, "Blade");
            }
        }
        [TestMethod]
        public void GetByNameTeste()
        {
            using (var cliente = new ProdutosClient())
            {
                var produtos = cliente.GetByName("Mountain");

                Assert.IsTrue(produtos.Any());
            }
        }
    }
}
