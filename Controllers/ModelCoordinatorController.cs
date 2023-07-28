using _3DModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3DModels.Controllers
{


    // Assuming you have your DbContext class named YourDbContext (as mentioned in the previous code example).

    [Route("api/[controller]")]
    [ApiController]
    public class ModelCoordinatorController : ControllerBase
    {
        private readonly ModelDbContext _dbContext;

        public ModelCoordinatorController(ModelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/ModelCoordinator
        [HttpGet]
        public ActionResult<IEnumerable<ModelCoordinator>> GetModelCoordinators()
        {
            var modelCoordinators = _dbContext.ModelCoordinators.ToList();
            return Ok(modelCoordinators);
        }

        // GET: api/ModelCoordinator/5
        [HttpGet("{id}")]
        public ActionResult<ModelCoordinator> GetModelCoordinator(int id)
        {
            var modelCoordinator = _dbContext.ModelCoordinators.FirstOrDefault(mc => mc.Id == id);

            if (modelCoordinator == null)
            {
                return NotFound();
            }

            return Ok(modelCoordinator);
        }

        // POST: api/ModelCoordinator
        [HttpPost]
        public ActionResult<ModelCoordinator> CreateModelCoordinator(ModelCoordinator modelCoordinator)
        {
            _dbContext.ModelCoordinators.Add(modelCoordinator);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetModelCoordinator), new { id = modelCoordinator.Id }, modelCoordinator);
        }

        // PUT: api/ModelCoordinator/5
        [HttpPut("{id}")]
        public IActionResult UpdateModelCoordinator(int id, ModelCoordinator modelCoordinator)
        {
            if (id != modelCoordinator.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(modelCoordinator).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.ModelCoordinators.Any(mc => mc.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ModelCoordinator/5
        [HttpDelete("{id}")]
        public IActionResult DeleteModelCoordinator(int id)
        {
            var modelCoordinator = _dbContext.ModelCoordinators.FirstOrDefault(mc => mc.Id == id);
            if (modelCoordinator == null)
            {
                return NotFound();
            }

            _dbContext.ModelCoordinators.Remove(modelCoordinator);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}

