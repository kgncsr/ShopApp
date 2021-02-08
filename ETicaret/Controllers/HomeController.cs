 using ETicaret.Business.Abstract;
using ETicaret.Data.Abstract;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productServices;

        public HomeController(IProductService productServices)
        {
            this._productServices = productServices;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productServices.GetHomePageProducts()
            };

            return View(productViewModel);
        }


    }
}