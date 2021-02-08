using ETicaret.Data.Abstract;
using ETicaret.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaret.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.ProductId == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)/*then include ile her aldımız ProductCategories bilgisi üzerinden i .category bilgiisini yüklücez*/
                    .FirstOrDefault();
            }
        }

        //private ShopContext db = new ShopContext();
        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i=>i.IsApproved).AsQueryable(); 

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(b => b.Category.Url == category));
                }

                return products.Count(); // ilgili kritere uyan kaç ürün varsa count la geri gönderioz

            }

        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i=>i.IsApproved==true && i.IsHome==true).ToList();
            }
        }

       

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name,int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i=>i.IsApproved).AsQueryable(); //asquaryble daki amac biz sorguyu yazıyoruz ama veri tabanına göndermeden önce üzerine ekstradan linq sorgusu kriter eklemek istiyorum diyoruz // to list demedimiz sürece üzerine filtrleme sansımız oluyor

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                        .Include(i => i.ProductCategories)//ürün bilgilerinin productscategorieslerini
                        .ThenInclude(i => i.Category)//daha sonra categorylerini yüklüyoruz
                        .Where(i => i.ProductCategories.Any(b => b.Category.Url == name));//yükledikten sonra ilgili kaydın productscategorieslerine gidioz ve  burdan category e geçiyoruz ve any değeri bize true değeri gönderiyor ve eğer true ise  ilgili ürünü bana getir diye kriter ekleniyor
                }

                return products.Skip((page-1)*pageSize).Take(pageSize).ToList(); //Iquaryble ı listeye cevirdmiz anda sorgu veritabnına gider
                
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))).AsQueryable();


                return products.ToList(); 

            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                                    .Include(i => i.ProductCategories)
                                    .FirstOrDefault(i => i.ProductId == entity.ProductId);


                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;

                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}