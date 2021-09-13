using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface ISubCategoryService
    {
        List<SubCategory> GetAll();
        List<SubCategory> GetAllByCategory(int categoryId);
        SubCategory GetById(int id);
        SubCategory GetBySubcategoryName(string subCategoryName);
        SubCategory Add(SubCategory subCategory);
        SubCategory Update(SubCategory subCategory);

        void Delete(SubCategory subCategory);
    }
}
