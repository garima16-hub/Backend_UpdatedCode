using _3DModels.Models;

public interface IInventoryRepository
{
    void AddModel(int inventoryItemId, ModelDTO modelDto);
}
