using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasaranOtomotiv.MVCUI.Controllers.Admin
{
    public class DashBoardWelcomeController : Controller
    {
        // GET: DashBoardWelcome
        public ActionResult Index()
        {
            return View();
        }
    }
}