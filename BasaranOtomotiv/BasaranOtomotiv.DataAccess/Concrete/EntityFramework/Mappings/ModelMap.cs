using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ModelMap: EntityTypeConfiguration<Model>
    {
        public ModelMap()
        {
            ToTable(@"Models", @"dbo");
            HasKey(model=>model.ModelId);
            HasMany(model=>model.Vehicles);
            HasMany(model => model.Engines);

            Property(model => model.ModelId).HasColumnName("ModelId");
            Property(model => model.ModelName).HasColumnName("ModelName");
            Property(model=>model.ModelActivity).HasColumnName("ModelActivity");
            Property(model=>model.CompanyId).HasColumnName("CompanyId");
        }
    }
}
