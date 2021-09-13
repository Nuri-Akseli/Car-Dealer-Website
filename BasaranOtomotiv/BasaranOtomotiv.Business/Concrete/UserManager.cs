using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Core.Utilities.Log.Abstract;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            
        }

        public User Add(User user)
        {
            return _userDal.Add(user);
        }

        public List<User> GetALL()
        {
            return _userDal.GetList();
        }

        public List<User> GetAllExceptHimself(int id)
        {
            return _userDal.GetList(user=>user.UserId!=id);
        }

        public User GetById(int id)
        {
            return _userDal.Get(user => user.UserId == id);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(user => user.UserMail == mail);
        }

        public User GetByMailAndPasswordAndActivity(string mail, string password,bool activity)
        {
            return _userDal.Get(user => user.UserMail == mail && user.UserPassword == password && user.UserActivity==true);
        }

        public User Update(User user)
        {
            return _userDal.Update(user);
        }

    }
}
