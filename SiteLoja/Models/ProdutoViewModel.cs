using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteLoja.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
    }
}