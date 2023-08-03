using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _3DModels.Models;

using _3DModels.Repository;



namespace _3DModels.Models
{

    public class Model

    {

        [Key]

        public int Id { get; set; }

        public string Title { get; set; } 

        public string Description { get; set; } 

        public ModelAccessories ModelAccesoriess { get; set; } = new ModelAccessories();

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageName { get; set; }

        // Add a foreign key to reference the InventoryItem

        [ForeignKey(nameof(InventoryItemId))]
        public int InventoryItemId { get; set; }

        
        public InventoryItem InventoryItem { get; set; }



    }

}