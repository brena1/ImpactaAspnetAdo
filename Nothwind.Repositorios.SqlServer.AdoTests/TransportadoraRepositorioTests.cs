using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Modelo;
using Nothwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Nothwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class TransportadoraRepositorioTests
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            Assert.IsTrue(_repositorio.Selecionar().Any());
        }

        [TestMethod()]
        public void SelecionarComIdTest()
        {
            Assert.IsNotNull(_repositorio.Selecionar(1));
            Assert.IsNull(_repositorio.Selecionar(1000));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var transportadora = new Transportadora();
            transportadora.Nome = "Correios";
            transportadora.Telefone = "1234 5678";

            _repositorio.Inserir(transportadora);
            Assert.AreNotEqual(0, transportadora.Id);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var transportadora = new Transportadora();
            transportadora.Id = 4;
            transportadora.Nome = "oi";
            transportadora.Telefone = "1234 5678";

            _repositorio.Atualizar(transportadora);
            Assert.AreEqual(_repositorio.Selecionar(transportadora.Id).Nome, transportadora.Nome);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _repositorio.Excluir(4);
            Assert.IsNull(_repositorio.Selecionar(4));
        }
    }
}