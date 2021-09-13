using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.ComplexTypes
{
    public class FullVehicle
    {
        public Vehicle Vehicle { get; set; }
        public VehiclePicture VehiclePicture { get; set; }
    }
}
