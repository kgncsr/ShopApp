using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Kategori için 5-100 arasında değer giriniz")]
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}
