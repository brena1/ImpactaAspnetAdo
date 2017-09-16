using System.Collections.Generic;

namespace Loja.Modelo
{
    public class Categoria
    {
        public int Id { get; set; }
        //ligar o lazy load.
        public virtual List<Produto> Produtos { get; set; }
        public string Nome { get; set; }
    }
}