using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {//hernagi bir database türüne özgü kod yazmadık sadece ıproductrepost yazdık bunu diğer webui da kullanıyor lucaz.Snala sınıfın dolu metodu ise concrate içinde hazırlanır

        List<Product> GetPopularProducts();//buda sadece producta özel operasyonum

        List<Product> GetProductsByCategory(string name,int page,int pageSize);// ürün bilgilerini alıcak yanında da categori bilgileri gelicek
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        Product GetProductDetails(string url);
        Product GetByIdWithCategories(int id);

        int GetCountByCategory(string category);

        void Update(Product entity, int[] categoryIds);

    }
}


