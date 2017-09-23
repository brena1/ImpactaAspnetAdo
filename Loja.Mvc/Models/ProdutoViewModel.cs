﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
        }

        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
      
        [Required]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [Required]
        public Nullable<int> Estoque { get; set; }
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; }
    }
}