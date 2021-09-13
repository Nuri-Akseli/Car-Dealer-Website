using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class VehiclePictureMap : EntityTypeConfiguration<VehiclePicture>
    {
        public VehiclePictureMap()
        {
            ToTable(@"VehiclePictures", @"dbo");
            HasKey(vehiclePicture=> vehiclePicture.VehiclePictureId);

            Property(vehiclePicture => vehiclePicture.VehiclePictureId).HasColumnName("VehiclePictureId");
            Property(vehiclePicture => vehiclePicture.VehiclePicturePath).HasColumnName("VehiclePicturePath");
            Property(vehiclePicture => vehiclePicture.VehicleId).HasColumnName("VehicleId");
        }
    }
}
