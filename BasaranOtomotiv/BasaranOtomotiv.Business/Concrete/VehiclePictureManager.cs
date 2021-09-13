using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Concrete
{
    public class VehiclePictureManager : IVehiclePictureService
    {
        IVehiclePictureDal _vehiclePictureDal;
        public VehiclePictureManager(IVehiclePictureDal vehiclePictureDal)
        {
            _vehiclePictureDal = vehiclePictureDal;
        }
        public VehiclePicture Add(VehiclePicture vehiclePicture)
        {
            return _vehiclePictureDal.Add(vehiclePicture);
        }

        public void Delete(VehiclePicture vehiclePicture)
        {
            _vehiclePictureDal.Delete(vehiclePicture);
        }

        public void DeleteByVehicleId(int vehicleId)
        {
            var vehiclePictures = GetListByVehicleId(vehicleId);
            foreach (var item in vehiclePictures)
            {
                Delete(item);
            }
        }

        public List<VehiclePicture> GetAll()
        {
            return _vehiclePictureDal.GetList();
        }

        public VehiclePicture GetById(int id)
        {
            return _vehiclePictureDal.Get(vehiclePicture => vehiclePicture.VehiclePictureId == id);
        }

        public List<VehiclePicture> GetListByVehicleId(int vehicleId)
        {
            return _vehiclePictureDal.GetList(vehicle => vehicle.VehicleId == vehicleId);
        }

        public VehiclePicture Update(VehiclePicture vehiclePicture)
        {
            return _vehiclePictureDal.Update(vehiclePicture);
        }
    }
}
