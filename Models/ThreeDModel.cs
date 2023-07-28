using System.ComponentModel.DataAnnotations.Schema;

namespace _3DModels.Models
{
    public class ThreeDModel
    {
        public int ID { get; set; }
        public string ModelName { get; set; }
        public int NumberOfVertices { get; set; }

        // Property to store the validation result as a boolean (true or false)
        [Column(TypeName = "bit")]
        public bool IsValid { get; set; }

        // Parameterless constructor required by Entity Framework
        public ThreeDModel()
        {
        }

        // Constructor to initialize the model
        public ThreeDModel(int id, string modelName, int numberOfVertices)
        {
            ID = id;
            ModelName = modelName;
            NumberOfVertices = numberOfVertices;
        }

        // Method to validate the 3D model based on the number of vertices
        public bool ValidateModel()
        {
            // Define the maximum number of vertices allowed
            const int MaxVerticesLimit = 100000;

            // Check if the number of vertices exceeds the limit
            if (NumberOfVertices > MaxVerticesLimit)
            {
                IsValid = false; // Set IsValid to false if the number of vertices exceeds the limit
                return false;    // Reject the model if the number of vertices exceeds the limit
            }

            // If the number of vertices is within the limit, accept the model
            IsValid = true; // Set IsValid to true if the model is valid
            return true;
        }
    }
}
