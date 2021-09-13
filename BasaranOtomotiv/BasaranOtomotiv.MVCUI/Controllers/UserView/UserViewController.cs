using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.DependancyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BasaranOtomotiv.MVCUI.Controllers.UserView
{
    [AllowAnonymous]
    public class UserViewController : Controller
    {
        IVehicleService _vehicleService = InstanceFactory.GetInstance<IVehicleService>();
        // GET: UserView
        public ActionResult Index()
        {
            return View(_vehicleService.GetShowCases());
        }
        public ActionResult Vehicles()
        {
            return View(_vehicleService.GetVehiclesByActivityAndShowCase(true,false));
        }
        public ActionResult VehicleDetail(int id)
        {
            return View(_vehicleService.GetById(id));
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}