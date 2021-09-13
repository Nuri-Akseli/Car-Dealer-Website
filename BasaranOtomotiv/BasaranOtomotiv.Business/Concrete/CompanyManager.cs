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
    public class CompanyManager:ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public Company Add(Company company)
        {
            return _companyDal.Add(company);
        }

        public void Delete(Company company)
        {
            _companyDal.Delete(company);
        }

        public List<Company> GetAll()
        {
            return _companyDal.GetList();
        }

        public List<Company> GetAllBySubCategory(int subCategoryId)
        {
            return _companyDal.GetList(company => company.SubCategoryId == subCategoryId).ToList();
        }

        public Company GetById(int id)
        {
            return _companyDal.Get(company=>company.CompanyId==id);
        }

        public Company Update(Company company)
        {
            return _companyDal.Update(company);
        }
    }
}
