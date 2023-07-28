using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Repositories
{
    public class ModelRepository
    {
        private readonly ModelDbContext _context;

        public ModelRepository(ModelDbContext context)
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

        public void UpdateModel(Model model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteModel(Model model)
        {
            _context.model.Remove(model);
            _context.SaveChanges();
        }
    }
}
