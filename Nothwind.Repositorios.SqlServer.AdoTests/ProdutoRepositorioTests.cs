﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nothwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        ProdutoRepositorio _produtoRepositorio = new ProdutoRepositorio();


        [TestMethod()]
        public void SelecionarPorCategoriaTest()
        {
            Assert.AreEqual(_produtoRepositorio.SelecionarPorCategoria(1).Rows[0]["ProductName"], "Chai");
        }

        [TestMethod()]
        public void SelecionarPorFornecedorTest()
        {
            Assert.AreEqual(_produtoRepositorio.SelecionarPorFornecedor(1).Rows[0]["ProductName"], "Chai");
        }
    }
}