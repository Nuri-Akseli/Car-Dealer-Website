using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface IVehiclePictureService
    {
        List<VehiclePicture> GetAll();
        List<VehiclePicture> GetListByVehicleId(int vehicleId);
        VehiclePicture GetById(int id);
        VehiclePicture Add(VehiclePicture vehiclePicture);
        VehiclePicture Update(VehiclePicture vehiclePicture);
        void Delete(VehiclePicture vehiclePicture);
        void DeleteByVehicleId(int vehicleId);
    }
}
