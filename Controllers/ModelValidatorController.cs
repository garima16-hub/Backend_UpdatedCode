using _3DModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3DModels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelValidatorController : ControllerBase
    {
        private readonly ModelDbContext _context;

        public ModelValidatorController(ModelDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("ValidateModel")]
        public IActionResult ValidateModel([FromBody] ThreeDModel model)
        {
            if (model == null)
            {
                
                return BadRequest("Invalid data. Model object must be provided.");
            }

            // Perform the model validation using the ValidateModel() method from the ThreeDModel class
            bool isValid = model.ValidateModel();

            if (isValid)
            {
                // Save the model to the database
                _context.ThreeDModels.Add(model);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetModelById), new { id = model.ID }, model);
            }
            else
            {
                _context.ThreeDModels.Add(model);
                _context.SaveChanges();
                return BadRequest("The 3D model is invalid due to the number of vertices exceeding the limit.");
            }
        }

        // GET: api/ModelValidator/5
        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            var model = _context.ThreeDModels.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
