using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class EngineMap: EntityTypeConfiguration<Engine>
    {
        public EngineMap()
        {
            ToTable(@"Engines", @"dbo");
            HasKey(engine => engine.EngineId);
            HasMany(engine => engine.Vehicles);

            Property(engine => engine.EngineId).HasColumnName("EngineId");
            Property(engine => engine.EngineName).HasColumnName("EngineName");
            Property(engine=>engine.EngineActivity).HasColumnName("EngineActivity");
            Property(engine=>engine.ModelId).HasColumnName("ModelId");
        }
    }
}
