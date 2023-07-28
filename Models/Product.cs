using _3DModels.Repository;
using System.ComponentModel.DataAnnotations;



namespace _3DModels.Models

{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProductCategory ProductCategory { get; set; } = new ProductCategory();
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
