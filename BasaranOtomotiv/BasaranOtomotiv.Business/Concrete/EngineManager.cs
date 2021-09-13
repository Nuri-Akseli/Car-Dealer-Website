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
    public class EngineManager:IEngineService
    {
        IEngineDal _engineDal;
        public EngineManager(IEngineDal engineDal)
        {
            _engineDal = engineDal;
        }

        public Engine Add(Engine engine)
        {
            return _engineDal.Add(engine);
        }

        public void Delete(Engine engine)
        {
            _engineDal.Delete(engine);
        }

        public List<Engine> GetAll()
        {
            return _engineDal.GetList();
        }

        public List<Engine> GetAllByModel(int modelId)
        {
            return _engineDal.GetList(engine => engine.ModelId == modelId).ToList();
        }

        public Engine GetById(int id)
        {
            return _engineDal.Get(engine=>engine.EngineId==id);
        }

        public Engine Update(Engine engine)
        {
            return _engineDal.Update(engine);
        }
    }
}
