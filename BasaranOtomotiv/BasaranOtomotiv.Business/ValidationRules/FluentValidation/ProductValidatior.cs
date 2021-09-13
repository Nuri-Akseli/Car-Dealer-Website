using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Vehicle>
    {
        IVehicleService _vehicleService;
        public ProductValidatior(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;

            RuleFor(vehicle => vehicle.VehicleHeading).NotEmpty().WithMessage("Başlık Boş Geçilemez!");
            RuleFor(vehicle => vehicle.VehicleHeading).MaximumLength(50).WithMessage("Başlık 50 karakterden fazla olamaz!");
            RuleFor(vehicle => vehicle.VehicleHeading).MinimumLength(5).WithMessage("Başlık 5 karakterden düşük olamaz!");

            RuleFor(vehicle => vehicle.VehicleDetail).NotEmpty().WithMessage("Detaylar Boş Geçilemez!");
            RuleFor(vehicle => vehicle.VehicleDetail).MinimumLength(10).WithMessage("Detaylar 10 karakterden fazla olmalıdır!");

            RuleFor(vehicle => vehicle.VehicleDistance).GreaterThanOrEqualTo(0).WithMessage("Yol bilgisi 0 dan düşük olamaz!");

            RuleFor(vehicle => vehicle.VehicleValue).GreaterThanOrEqualTo(0).WithMessage("Ücret 0 dan küçük olamaz!");

            RuleFor(vehicle => vehicle.VehicleIsShowCase).Must(UpToSixCar).WithMessage("En Fazla 6 Tane Araç Vitrine Koyulabilir!");

            RuleFor(vehicle => vehicle.VehiclePlate).NotEmpty().WithMessage("Plaka Boş Geçilemez!");
            RuleFor(vehicle => vehicle.VehiclePlate).MaximumLength(10).WithMessage("Plaka en fazla 10 karakter olabilir!");
            RuleFor(vehicle => vehicle.VehiclePlate).MinimumLength(4).WithMessage("Plaka en az 4 karakter olabilir!");
            RuleFor(vehicle => vehicle.VehiclePlate).Must(Unique).WithMessage("Plakalı Araç Zaten Sisteme Kayıtlı");

        }

        private bool Unique(string arg)
        {
            var result = _vehicleService.GetByVehiclePlate(arg);
            return result == null
                ? true
                : false;
        }

        private bool UpToSixCar(bool arg)
        {
            var result = _vehicleService.GetShowCases().Count;
            return result <= 6
                ? true
                : false;
        }
    }
}
