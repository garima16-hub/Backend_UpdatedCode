using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public class ModelAccessories
    {
       
        public int ModelId { get; set; }

        public string Filepath { get; set; }
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Accessories_id { get; set; }

        public string Accessories_name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
