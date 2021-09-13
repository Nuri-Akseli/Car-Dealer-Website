using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class Company:IEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public bool CompanyActivity { get; set; }

        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
