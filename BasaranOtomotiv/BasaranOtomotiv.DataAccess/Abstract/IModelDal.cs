using BasaranOtomotiv.Core.DataAccess;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.DataAccess.Abstract
{
    public interface IModelDal:IEntityRepository<Model>
    {
    }
}
