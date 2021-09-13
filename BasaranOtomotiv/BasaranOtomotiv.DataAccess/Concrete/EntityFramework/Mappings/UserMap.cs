using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(user=>user.UserId);
            HasMany(user => user.Vehicles);

            Property(user=>user.UserName).HasColumnName("UserName");
            Property(user => user.UserSurname).HasColumnName("UserSurname");
            Property(user => user.UserMail).HasColumnName("UserMail");
            Property(user => user.UserActivity).HasColumnName("UserActivity");
            Property(user => user.UserPassword).HasColumnName("UserPassword");
            Property(user => user.UserPhoto).HasColumnName("UserPhoto");
            Property(user => user.UserRole).HasColumnName("UserRole");
        }
    }
}
