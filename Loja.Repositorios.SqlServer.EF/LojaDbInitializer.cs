using System;
using System.Data.Entity;
using Loja.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Loja.Repositorios.SqlServer.EF
{
    internal class LojaDbInitializer : DropCreateDatabaseAlways<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(ObterCategorias());
                context.SaveChanges();
            }


            if (!context.Produtos.Any())
            {
                context.Produtos.AddRange(ObterProdutos(context));
                context.SaveChanges();
            }

            base.Seed(context);
        }

        private IEnumerable<Produto> ObterProdutos(LojaDbContext context)
        {
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 17.27m;
            grampeador.Estoque = 27;
            grampeador.Descontinuado = false;
            grampeador.Categoria = context.Categorias.Single(c => c.Nome == "Papelaria");

            var penDrive = new Produto();
            penDrive.Nome = "PenDrive";
            penDrive.Preco = 20.48m;
            penDrive.Estoque = 50;
            penDrive.Descontinuado = false;
            penDrive.Categoria = context.Categorias.Single(c => c.Nome == "Informática");

            var chanel = new Produto();
            chanel.Nome = "Chanel";
            chanel.Preco = 500.99m;
            chanel.Estoque = 10;
            chanel.Descontinuado = false;
            chanel.Categoria = context.Categorias.Single(c => c.Nome == "Perfumaria");

            return new List<Produto> {grampeador, penDrive, chanel };
        }

        private List<Categoria> ObterCategorias()
        {
            return new List<Categoria> {
                new Categoria {Nome = "Papelaria" },
                new Categoria {Nome = "Informática" } 
                ,new Categoria {Nome = "Perfumaria" }

            };
            
        }
    }
}