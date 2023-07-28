using System;
using System.Collections.Generic;

namespace _3DModels.Models
{

    public class ModelDesigner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}