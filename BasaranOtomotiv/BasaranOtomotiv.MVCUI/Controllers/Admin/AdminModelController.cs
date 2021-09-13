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
    public class AdminModelController : Controller
    {
        IModelService _modelService = InstanceFactory.GetInstance<IModelService>();
        ICompanyService _companyService = InstanceFactory.GetInstance<ICompanyService>();
        Validate _validate = new Validate(new ModelValidatior());
        // GET: AdminModel
    
        public ActionResult GetModelList()
        {
            return View(_modelService.GetAll());
        }

        public ActionResult UpdateModelActivity(int id)
        {
            var model = _modelService.GetById(id);
            if (model.ModelActivity)
            {
                model.ModelActivity = false;
            }
            else
            {
                model.ModelActivity = true;
            }
            _modelService.Update(model);
            return RedirectToAction("GetModelList");
        }

        [HttpGet]
        public ActionResult UpdateModel(int id)
        {
            return View(_modelService.GetById(id));
        }
        [HttpPost]
        public ActionResult UpdateModel(Model model)
        {
            var result = _validate.IsValid(model);
            if (result.IsValid)
            {
                _modelService.Update(model);
                return RedirectToAction("GetModelList");
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
        public ActionResult AddModel()
        {
            List<SelectListItem> modelValues = (from company in _companyService.GetAll()
                                                      select new SelectListItem
                                                      {
                                                          Text = company.CompanyName,
                                                          Value = company.CompanyId.ToString()
                                                      }).ToList();
            ViewBag.models = modelValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddModel(Model model)
        {
            model.ModelActivity = true;
            var result = _validate.IsValid(model);
            if (result.IsValid)
            {
                _modelService.Add(model);
                return RedirectToAction("GetModelList");
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

        public ActionResult DeleteModel(int id)
        {
            var model = _modelService.GetById(id);
            _modelService.Delete(model);
            return RedirectToAction("GetModelList");
        }
    }
}