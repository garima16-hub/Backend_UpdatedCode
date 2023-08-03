using _3DModels.Models;
using _3DModels.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using _3DModels.Services;

namespace _3DModels.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ModelDbContext _dbContext;
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<InventoryService> _logger; 

        public InventoryService(ModelDbContext dbContext, IInventoryRepository repository, IMapper mapper, ILogger<InventoryService> logger)
        {
            _dbContext = dbContext;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

      

        public void AddModel(int InventoryItemId, ModelDTO modelDto)
        {
            try
            {
                // Map the DTO to the Model entity and add it to the repository.
                var model = _mapper.Map<ModelDTO>(modelDto);
                _repository.AddModel(InventoryItemId, model);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw;
            }

           
        }
    }
}
