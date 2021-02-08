using ETicaret.Business.Abstract;
using ETicaret.Data.Abstract;
using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Concrete
{
    public class ProductManager : IProductService // busines katmanı eklememizdeki sebep  mesela  ürün eklemeden önce  gerekli tüm kriterleri kontrol edicez ve ef core üzerinden işlem yapıcaz // ön filtreleme
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name,page,pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productRepository.Update(entity, categoryIds);
        }
    }
}
