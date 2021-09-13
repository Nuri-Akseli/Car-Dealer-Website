using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserMail { get; set; }
        public string UserPhoto { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public bool UserActivity { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
