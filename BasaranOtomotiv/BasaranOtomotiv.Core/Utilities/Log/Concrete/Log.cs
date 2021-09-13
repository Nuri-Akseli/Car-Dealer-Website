using BasaranOtomotiv.Core.Utilities.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;

namespace BasaranOtomotiv.Core.Utilities.Log.Concrete
{
    public class Log : Page, ILog
    {
        public void LogIn(int UserId)
        {
            FormsAuthentication.SetAuthCookie(UserId.ToString(), false);
            Session["UserId"] = UserId;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
        }
    }
}
