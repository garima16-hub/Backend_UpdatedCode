using _3DModels.Repository;
using System.ComponentModel.DataAnnotations;



namespace _3DModels.Models

{


    public class ModelDTO
    {
        [Key]

        public int Id { get; set; }

        public string Title { get; set; } 

        public string Description { get; set; } 

        public ModelAccessories ModelAccesoriess { get; set; } = new ModelAccessories();

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; } 
    }
}
