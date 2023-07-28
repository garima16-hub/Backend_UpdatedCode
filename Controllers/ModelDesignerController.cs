using _3DModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelDesignerController : ControllerBase
    {
        private List<ModelDesigner> modelDesigners;
        private readonly ModelDbContext _context;



        public ModelDesignerController()
        {
            modelDesigners = new List<ModelDesigner>();
        }
        public ModelDesignerController(ModelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void AddModelDesigner(ModelDesigner modelDesigner)
        {
            // You may consider generating a unique Id for the modelDesigner here.
            modelDesigners.Add(modelDesigner);
            Console.WriteLine("Model Designer added successfully.");
        }

        [HttpGet("{id}")]
        public ModelDesigner GetModelDesignerById(int id)
        {
            return modelDesigners.Find(d => d.Id == id);
        }

        [HttpGet]
        public List<ModelDesigner> GetAllModelDesigners()
        {
            return modelDesigners;
        }

        [HttpPut]
        public void UpdateModelDesigner(ModelDesigner updatedModelDesigner)
        {
            ModelDesigner modelDesignerToUpdate = modelDesigners.Find(d => d.Id == updatedModelDesigner.Id);
            if (modelDesignerToUpdate != null)
            {
                modelDesignerToUpdate.Name = updatedModelDesigner.Name;
                modelDesignerToUpdate.Description = updatedModelDesigner.Description;
                modelDesignerToUpdate.IsActive = updatedModelDesigner.IsActive;
                modelDesignerToUpdate.DateModified = DateTime.Now;
                modelDesignerToUpdate.LastModifiedBy = updatedModelDesigner.LastModifiedBy;
            }
            Console.WriteLine("Model Designer updated successfully.");
        }

        [HttpDelete("{id}")]
        public void DeleteModelDesigner(int id)
        {
            modelDesigners.RemoveAll(d => d.Id == id);
            Console.WriteLine("Model Designer deleted successfully.");
        }
    }
}
