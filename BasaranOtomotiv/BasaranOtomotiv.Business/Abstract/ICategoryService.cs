using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByCategoryName(string categoryName);
        Category Add(Category category);
        Category Update(Category category);
        void Delete(Category category);
    }
}
