using _3DModels.Models;
using _3DModels.Repositories;
using System.Collections.Generic;

namespace _3DModels.Services
{
    public class ModelValidatorService : IModelValidatorService
    {
        private readonly ModelValidatorRepository _repository;

        public ModelValidatorService(ModelValidatorRepository repository)
        {
            _repository = repository;
        }

        public void AddModel(ThreeDModel model)
        {
            _repository.AddModel(model);
        }

        public IEnumerable<ThreeDModel> GetAllModels()
        {
            return _repository.GetAllModels();
        }

        public ThreeDModel GetModelById(int id)
        {
            return _repository.GetModelById(id);
        }

        public bool UpdateModel(ThreeDModel model)
        {
            return _repository.UpdateModel(model);
        }

        public bool DeleteModel(int id)
        {
            return _repository.DeleteModel(id);
        }
    }
}
