using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nothwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class FornecedorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var fornecedorRepositorio = new FornecedorRepositorio();

            var fornecedorDataTable = fornecedorRepositorio.Selecionar();

            Assert.AreNotEqual(fornecedorDataTable.Rows.Count, 0);

            
        }
    }
}