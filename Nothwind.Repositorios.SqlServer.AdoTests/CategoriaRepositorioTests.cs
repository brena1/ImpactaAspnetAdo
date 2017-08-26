using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace Nothwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class CategoriaRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var categoriaRepositorio = new CategoriaRepositorio();

            var categoriaDataTable = categoriaRepositorio.Selecionar();

            //


            foreach (DataRow registro in categoriaDataTable.Rows)
            {
                Console.WriteLine($"{registro[0]} - {registro["CategoryName"]} ");
            }
        }
    }
}