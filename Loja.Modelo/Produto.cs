using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Modelo
{
    public class Produto
    {
        public int Id { get; set; }
        //virtual - ligar o lazy load
        public virtual Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
