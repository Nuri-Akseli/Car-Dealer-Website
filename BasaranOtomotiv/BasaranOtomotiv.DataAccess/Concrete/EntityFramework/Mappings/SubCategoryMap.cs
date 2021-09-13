using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SubCategoryMap: EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable(@"SubCategories", @"dbo");
            HasKey(subCategory=>subCategory.SubCategoryId);
            HasMany(subCategory => subCategory.Vehicles);
            HasMany(subCategory => subCategory.Companies);

            Property(subCategory => subCategory.SubCategoryId).HasColumnName("SubCategoryId");
            Property(subCategory => subCategory.SubCategoryName).HasColumnName("SubCategoryName");
            Property(subCategory => subCategory.SubCategoryActivity).HasColumnName("SubCategoryActivity");
            Property(subCategory => subCategory.CategoryId).HasColumnName("CategoryId");
        }
    }
}
