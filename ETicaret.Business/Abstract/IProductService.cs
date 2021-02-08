using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface IProductService
    {
         Product GetById(int id);
         Product GetByIdWithCategories(int id);
         Product GetProductDetails(string url);
         List<Product> GetProductsByCategory(string name, int page, int pageSize);
         List<Product> GetAll();
         List<Product> GetHomePageProducts();
         List<Product> GetSearchResult(string searchString);
         void Create(Product product);
         void Update(Product entity, int[] categoryIds);
         void Delete(Product product);
         int GetCountByCategory(string category);
    }
}
