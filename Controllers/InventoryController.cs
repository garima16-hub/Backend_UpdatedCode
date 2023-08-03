using _3DModels.Models;
using _3DModels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _3DModels.Controllers
{
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }



        [HttpPost("{inventoryItemId}/Models")]
        public ActionResult<ModelDTO> AddModel(int inventoryItemId, [FromBody] ModelDTO modelDto)
        {
            _inventoryService.AddModel(inventoryItemId, modelDto);
            return CreatedAtAction(nameof(AddModel), new { inventoryItemId }, modelDto);
        }

    }
}

