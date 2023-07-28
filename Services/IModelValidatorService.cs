using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Services
{
    public interface IModelValidatorService
    {
        void AddModel(ThreeDModel model);
        IEnumerable<ThreeDModel> GetAllModels();
        ThreeDModel GetModelById(int id);
        bool UpdateModel(ThreeDModel model);
        bool DeleteModel(int id);
    }
}
