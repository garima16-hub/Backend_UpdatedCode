using _3DModels.Models;
using _3DModels.Services;

namespace _3DModels.Services
{
    public interface IInventoryService
    {
        

        void AddModel(int inventoryItemId, ModelDTO modelDto);
  


    }
}
