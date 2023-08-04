using _3DModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelDesignerController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public ModelDesignerController(ModelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddModelDesigner(ModelDesigner modelDesigner)
        {
            // You may consider generating a unique Id for the modelDesigner here.
            _context.ModelDesigners.Add(modelDesigner);
            _context.SaveChanges();
            Console.WriteLine("Model Designer added successfully.");
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetModelDesignerById(int id)
        {
            var modelDesigner = _context.ModelDesigners.FirstOrDefault(d => d.Id == id);
            if (modelDesigner == null)
            {
                return NotFound();
            }
            return Ok(modelDesigner);
        }

        [HttpGet]
        public IActionResult GetAllModelDesigners()
        {
            var modelDesigners = _context.ModelDesigners.ToList();
            return Ok(modelDesigners);
        }

        [HttpPut]
        public IActionResult UpdateModelDesigner(ModelDesigner updatedModelDesigner)
        {
            var modelDesignerToUpdate = _context.ModelDesigners.FirstOrDefault(d => d.Id == updatedModelDesigner.Id);
            if (modelDesignerToUpdate != null)
            {
                modelDesignerToUpdate.Name = updatedModelDesigner.Name;
                modelDesignerToUpdate.Description = updatedModelDesigner.Description;
                modelDesignerToUpdate.IsActive = updatedModelDesigner.IsActive;
                modelDesignerToUpdate.DateModified = DateTime.Now;
                modelDesignerToUpdate.LastModifiedBy = updatedModelDesigner.LastModifiedBy;

                _context.SaveChanges();
                Console.WriteLine("Model Designer updated successfully.");
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModelDesigner(int id)
        {
            var modelDesigner = _context.ModelDesigners.FirstOrDefault(d => d.Id == id);
            if (modelDesigner != null)
            {
                _context.ModelDesigners.Remove(modelDesigner);
                _context.SaveChanges();
                Console.WriteLine("Model Designer deleted successfully.");
                return Ok();
            }
            return NotFound();
        }
    }
}
