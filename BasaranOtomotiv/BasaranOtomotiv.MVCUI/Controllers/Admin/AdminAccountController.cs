using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.Concrete;
using BasaranOtomotiv.Business.DependancyResolvers.Ninject;
using BasaranOtomotiv.Business.ValidationRules.FluentValidation;
using BasaranOtomotiv.Core.Utilities.Validation.FluentValidation;
using BasaranOtomotiv.DataAccess.Concrete.EntityFramework;
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
    public class AdminAccountController : Controller
    {
        IUserService _userService = InstanceFactory.GetInstance<IUserService>();
        Validate _validate = new Validate(new UserUpdateValidatior());
        Validate _validateAdd = new Validate(new UserValidatior(new UserManager(new EfUserDal())));
        // GET: AdminAccount
        [HttpGet]
        public ActionResult EditProfile()
        {
            
            return View(_userService.GetById((int)Session["UserId"]));
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            var result = _validate.IsValid(user);
            if (result.IsValid)
            {
                _userService.Update(user);
                return RedirectToAction("Index", "DashBoardWelcome");
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

        [Authorize(Roles = "Supervisor,Admin")]
        public ActionResult AllUsers(int page=1)
        {
            return View(_userService.GetAllExceptHimself((int)Session["UserId"]).ToPagedList(page,10));
        }
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpGet]
        public ActionResult AdminEditUser(int id)
        {
            
            return View(_userService.GetById(id));
        }
        [HttpPost]
        public ActionResult AdminEditUser(User user)
        {
            _userService.Update(user);
            return RedirectToAction("AllUsers");
        }
        [Authorize(Roles = "Supervisor,Admin")]
        public ActionResult ChangeUserActivity(int id)
        {
            var user = _userService.GetById(id);
            if (user.UserActivity)
            {
                user.UserActivity = false;
            }
            else
            {
                user.UserActivity = true;
            }
            _userService.Update(user);
            return RedirectToAction("AllUsers");
        }
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            user.UserPassword = "BASARANOTOMOTİV";
            user.UserActivity = true;
            var result = _validateAdd.IsValid(user);
            if (result.IsValid)
            {
                if (Request.Files.Count>0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension=Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Templates/images/UsersPicture/" + user.UserMail + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    user.UserPhoto = "/Templates/images/UsersPicture/" + user.UserMail + fileName + extension;

                }
                _userService.Add(user);
                return RedirectToAction("AllUsers");
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
    }
}