using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Core.Utilities.Log.Abstract
{
    public interface ILog
    {
        void LogIn(int UserId);
        void Logout();
    }
}
