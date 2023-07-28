using System.ComponentModel.DataAnnotations;

using _3DModels.Models;

using _3DModels.Repository;



namespace _3DModels.Models
{

    public class Model

    {

        [Key]

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ModelAccessories ModelAccesoriess { get; set; } = new ModelAccessories();

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; } = string.Empty;



    }

}