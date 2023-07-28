using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using _3DModels.Repository;
using _3DModels.Repositories;





namespace _3DModels.Controllers

{

    [Route("api/[controller]")]

    [ApiController]



    public class ModelController : Controller

    {

        // .....declaring the fields......

        readonly IModel model;

        private readonly string DateFormat;

        public ModelController(IModel model, IConfiguration configuration)

        {

            this.model = model;

            DateFormat = configuration["Constants:DateFormat"];

        }
        // <....loading products by category , subcategory.......>

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
