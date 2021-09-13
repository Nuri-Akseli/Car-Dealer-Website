using BasaranOtomotiv.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaranOtomotiv.Business.Abstract
{
    public interface IEngineService
    {
        List<Engine> GetAll();
        List<Engine> GetAllByModel(int modelId);
        Engine GetById(int id);
        Engine Add(Engine engine);
        Engine Update(Engine engine);
        void Delete(Engine engine);
    }
}
