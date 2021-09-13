using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class Engine:IEntity
    {
        public int EngineId { get; set; }
        public string EngineName { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public bool EngineActivity { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
