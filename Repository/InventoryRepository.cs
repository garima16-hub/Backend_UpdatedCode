using _3DModels.Models;
using _3DModels.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;



namespace _3DModels.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ModelDbContext _dbContext; // Replace with your actual DbContext type


        public InventoryRepository(ModelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddModel(int inventoryItemId, ModelDTO modelDto)
        {
            try
            {
                var inventoryItem = _dbContext.InventoryItems.Find(inventoryItemId);

                if (inventoryItem == null)
                {
                    throw new ArgumentException($"Invalid InventoryItemId: {inventoryItemId}");
                }

                var modelEntity = new Model
                {
                    Title = modelDto.Title,
                    Description = modelDto.Description, // Make sure this value is not null
                    ModelAccesoriess = modelDto.ModelAccesoriess,
                    Price = modelDto.Price,
                    Quantity = modelDto.Quantity,
                    ImageName = modelDto.ImageName
                };

                inventoryItem.Models.Add(modelEntity);
                _dbContext.SaveChanges();
            }

            catch (SqlException ex) when (ex.Number == 547) // Foreign key violation
            {
                // Handle the specific foreign key violation scenario
                throw new ArgumentException($"Invalid InventoryItemId: {inventoryItemId}", ex);
            }
        }

       
    }
}
