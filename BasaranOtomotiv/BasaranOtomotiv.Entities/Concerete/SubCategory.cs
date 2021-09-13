using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class SubCategory:IEntity
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool SubCategoryActivity { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
