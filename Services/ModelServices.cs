/*using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Services
{
    public class ModelService
    {
        private readonly ModelDbContext _context;

        public ModelService(ModelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Model> GetAllModels()
        {
            return _context.model.ToList();
        }

        public Model GetModelById(int id)
        {
            return _context.model.Find(id);
        }

        public void AddModel(Model model)
        {
            _context.model.Add(model);
            _context.SaveChanges();
        }

        public void UpdateModel(int id, Model model)
        {
            if (id != model.ModelId)
            {
                throw new ArgumentException("Invalid Model ID.");
            }

            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteModel(int id)
        {
            var model = _context.model.Find(id);
            if (model == null)
            {
                throw new NotFoundException("Model not found.");
            }

            _context.model.Remove(model);
            _context.SaveChanges();
        }
    }
}
*/