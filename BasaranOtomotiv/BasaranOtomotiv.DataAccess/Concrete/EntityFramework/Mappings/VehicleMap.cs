using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class VehicleMap:EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            ToTable(@"Vehicles", @"dbo");
            HasKey(vehicle=>vehicle.VehicleId);
            HasMany(vehicle => vehicle.VehiclePictures);


            Property(vehicle => vehicle.VehicleId).HasColumnName("VehicleId");
            Property(vehicle => vehicle.VehicleHeading).HasColumnName("VehicleHeading");
            Property(vehicle => vehicle.VehicleDetail).HasColumnName("VehicleDetail");
            Property(vehicle => vehicle.VehicleActivity).HasColumnName("VehicleActivity");
            Property(vehicle => vehicle.VehicleDistance).HasColumnName("VehicleDistance");
            Property(vehicle => vehicle.VehicleDistanceUnit).HasColumnName("VehicleDistanceUnit");
            Property(vehicle => vehicle.VehicleIsShowCase).HasColumnName("VehicleIsShowCase");
            Property(vehicle => vehicle.VehiclePlate).HasColumnName("VehiclePlate");
            Property(vehicle => vehicle.VehicleTime).HasColumnName("VehicleTime");
            Property(vehicle => vehicle.VehicleValue).HasColumnName("VehicleValue");
            Property(vehicle => vehicle.VehicleValueUnit).HasColumnName("VehicleValueUnit");
            Property(vehicle => vehicle.UserId).HasColumnName("UserId");
            Property(vehicle => vehicle.SubCategoryId).HasColumnName("SubCategoryId");
            Property(vehicle => vehicle.ModelId).HasColumnName("ModelId");
            Property(vehicle => vehicle.EngineId).HasColumnName("EngineId");
            Property(vehicle => vehicle.CompanyId).HasColumnName("CompanyId");
            Property(vehicle => vehicle.CategoryId).HasColumnName("CategoryId");
            
        }
    }
}
