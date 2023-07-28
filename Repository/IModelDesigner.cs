using _3DModels.Models;

namespace _3DModels.Repository
{
    public interface IModelDesigner
    {
        List<ModelDesigner> GetAllModelDesigners();
        ModelDesigner GetModelDesignerById(int id);
        void AddModelDesigner(ModelDesigner modelDesigner);
        void UpdateModelDesigner(ModelDesigner updatedModelDesigner);
        void DeleteModelDesigner(int id);
    }
}

