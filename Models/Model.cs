using Microsoft.CodeAnalysis.Completion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price{get; set;}
    }
}
