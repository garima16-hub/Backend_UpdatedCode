using _3DModels.Models;


namespace _3DModels.Repository
{
    public interface IDataAccess
    {
        // loading category and subcategory list
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        List<Product> GetProducts(string category, string subcategory, int count);
        Product GetProduct(int id);
        
    }
}
