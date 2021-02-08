using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}
