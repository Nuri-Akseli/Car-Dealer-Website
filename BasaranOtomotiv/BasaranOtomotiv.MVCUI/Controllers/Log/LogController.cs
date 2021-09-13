using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.DependancyResolvers.Ninject;
using BasaranOtomotiv.Core.Utilities.Log.Abstract;
using BasaranOtomotiv.Core.Utilities.Log.Concrete;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasaranOtomotiv.MVCUI.Controllers.Log
{
    [AllowAnonymous]
    public class LogController : Controller
    {
        IUserService _UserService = InstanceFactory.GetInstance<IUserService>();
        ILog _log = InstanceFactory.GetInstance<ILog>();
        // GET: Log
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            var userInfo = _UserService.GetByMailAndPasswordAndActivity(user.UserMail, user.UserPassword,true);
            if (userInfo!=null)
            {
                _log.LogIn(userInfo.UserId);
                return RedirectToAction("Index", "DashBoardWelcome");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
            
        }
        public ActionResult LogOut()
        {
            _log.Logout();
            return RedirectToAction("Index", "UserView");
        }
    }
}