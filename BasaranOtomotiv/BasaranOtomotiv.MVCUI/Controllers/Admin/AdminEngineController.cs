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
    public class AdminEngineController : Controller
    {
        IEngineService _engineService = InstanceFactory.GetInstance<IEngineService>();
        IModelService _modelService = InstanceFactory.GetInstance<IModelService>();
        Validate _validate = new Validate(new EngineValidatior());
        // GET: AdminEngine

        public ActionResult GetEngineList()
        {
            return View(_engineService.GetAll());
        }

        public ActionResult UpdateEngineActivity(int id)
        {
            var engine = _engineService.GetById(id);
            if (engine.EngineActivity)
            {
                engine.EngineActivity = false;
            }
            else
            {
                engine.EngineActivity = true;
            }
            _engineService.Update(engine);
            return RedirectToAction("GetEngineList");
        }

        [HttpGet]
        public ActionResult UpdateEngine(int id)
        {
            return View(_engineService.GetById(id));
        }
        [HttpPost]
        public ActionResult UpdateEngine(Engine engine)
        {
            var result = _validate.IsValid(engine);
            if (result.IsValid)
            {
                _engineService.Update(engine);
                return RedirectToAction("GetEngineList");
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
        public ActionResult AddEngine()
        {
            List<SelectListItem> modelValues = (from model in _modelService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = model.ModelName,
                                                    Value = model.ModelId.ToString()
                                                }).ToList();
            ViewBag.models = modelValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddEngine(Engine engine)
        {
            engine.EngineActivity = true;
            var result = _validate.IsValid(engine);
            if (result.IsValid)
            {
                _engineService.Add(engine);
                return RedirectToAction("GetEngineList");
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
            var engine = _engineService.GetById(id);
            _engineService.Delete(engine);
            return RedirectToAction("GetEngineList");
        }
    }
}