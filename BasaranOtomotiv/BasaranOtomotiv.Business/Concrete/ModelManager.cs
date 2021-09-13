using BasaranOtomotiv.Business.Abstract;
using BasaranOtomotiv.DataAccess.Abstract;
using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Concrete
{
    public class ModelManager:IModelService
    {
        IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public Model Add(Model model)
        {
            return _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetList();
        }

        public List<Model> GetAllByCompany(int companyId)
        {
            return _modelDal.GetList(model => model.CompanyId == companyId);
        }

        public Model GetById(int id)
        {
            return _modelDal.Get(model => model.ModelId == id);
        }

        public Model Update(Model model)
        {
            return _modelDal.Update(model);
        }
    }
}
