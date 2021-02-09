using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface IProductService : IValidator<Product>//her bir servis mutalaka validotoru implement etmek zorunda
    {
         Product GetById(int id);
         Product GetByIdWithCategories(int id);
         Product GetProductDetails(string url);
         List<Product> GetProductsByCategory(string name, int page, int pageSize);
         List<Product> GetAll();
         List<Product> GetHomePageProducts();
         List<Product> GetSearchResult(string searchString);
         bool Create(Product entity);
         bool Update(Product entity, int[] categoryIds);
         void Delete(Product product);
         int GetCountByCategory(string entity);
    }
}
