using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        List<Company> GetAllBySubCategory(int subCategoryId);
        Company GetById(int id);
        Company Add(Company company);
        Company Update(Company company);
        void Delete(Company company);
    }
}
