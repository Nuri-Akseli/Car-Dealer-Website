using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetALL();
        List<User> GetAllExceptHimself(int id);
        User GetByMailAndPasswordAndActivity(string mail,string password,bool activity);
        User GetByMail(string mail);
        User GetById(int id);
        User Add(User user);
        User Update(User user);

    }
}
