using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _3DModels.Models;

namespace _3DModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public ModelController(ModelDbContext context)
        {
            _context = context;
        }

        // GET: api/Model
        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetModels()
        {
            return _context.model.ToList();
        }

        // GET: api/Model/5
        [HttpGet("{id}")]
        public ActionResult<Model> GetModel(int id)
        {
            var model = _context.model.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // POST: api/Model
        [HttpPost]
        public ActionResult<Model> PostModel(Model model)
        {
            _context.model.Add(model);
            _context.SaveChanges();

            return CreatedAtAction("GetModel", new { id = model.ModelId }, model);
        }

        // PUT: api/Model/5
        [HttpPut("{id}")]
        public IActionResult PutModel(int id, Model model)
        {
            if (id != model.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Model/5
        [HttpDelete("{id}")]
        public ActionResult<Model> DeleteModel(int id)
        {
            var model = _context.model.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.model.Remove(model);
            _context.SaveChanges();

            return model;
        }
    }
}
