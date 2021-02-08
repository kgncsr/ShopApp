using ETicaret.Business.Abstract;
using ETicaret.Entity;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult List(string category,int page= 1/*herhangi bir sayfa isteği gelmezse kullanıcı direk 1. sayfaya yönlendirilir*/)
        {
            const int pageSize = 2; //sayfada 2 ürün gösterilsin // const un amacı sayfada hicbir zaman pagsize ı değiştirmicez dioz
            var productViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()//burdaki tüm bilgileri  page info ile paketleyip view e göndercez ve bu bilgilerle link yapısı oluscak
                {
                    TotalItems=_productService.GetCountByCategory(category),//kategoriye göre ürün sayısı gelcek kategori yok ise tüm ürün sayısı gelcek
                    CurrentPage=page,//metoda gönderdiğimiz page bilgisi
                    ItemsPerPage =pageSize,//kaç ürün göstermek istiyorum   
                    CurrentCategory = category//hangi kategori varsa gelir
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            };//bunu productviewmodel.csye gönderiyo onu viewde kullanıyo sonra onu ekrana basıyo 

            return View(productViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(url);

            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel//viewmodel içine paketledim
            {
                Product = product,
                Categories = product.ProductCategories
                .Select(i => i.Category)// zaten vt'den sorguladığımız bir bilgi üstüne select işlemi yapabiliriz her gelen bilgi üzerinden kategoriye geçeriz
                .ToList()//ve almış olduğum her kategoriyi foreace kullanıyomuşum gibi i içine kopyaliycam ve gitmiş olduğum productun categorysine gidicem
            });//ürünü aldım kategorilerinide getirdim 1. telefonlar o veriyi post edeceksin ama elinde product ve category var ve başka categoryde varsa o ürnün hangi kategoriden geldiğini bilmen lazım oda bu
        }

        public IActionResult Search(string q)
        {

            var productViewModel = new ProductListViewModel()
            {

                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }

    }
}