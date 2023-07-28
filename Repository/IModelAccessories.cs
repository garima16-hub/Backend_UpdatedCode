using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Repository
{
    public interface IModelAccessories
    {
        IEnumerable<ModelAccessories> GetModelAccessories();
        ModelAccessories GetModelAccessoriesById(int id);
        void AddModelAccessories(ModelAccessories modelAccessories);
        void UpdateModelAccessories(ModelAccessories modelAccessories);
        void DeleteModelAccessories(int id);
    }
}
