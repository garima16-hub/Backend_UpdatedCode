using _3DModels.Models;
using _3DModels.Services;

namespace _3DModels.Services
{
    public interface IInventoryService
    {
        // Existing methods...

        void AddModel(int inventoryItemId, ModelDTO modelDto);
        // Add other methods as needed
    }
}
