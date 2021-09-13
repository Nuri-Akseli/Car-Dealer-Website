using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class Model:IEntity
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public bool ModelActivity { get; set; }

        public virtual ICollection<Engine> Engines { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
