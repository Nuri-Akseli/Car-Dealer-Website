using BasaranOtomotiv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Entities.Concerete
{
    public class Vehicle:IEntity
    {
        public int VehicleId { get; set; }
        public string VehicleHeading { get; set; }
        public string VehicleDetail { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int EngineId { get; set; }
        public virtual Engine Engine { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime VehicleTime { get; set; }
        public int VehicleDistance { get; set; }
        public string VehicleDistanceUnit { get; set; }
        public int VehicleValue { get; set; }
        public string VehicleValueUnit { get; set; }
        public bool VehicleIsShowCase { get; set; }
        public bool VehicleActivity { get; set; }
        public string VehiclePlate { get; set; }


        public virtual ICollection<VehiclePicture> VehiclePictures { get; set; }
    }
}
