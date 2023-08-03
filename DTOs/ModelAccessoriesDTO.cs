using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models

{

    public class ModelAccessoriesDTO

    {



        public int id { get; set; }

        public string Category { get; set; } = "";

        public string SubCategory { get; set; } = "";

        [ForeignKey(nameof(Category))]
        public int Id { get; set; }
    }

}