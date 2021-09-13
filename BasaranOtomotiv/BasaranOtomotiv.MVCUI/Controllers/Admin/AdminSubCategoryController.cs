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
    public class AdminSubCategoryController : Controller
    {
        ISubCategoryService _subCategoryService = InstanceFactory.GetInstance<ISubCategoryService>();
        ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        Validate _validate = new Validate(new SubCategoryValidatior(InstanceFactory.GetInstance<ISubCategoryService>()));
        // GET: AdminSubCategory
        public ActionResult GetSubCategoryList()
        {
            var subCategories = _subCategoryService.GetAll();
            return View(subCategories);
        }

        public ActionResult UpdateSubCategoryActivity(int id)
        {
            var subCategory = _subCategoryService.GetById(id);
            if (subCategory.SubCategoryActivity)
            {
                subCategory.SubCategoryActivity = false;
            }
            else
            {
                subCategory.SubCategoryActivity = true;
            }
            _subCategoryService.Update(subCategory);
            return RedirectToAction("GetSubCategoryList");
        }

        [HttpGet]
        public ActionResult UpdateSubCategory(int id)
        {
            return View(_subCategoryService.GetById(id));
        }
        [HttpPost]
        public ActionResult UpdateSubCategory(SubCategory subCategory)
        {
            var result = _validate.IsValid(subCategory);
            if (result.IsValid)
            {
                _subCategoryService.Update(subCategory);
                return RedirectToAction("GetSubCategoryList");
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
        public ActionResult AddSubCategory()
        {
            List<SelectListItem> categoryValues = (from category in _categoryService.GetAll()
                                                   select new SelectListItem { 
                                                       Text=category.CategoryName,
                                                       Value=category.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategory subCategory)
        {
            subCategory.SubCategoryActivity = true;
            var result = _validate.IsValid(subCategory);
            if (result.IsValid)
            {
                _subCategoryService.Add(subCategory);
                return RedirectToAction("GetSubCategoryList");
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

        public ActionResult DeleteCategory(int id)
        {
            var subCategory = _subCategoryService.GetById(id);
            _subCategoryService.Delete(subCategory);
            return RedirectToAction("GetSubCategoryList");
        }
    }
}