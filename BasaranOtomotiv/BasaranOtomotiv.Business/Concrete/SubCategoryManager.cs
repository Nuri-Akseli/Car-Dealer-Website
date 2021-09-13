using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Concrete
{
    public class SubCategoryManager:ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public SubCategory Add(SubCategory subCategory)
        {
            return _subCategoryDal.Add(subCategory);
        }

        public void Delete(SubCategory subCategory)
        {
            _subCategoryDal.Delete(subCategory);
        }

        public List<SubCategory> GetAll()
        {
            return _subCategoryDal.GetList();
        }

        public List<SubCategory> GetAllByCategory(int categoryId)
        {
            return _subCategoryDal.GetList(subCategory => subCategory.CategoryId == categoryId);
        }

        public SubCategory GetById(int id)
        {
            return _subCategoryDal.Get(subCategory => subCategory.SubCategoryId == id);
        }

        public SubCategory GetBySubcategoryName(string subCategoryName)
        {
            return _subCategoryDal.Get(subCategory => subCategory.SubCategoryName == subCategoryName);
        }

        public SubCategory Update(SubCategory subCategory)
        {
            return _subCategoryDal.Update(subCategory);
        }
    }
}
