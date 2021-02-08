using ETicaret.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>//ırepcat verdim artık bu class ırepin içindeki tüm operasynlara sahip orada t gördüğü yere category yazacak
    {//bu interfacenin içine tek tek doldurmaya gerek yok bunun yerine IRepository clasını aldım ve ona category gönderdim daha sonra arabirim uyguladım


        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);

        //----- artık bunlara gerek yok çünkü Ana bir clasımız var oda IRepository içine <Category> gönderdim ve burada işlem yaparsam Category gidip T olacak
        //  Category GetById(int id);
        //  List<Category> GetAll();
        //  void Create(Category product);
        //  void Update(Category product);
        //  void Delete(int product);
    }
}
