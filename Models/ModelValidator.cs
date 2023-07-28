using _3DModels.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public class ModelValidator : IModelValidator
    {
      
        internal readonly int NumberOfVertices;

        [Key]
        public int ID { get; set; }

        public string ModelName { get; set; }

       

        public bool ValidateModel(ThreeDModel model)
        {
            // Define the maximum number of vertices allowed
            const int MaxVerticesLimit = 100000;

            // Check if the number of vertices exceeds the limit
            if (model.NumberOfVertices > MaxVerticesLimit)
            {
                 // Set IsValid to false if the number of vertices exceeds the limit
                return false;    // Reject the model if the number of vertices exceeds the limit
            }

            // If the number of vertices is within the limit, accept the model
            // Set IsValid to true if the model is valid
            return true;
        }
    }
}
