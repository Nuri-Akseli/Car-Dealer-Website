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
    public class AdminCategoryController : Controller
    {
        ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        Validate _validate = new Validate(new CategoryValidatior(InstanceFactory.GetInstance<ICategoryService>()));
        // GET: AdminCategory
        public ActionResult GetCategoryList()
        {
            return View(_categoryService.GetAll());
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            return View(_categoryService.GetById(id));
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var result = _validate.IsValid(category);
            if (result.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("GetCategoryList");
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
        public ActionResult UpdateCategoryActivity(int id)
        {
            var category = _categoryService.GetById(id);
            if (category.CategoryActivity)
            {
                category.CategoryActivity = false;
            }
            else
            {
                category.CategoryActivity = true;
            }
            _categoryService.Update(category);
            return RedirectToAction("GetCategoryList");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.CategoryActivity = true;
            var result = _validate.IsValid(category);
            if (result.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            return RedirectToAction("GetCategoryList");
        }

    }
}