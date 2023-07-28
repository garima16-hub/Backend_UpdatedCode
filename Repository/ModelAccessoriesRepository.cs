using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Repositories
{
    public class ModelAccessoriesRepository
    {
        private readonly ModelDbContext _context;

        public ModelAccessoriesRepository(ModelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ModelAccessories> GetAllModelAccessories()
        {
            return _context.ModelAccessories.ToList();
        }

        public ModelAccessories GetModelAccessoriesById(int id)
        {
            return _context.ModelAccessories.Find(id);
        }

        public void AddModelAccessories(ModelAccessories modelAccessories)
        {
            _context.ModelAccessories.Add(modelAccessories);
            _context.SaveChanges();
        }

        public void UpdateModelAccessories(ModelAccessories modelAccessories)
        {
            _context.Entry(modelAccessories).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteModelAccessories(int id)
        {
            var modelAccessories = _context.ModelAccessories.Find(id);
            if (modelAccessories != null)
            {
                _context.ModelAccessories.Remove(modelAccessories);
                _context.SaveChanges();
            }
        }
    }
}
