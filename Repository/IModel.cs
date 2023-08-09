using _3DModels.Models;
using System.Collections.Generic;
using _3DModels.Repository;
namespace _3DModels.Repository
{
    public interface IModel
    {

        public List<Model> GetAllModels();
        List<Model> GetModels(string category, string subcategory, int count);

        Model GetModel(int id);

        ModelAccessories GetModelAccessory(int id);
    }
}
