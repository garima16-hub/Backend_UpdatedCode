using _3DModels.Models;
using System;
using System.Collections.Generic;
using _3DModels.Repositories;

namespace _3DModels.Services
{

    public class ModelCoordinatorService
    {
        private readonly ModelCoordinatorRepository _modelCoordinatorRepository;

        public ModelCoordinatorService(ModelCoordinatorRepository modelCoordinatorRepository)
        {
            _modelCoordinatorRepository = modelCoordinatorRepository;
        }

        public IEnumerable<ModelCoordinator> GetAllModelCoordinators()
        {
            return _modelCoordinatorRepository.GetAllModelCoordinators();
        }

        public ModelCoordinator GetModelCoordinatorById(int id)
        {
            return _modelCoordinatorRepository.GetModelCoordinatorById(id);
        }

        public void AddModelCoordinator(ModelCoordinator modelCoordinator)
        {
            // Perform any business logic or validation before adding the modelCoordinator
            _modelCoordinatorRepository.AddModelCoordinator(modelCoordinator);
        }

        public void UpdateModelCoordinator(ModelCoordinator modelCoordinator)
        {
            // Perform any business logic or validation before updating the modelCoordinator
            _modelCoordinatorRepository.UpdateModelCoordinator(modelCoordinator);
        }

        public void DeleteModelCoordinator(int id)
        {
            // Perform any business logic before deleting the modelCoordinator
            _modelCoordinatorRepository.DeleteModelCoordinator(id);
        }

        // You can add more methods here to implement additional business logic or functionality related to ModelCoordinator entity
    }
}