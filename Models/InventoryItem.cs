using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    // Models/InventoryItem.cs
    public class InventoryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        // Add a collection of models associated with this inventory item
        public ICollection<Model> Models { get; set; } = new List<Model>();

        // Add other properties as needed
    }
}
