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
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Add(Category category)
        {
            return _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Category GetByCategoryName(string categoryName)
        {
            return _categoryDal.Get(category=>category.CategoryName==categoryName);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(category => category.CategoryId == id);
        }

        public Category Update(Category category)
        {
            return _categoryDal.Update(category);
        }
    }
}
