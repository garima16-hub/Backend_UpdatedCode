using System;
using System.Collections.Generic;
using System.Linq;
using _3DModels.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModels.Repositories
{

    public class ModelCoordinatorRepository
    {
        private readonly ModelDbContext _dbContext;

        public ModelCoordinatorRepository(ModelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ModelCoordinator> GetAllModelCoordinators()
        {
            return _dbContext.ModelCoordinators.ToList();
        }

        public ModelCoordinator GetModelCoordinatorById(int id)
        {
            return _dbContext.ModelCoordinators.FirstOrDefault(mc => mc.Id == id);
        }

        public void AddModelCoordinator(ModelCoordinator modelCoordinator)
        {
            _dbContext.ModelCoordinators.Add(modelCoordinator);
            _dbContext.SaveChanges();
        }

        public void UpdateModelCoordinator(ModelCoordinator modelCoordinator)
        {
            _dbContext.Entry(modelCoordinator).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteModelCoordinator(int id)
        {
            var modelCoordinator = _dbContext.ModelCoordinators.FirstOrDefault(mc => mc.Id == id);
            if (modelCoordinator != null)
            {
                _dbContext.ModelCoordinators.Remove(modelCoordinator);
                _dbContext.SaveChanges();
            }
        }
    }
}