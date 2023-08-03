using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using _3DModels.Repository;
using _3DModels.Repositories;

namespace _3DModels.Controllers

{

    [Route("api/[controller]")]

    [ApiController]



    public class ModelAccessories : Controller

    {

        // .....declaring the fields......

        readonly IModelAccessories modelAccessories;

        private readonly string DateFormat;

        public ModelAccessories(IModelAccessories modelAccessories, IConfiguration configuration)

        {

            this.modelAccessories = modelAccessories;

            DateFormat = configuration["Constants:DateFormat"];

        }

        [HttpGet("GetCategoryList")]

        public IActionResult GetCategoryList()

        {

            var result = modelAccessories.GetModelAccessories();

            return Ok(result);

        }



    }
}

