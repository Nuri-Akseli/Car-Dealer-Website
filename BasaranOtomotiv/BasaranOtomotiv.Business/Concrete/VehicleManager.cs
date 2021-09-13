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
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public Vehicle Add(Vehicle vehicle)
        {
            return _vehicleDal.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetList(vehicle=>vehicle.VehicleIsShowCase==false);
        }

        public Vehicle GetById(int id)
        {
            return _vehicleDal.Get(vehicle=>vehicle.VehicleId==id);
        }

        public Vehicle GetByVehiclePlate(string plate)
        {
            return _vehicleDal.Get(vehicle => vehicle.VehiclePlate.Contains(plate.Trim()));
        }

        public List<Vehicle> GetShowCases()
        {
            
            return _vehicleDal.GetList(vehicle => vehicle.VehicleIsShowCase == true);
        }

        public List<Vehicle> GetVehiclesByActivityAndShowCase(bool isActive, bool isShowCase)
        {
            return _vehicleDal.GetList(vehicle => vehicle.VehicleActivity == isActive && vehicle.VehicleIsShowCase == isShowCase);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            return _vehicleDal.Update(vehicle);
        }
    }
}
