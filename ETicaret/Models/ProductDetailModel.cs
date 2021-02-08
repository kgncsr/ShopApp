using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class ProductDetailModel //hem ürün hem category bilgisini bana taşıyacak olan bir yapı
    {

        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
