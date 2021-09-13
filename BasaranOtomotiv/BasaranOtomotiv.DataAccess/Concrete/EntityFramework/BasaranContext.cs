using BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework
{
    public class BasaranContext:DbContext
    {
        public BasaranContext()
        {
            Database.SetInitializer<BasaranContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePicture> VehiclePictures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new EngineMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehiclePictureMap());
        }
    }
}
