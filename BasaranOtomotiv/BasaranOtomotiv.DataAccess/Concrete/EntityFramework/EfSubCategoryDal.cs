using BasaranOtomotiv.Core.DataAccess.EntityFramework;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Concrete.EntityFramework
{
    public class EfSubCategoryDal : EfEntityRepositoryBase<SubCategory, BasaranContext>, ISubCategoryDal
    {
    }
}
