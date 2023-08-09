using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using _3DModels.Repository;
using _3DModels.Repositories;
using _3DModels.Models;

namespace _3DModels.Controllers

{

    [Route("api/[controller]")]

    [ApiController]



    public class ModelController : Controller

    {

        // .....declaring the fields......

        readonly IModel model;

        private readonly string DateFormat;

        private readonly IModel _model;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ModelDbContext _dbContext;

        public ModelController(IModel model, IConfiguration configuration, ModelDbContext dbContext)

        {

            this.model = model;

            DateFormat = configuration["Constants:DateFormat"];
            _dbContext = dbContext;

        }
        // <....loading products by category , subcategory.......>

        [HttpGet("GetAllModels")]

        public ActionResult<IEnumerable<Model>> GetAllModels()
        {
            return _dbContext.Models.ToList();
        }

        [HttpGet("GetModels")]

        public IActionResult GetProducts(string category, string subcategory, int count)

        {

            var result = model.GetModels(category, subcategory, count);

            return Ok(result);



        }

        // <..............Get the products by their id............>

        [HttpGet("GetModel/{id}")]

        public IActionResult GetProduct(int id)

        {

            var result = model.GetModel(id);

            return Ok(result);

        }




    }
}