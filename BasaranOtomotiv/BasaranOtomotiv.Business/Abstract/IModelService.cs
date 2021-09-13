using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll();
        List<Model> GetAllByCompany(int companyId);
        Model GetById(int id);
        Model Add(Model model);
        Model Update(Model model);
        void Delete(Model model);
    }
}
