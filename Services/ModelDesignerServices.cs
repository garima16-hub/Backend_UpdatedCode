
using _3DModels.Models;
using _3DModels.Repositories;
using System;
using System.Collections.Generic;


namespace _3DModels.Services
{
    public class ModelDesignerService
    {
        private ModelDesignerRepository modelDesignerRepository;

        public ModelDesignerService()
        {
            modelDesignerRepository = new ModelDesignerRepository();
        }

        public void AddModelDesigner(ModelDesigner modelDesigner)
        {
            // You can add additional business logic or validation here before saving the model designer.
            modelDesignerRepository.AddModelDesigner(modelDesigner);
            Console.WriteLine("Model Designer added successfully.");
        }

        public ModelDesigner GetModelDesignerById(int id)
        {
            return modelDesignerRepository.GetModelDesignerById(id);
        }

        public List<ModelDesigner> GetAllModelDesigners()
        {
            return modelDesignerRepository.GetAllModelDesigners();
        }

        public void UpdateModelDesigner(ModelDesigner updatedModelDesigner)
        {
            // You can add additional business logic or validation here before updating the model designer.
            modelDesignerRepository.UpdateModelDesigner(updatedModelDesigner);
            Console.WriteLine("Model Designer updated successfully.");
        }

        public void DeleteModelDesigner(int id)
        {
            // You can add additional business logic or validation here before deleting the model designer.
            modelDesignerRepository.DeleteModelDesigner(id);
            Console.WriteLine("Model Designer deleted successfully.");
        }
    }
}

