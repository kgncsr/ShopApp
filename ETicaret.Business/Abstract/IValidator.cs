using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Business.Abstract
{
    public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        bool Validation(T entity);//bu metot I validatora gelen entityi alsın validate etsin  ve basarı basarısız olma durumuna göre true veya false döndürsün

    }
}
