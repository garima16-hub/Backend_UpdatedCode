using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Repository
{
    
        public interface IModelValidator
        {
            bool ValidateModel(ThreeDModel model);
        }

    }

