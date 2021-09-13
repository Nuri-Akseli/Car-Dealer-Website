using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.DependancyResolvers.Ninject;
using BasaranOtomotiv.Business.ValidationRules.FluentValidation;
using BasaranOtomotiv.Core.Utilities.Validation.FluentValidation;
using BasaranOtomotiv.Entities.ComplexTypes;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BasaranOtomotiv.MVCUI.Controllers.Admin
{
    public class AdminProductController : Controller
    {
        ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        ISubCategoryService _subCategoryService = InstanceFactory.GetInstance<ISubCategoryService>();
        ICompanyService _companyService = InstanceFactory.GetInstance<ICompanyService>();
        IModelService _modelService = InstanceFactory.GetInstance<IModelService>();
        IEngineService _engineService = InstanceFactory.GetInstance<IEngineService>();
        IVehicleService _vehicleService = InstanceFactory.GetInstance<IVehicleService>();
        IVehiclePictureService _vehiclePictureService = InstanceFactory.GetInstance<IVehiclePictureService>();
        Validate _validate = new Validate(new ProductValidatior(InstanceFactory.GetInstance<IVehicleService>()));
        // GET: AdminProduct
        [HttpGet]
        public ActionResult GetCategory()
        {

            List<SelectListItem> categoryValues = (from category in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = category.CategoryName,
                                                       Value = category.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;
            return View();
        }
        [HttpPost]
        public ActionResult GetCategory(int categoryId)
        {
            TempData["categoryId"] = categoryId;
            TempData.Keep();
            return RedirectToAction("GetSubCategory");
        }
        [HttpGet]
        public ActionResult GetSubCategory()
        {

            List<SelectListItem> subCategoryValues = (from subCategory in _subCategoryService.GetAllByCategory((int)TempData["categoryId"])
                                                      select new SelectListItem
                                                      {
                                                          Text = subCategory.SubCategoryName,
                                                          Value = subCategory.SubCategoryId.ToString()
                                                      }).ToList();
            ViewBag.subCategories = subCategoryValues;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult GetSubCategory(int subCategoryId)
        {
            TempData["subCategoryId"] = subCategoryId;
            TempData.Keep();
            return RedirectToAction("GetCompany");
        }
        [HttpGet]
        public ActionResult GetCompany()
        {
            List<SelectListItem> companyValues = (from company in _companyService.GetAllBySubCategory((int)TempData["subCategoryId"])
                                                  select new SelectListItem
                                                  {
                                                      Text = company.CompanyName,
                                                      Value = company.CompanyId.ToString()
                                                  }).ToList();
            ViewBag.companies = companyValues;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult GetCompany(int companyId)
        {
            TempData["companyId"] = companyId;
            TempData.Keep();
            return RedirectToAction("GetModel");
        }
        [HttpGet]
        public ActionResult GetModel()
        {
            List<SelectListItem> modelValues = (from model in _modelService.GetAllByCompany((int)TempData["companyId"])
                                                select new SelectListItem
                                                {
                                                    Text = model.ModelName,
                                                    Value = model.ModelId.ToString()
                                                }).ToList();
            TempData.Keep();
            ViewBag.models = modelValues;
            return View();
        }
        [HttpPost]
        public ActionResult GetModel(int modelId)
        {
            TempData["modelId"] = modelId;
            TempData.Keep();
            return RedirectToAction("GetEngine");
        }
        [HttpGet]
        public ActionResult GetEngine()
        {
            List<SelectListItem> engineValues = (from engine in _engineService.GetAllByModel((int)TempData["modelId"])
                                                 select new SelectListItem
                                                 {
                                                     Text = engine.EngineName,
                                                     Value = engine.EngineId.ToString()
                                                 }).ToList();
            ViewBag.engines = engineValues;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult GetEngine(int engineId)
        {
            TempData["engineId"] = engineId;
            TempData.Keep();
            return RedirectToAction("AddProduct");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(FullVehicle fullVehicle, IEnumerable<HttpPostedFileBase> files)
        {
            fullVehicle.Vehicle.UserId = (int)Session["UserId"];
            fullVehicle.Vehicle.VehicleActivity = true;
            fullVehicle.Vehicle.VehicleTime = DateTime.Now;

            fullVehicle.Vehicle.CategoryId = (int)TempData["categoryId"];
            fullVehicle.Vehicle.SubCategoryId = (int)TempData["subCategoryId"];
            fullVehicle.Vehicle.CompanyId = (int)TempData["companyId"];
            fullVehicle.Vehicle.ModelId = (int)TempData["modelId"];
            fullVehicle.Vehicle.EngineId = (int)TempData["engineId"];

            var result = _validate.IsValid(fullVehicle.Vehicle);
            if (result.IsValid && Request.Files.Count > 0)
            {
                _vehicleService.Add(fullVehicle.Vehicle);
                
                fullVehicle.VehiclePicture.VehicleId = _vehicleService.GetByVehiclePlate(fullVehicle.Vehicle.VehiclePlate).VehicleId;
                int count = 0;
                foreach (var file in files)
                {
                    if (file.ContentLength > 0)
                    {
                        string path = "~/Templates/images/VehiclePicture/" +count.ToString() + fullVehicle.VehiclePicture.VehicleId.ToString()+ fullVehicle.Vehicle.VehiclePlate + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath(path));
                        fullVehicle.VehiclePicture.VehiclePicturePath = "/Templates/images/VehiclePicture/" +count.ToString()+ fullVehicle.VehiclePicture.VehicleId.ToString() + fullVehicle.Vehicle.VehiclePlate + Path.GetExtension(file.FileName);
                        _vehiclePictureService.Add(fullVehicle.VehiclePicture);
                        count++;

                    }

                }
               
                return RedirectToAction("GetProductList");

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


        public ActionResult GetProductList(int page=1)
        {
            return View(_vehicleService.GetAll().ToPagedList(page,10));
        }
        public ActionResult GetShowCaseList()
        {
            return View(_vehicleService.GetShowCases());
        }

        public ActionResult ChangeProductActivity(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle.VehicleActivity)
            {
                vehicle.VehicleActivity = false;
            }
            else
            {
                vehicle.VehicleActivity = true;
            }
            _vehicleService.Update(vehicle);
            return RedirectToAction("GetProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            DeleteImages(id);
            _vehiclePictureService.DeleteByVehicleId(id);
            _vehicleService.Delete(_vehicleService.GetById(id));
            return RedirectToAction("GetProductList");
        }
        private void DeleteImages(int id)
        {
            var images = _vehiclePictureService.GetListByVehicleId(id);
            foreach (var item in images)
            {
                var imagePath = Path.Combine(Server.MapPath("~"), item.VehiclePicturePath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }
    }
}