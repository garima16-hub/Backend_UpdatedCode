using _3DModels.Models;
using System.Collections.Generic;
using _3DModels.Repository;

public interface IInventoryRepository
{
    void AddModel(int inventoryItemId, ModelDTO modelDto);
    
}
