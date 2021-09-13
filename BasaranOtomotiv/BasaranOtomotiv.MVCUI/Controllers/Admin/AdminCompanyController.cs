using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.DependancyResolvers.Ninject;
using BasaranOtomotiv.Business.ValidationRules.FluentValidation;
using BasaranOtomotiv.Core.Utilities.Validation.FluentValidation;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasaranOtomotiv.MVCUI.Controllers.Admin
{
    public class AdminCompanyController : Controller
    {
        ICompanyService  _companyService = InstanceFactory.GetInstance<ICompanyService>();
        ISubCategoryService _subCategoryService = InstanceFactory.GetInstance<ISubCategoryService>();
        Validate _validate = new Validate(new CompanyValidatior());
        // GET: AdminCompany
     
        public ActionResult GetCompanyList()
        {
            return View(_companyService.GetAll());
        }

        public ActionResult UpdateCompanyActivity(int id)
        {
            var company = _companyService.GetById(id);
            if (company.CompanyActivity)
            {
                company.CompanyActivity = false;
            }
            else
            {
                company.CompanyActivity = true;
            }
            _companyService.Update(company);
            return RedirectToAction("GetCompanyList");
        }

        [HttpGet]
        public ActionResult UpdateCompany(int id)
        {
            return View(_companyService.GetById(id));
        }
        [HttpPost]
        public ActionResult UpdateCompany(Company company)
        {
            var result = _validate.IsValid(company);
            if (result.IsValid)
            {
                _companyService.Update(company);
                return RedirectToAction("GetCompanyList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddCompany()
        {
            List<SelectListItem> subCategoryValues = (from subCategory in _subCategoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = subCategory.SubCategoryName,
                                                       Value = subCategory.SubCategoryId.ToString()
                                                   }).ToList();
            ViewBag.subCategories = subCategoryValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            company.CompanyActivity = true;
            var result = _validate.IsValid(company);
            if (result.IsValid)
            {
                _companyService.Add(company);
                return RedirectToAction("GetCompanyList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCompany(int id)
        {
            var company = _companyService.GetById(id);
            _companyService.Delete(company);
            return RedirectToAction("GetCompanyList");
        }
    }
}