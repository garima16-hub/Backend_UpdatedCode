using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Repository
{
    public interface IModel
    {
        List<Model> GetAllModel();
       Model GetModelById(int ModelId);
        void CreateModel(Model model);
        void UpdateModel(Model model);
        void DeleteModel(int ModelId);
    }
}
