using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class VehiclePicture:IEntity
    {
        public int VehiclePictureId { get; set; }
        public string VehiclePicturePath { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
