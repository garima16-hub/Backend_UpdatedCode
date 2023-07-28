using _3DModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace _3DModels.Repositories
{
    public class ModelValidatorRepository
    {
        private List<ThreeDModel> modelList;
        private readonly ModelDbContext _context;

        public ModelValidatorRepository(ModelDbContext context)
        {
            _context = context;
        }

        public ModelValidatorRepository()
        {
            modelList = new List<ThreeDModel>();
        }

        public void AddModel(ThreeDModel model)
        {
            modelList.Add(model);
        }

        public IEnumerable<ThreeDModel> GetAllModels()
        {
            return modelList;
        }

        public ThreeDModel GetModelById(int id)
        {
            return modelList.FirstOrDefault(m => m.ID == id);
        }

        public bool UpdateModel(ThreeDModel model)
        {
            ThreeDModel existingModel = modelList.FirstOrDefault(m => m.ID == model.ID);
            if (existingModel != null)
            {
                existingModel.ModelName = model.ModelName;
                existingModel.NumberOfVertices = model.NumberOfVertices;
                return true;
            }
            return false;
        }

        public bool DeleteModel(int id)
        {
            ThreeDModel modelToRemove = modelList.FirstOrDefault(m => m.ID == id);
            if (modelToRemove != null)
            {
                modelList.Remove(modelToRemove);
                return true;
            }
            return false;
        }
    }
}