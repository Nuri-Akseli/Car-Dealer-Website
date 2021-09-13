using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CompanyMap:EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            ToTable(@"Companies", @"dbo");
            HasKey(company => company.CompanyId);
            HasMany(company => company.Vehicles);
            HasMany(company => company.Models);

            Property(company => company.CompanyId).HasColumnName("CompanyId");
            Property(company => company.CompanyName).HasColumnName("CompanyName");
            Property(company => company.CompanyActivity).HasColumnName("CompanyActivity");
            Property(company=>company.SubCategoryId).HasColumnName("SubCategoryId");
        }
    }
}
