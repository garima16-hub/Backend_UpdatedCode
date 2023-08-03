// Models/InventoryMappings.cs
using AutoMapper;

using _3DModels.Models;
using _3DModels.Controllers;

public class InventoryMappings : Profile
{
    public InventoryMappings()
    {
        CreateMap<Model, ModelDTO>();
        CreateMap<ModelAccessories, ModelAccessoriesDTO>();
    }
}
