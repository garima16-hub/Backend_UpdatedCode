using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _3DModels.Models;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelAccessoriesController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public ModelAccessoriesController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/ModelAccessories
        [HttpGet]
        public ActionResult<IEnumerable<ModelAccessories>> GetModelAccessories()
        {
            return _context.ModelAccessories.ToList();
        }

        // GET: api/ModelAccessories/5
        [HttpGet("{id}")]
        public ActionResult<ModelAccessories> GetModelAccessories(int id)
        {
            var modelAccessories = _context.ModelAccessories.Find(id);

            if (modelAccessories == null)
            {
                return NotFound();
            }

            return modelAccessories;
        }

        // POST: api/ModelAccessories
        [HttpPost]
        public ActionResult<ModelAccessories> PostModelAccessories(ModelAccessories modelAccessories)
        {
            _context.ModelAccessories.Add(modelAccessories);
            _context.SaveChanges();

            return CreatedAtAction("GetModelAccessories", new { id = modelAccessories.ModelId }, modelAccessories);
        }

        // PUT: api/ModelAccessories/5
        [HttpPut("{id}")]
        public IActionResult PutModelAccessories(int id, ModelAccessories modelAccessories)
        {
            if (id != modelAccessories.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(modelAccessories).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ModelAccessories/5
        [HttpDelete("{id}")]
        public ActionResult<ModelAccessories> DeleteModelAccessories(int id)
        {
            var modelAccessories = _context.ModelAccessories.Find(id);
            if (modelAccessories == null)
            {
                return NotFound();
            }

            _context.ModelAccessories.Remove(modelAccessories);
            _context.SaveChanges();

            return modelAccessories;
        }
    }
}
