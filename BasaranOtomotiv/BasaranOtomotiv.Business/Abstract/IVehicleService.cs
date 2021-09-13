using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetVehiclesByActivityAndShowCase(bool isActive,bool isShowCase);
        List<Vehicle> GetShowCases();
        Vehicle GetById(int id);
        Vehicle GetByVehiclePlate(string plate);
        Vehicle Add(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);
    }
}
