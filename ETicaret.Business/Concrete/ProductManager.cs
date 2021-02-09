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

 

        public bool Create(Product entity)
        {
            //if (entity.Name.Length == 0) {} tek tek metot ıcınde hazırlayabiliriz ya da genel bir interface üzerinden yaparız
            if (Validation(entity))
            {
                _productRepository.Create(entity);//validation dan dönen sonuc true ise ekleme işlemini yap
                return true;
            }
            return false;
            
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
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

        public int GetCountByCategory(string entity)
        {

            return _productRepository.GetCountByCategory(entity);
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


        public bool Update(Product entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori secmelisiniz.";
                    return false;
                }
                _productRepository.Update(entity, categoryIds);
                return true;
            }
            return false;
           
        }

        public string ErrorMessage { get; set; }
        public bool Validation(Product entity)
        {
            var isValid = true;//başta her sey yolunda
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz.\n";
                isValid = false;
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "ürün fiyatı negatif olamaz.\n";
                isValid = false;
            }

            return isValid;
        }
    }
}
