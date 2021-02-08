using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; } //vtde kaç ürünüm var toplam
        public int ItemsPerPage { get; set; } //her sayfada kaç ürün göstermek istiyorum
        public int CurrentPage { get; set; } // hangi sayfadayız --secilen sayfayı işaretlemek icin
        public string CurrentCategory { get; set; } // link olustururken kategori bilgisi yapılmıs mı

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);//toplam 10 ürün var ve her sayfada 3 olursa 10 / 3:3.3 olur bunu yuvarlamam lazım 4 e
        }

    }

    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
