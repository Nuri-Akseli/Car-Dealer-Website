using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.Business.Concrete;
using BasaranOtomotiv.Core.Utilities.Log.Abstract;
using BasaranOtomotiv.Core.Utilities.Log.Concrete;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.DependancyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<ICompanyService>().To<CompanyManager>().InSingletonScope();
            Bind<IEngineService>().To<EngineManager>().InSingletonScope();
            Bind<IModelService>().To<ModelManager>().InSingletonScope();
            Bind<ISubCategoryService>().To<SubCategoryManager>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<IVehicleService>().To<VehicleManager>().InSingletonScope();
            Bind<IVehiclePictureService>().To<VehiclePictureManager>().InSingletonScope();


            Bind<IUserDal>().To<EfUserDal>();
            Bind<ICategoryDal>().To<EfCategoryDal>();
            Bind<ISubCategoryDal>().To<EfSubCategoryDal>();
            Bind<ICompanyDal>().To<EfCompanyDal>();
            Bind<IModelDal>().To<EfModelDal>();
            Bind<IEngineDal>().To<EfEngineDal>();
            Bind<IVehicleDal>().To<EfVehicleDal>();
            Bind<IVehiclePictureDal>().To<EfVehiclePictureDal>();


            Bind<ILog>().To<Log>();




            Bind<DbContext>().To<BasaranContext>();
        }
    }
}
