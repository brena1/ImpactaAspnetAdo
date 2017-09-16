using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Mvc.Models
{
    public class TransportadoraViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }

    }
}