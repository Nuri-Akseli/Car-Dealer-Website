using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(category=>category.CategoryId);
            HasMany(category => category.Vehicles);
            HasMany(category => category.SubCategories);

            Property(category => category.CategoryId).HasColumnName("CategoryId");
            Property(category => category.CategoryName).HasColumnName("CategoryName");
            Property(category => category.CategoryActivity).HasColumnName("CategoryActivity");
            
        }
    }
}
