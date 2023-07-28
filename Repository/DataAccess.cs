using _3DModels.Models;
using Microsoft.Data.SqlClient;


namespace _3DModels.Repository
{
    
        public class DataAccess : IDataAccess
        {
            private readonly IConfiguration configuration;
            private readonly string dbconnection;
            private readonly string dateformat;

            public DataAccess(IConfiguration configuration)
            {
                this.configuration = configuration;
                dbconnection = this.configuration["ConnectionStrings:dbconn"];
                dateformat = this.configuration["Contants:DateFormat"];
            }

            public Product GetProduct(int id)
            {
                var product = new Product();
                using (SqlConnection connection = new(dbconnection))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection
                    };
                    string query = "SELECT * FROM Products WHERE Id = " + id + ";";
                    command.CommandText = query;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Id = (int)reader["Id"];
                        product.Title = (string)reader["Title"];
                        product.Description = (string)reader["Description"];
                        product.Price = (decimal)reader["Price"];
                        product.Quantity = (int)reader["Quantity"];
                        product.ImageName = (string)reader["ImageName"];
                        var categoryid = (int)reader["ProductCategoryid"];
                        product.ProductCategory = GetProductCategory(categoryid);
                    }

                }
                return product;
            }

            public List<ProductCategory> GetProductCategories()
            {
                var ProductCategory = new List<ProductCategory>();
                using (SqlConnection connection = new(dbconnection))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection
                    };
                    string query = "SELECT * FROM ProductCategory;";
                    command.CommandText = query;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var category = new ProductCategory()
                        {
                            id = (int)reader["id"],
                            Category = (string)reader["Category"],
                            SubCategory = (string)reader["SubCategory"],
                        };
                        ProductCategory.Add(category);

                    }
                }
                return ProductCategory;
            }

            public ProductCategory GetProductCategory(int id)
            {
                var productcategory = new ProductCategory();
                using (SqlConnection connection = new(dbconnection))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection
                    };
                    string query = "SELECT * FROM ProductCategory WHERE id = " + id + ";";
                    command.CommandText = query;
                    connection.Open();
                    SqlDataReader r = command.ExecuteReader();
                    while (r.Read())
                    {
                        productcategory.id = (int)r["id"];
                        productcategory.Category = (string)r["Category"];
                        productcategory.SubCategory = (string)r["SubCategory"];

                    }

                }
                return productcategory;
            }

            public List<Product> GetProducts(string category, string subcategory, int count)
            {
                var products = new List<Product>();
                using (SqlConnection connection = new(dbconnection))
                {
                    SqlCommand command = new()
                    {
                        Connection = connection
                    };
                    string query = "SELECT TOP " + count + " * FROM Products WHERE ProductCategoryid=(SELECT id FROM ProductCategory WHERE Category=@c AND SubCategory=@s) ORDER BY newid();";
                    command.CommandText = query;
                    command.Parameters.Add("@c", System.Data.SqlDbType.NVarChar).Value = category;
                    command.Parameters.Add("@s", System.Data.SqlDbType.NVarChar).Value = subcategory;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Quantity = (int)reader["Quantity"],
                            ImageName = (string)reader["ImageName"],
                        };
                        var categoryid = (int)reader["ProductCategoryid"];
                        product.ProductCategory = GetProductCategory(categoryid);
                        products.Add(product);
                    }
                }
                return products;
            }


        }
    }



