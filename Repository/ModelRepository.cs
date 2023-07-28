using _3DModels.Models;

using Microsoft.Data.SqlClient;

using System.Security.Claims;

using System.Data.Common;

using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using System.Text;

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata;
using _3DModels.Repositories;
using _3DModels.Repository;

namespace _3DModels.Repository

{

    public class ModelRepository : IModel

    {

        private readonly IConfiguration configuration;

        private readonly string dbconnection;

        private readonly string dateformat;

        public ModelRepository(IConfiguration configuration)

        {

            this.configuration = configuration;

            dbconnection = this.configuration["ConnectionStrings:Configuration"];

            dateformat = this.configuration["Contants:DateFormat"];

        }

        //Get the Models by their id
        public Model GetModel(int id)

        {

            var product = new Model();

            using (SqlConnection connection = new(dbconnection))

            {

                SqlCommand command = new()

                {

                    Connection = connection

                };

                string query = "SELECT * FROM Models WHERE Id = " + id + ";";

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

                    var categoryid = (int)reader["ModelAccesoriessid"];

                    product.ModelAccesoriess = GetModelAccessory(categoryid);

                }





            }

            return product;

        }


        //Get the GetModelAccessory by their id
        public ModelAccessories GetModelAccessory(int id)

        {

            var productcategory = new ModelAccessories();

            using (SqlConnection connection = new(dbconnection))

            {

                SqlCommand command = new()

                {

                    Connection = connection

                };

                string query = "SELECT * FROM ModelAccesories WHERE id = " + id + ";";

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



        // Get the Model by their category,subcategory and count 
        public List<Model> GetModels(string category, string subcategory, int count)

        {

            var products = new List<Model>();

            using (SqlConnection connection = new(dbconnection))

            {

                SqlCommand command = new()

                {

                    Connection = connection

                };

                string query = "SELECT TOP " + count + " * FROM Models WHERE ModelAccesoriessid=(SELECT id FROM ModelAccesories WHERE Category=@c AND SubCategory=@s) ORDER BY newid();";

                command.CommandText = query;

                command.Parameters.Add("@c", System.Data.SqlDbType.NVarChar).Value = category;

                command.Parameters.Add("@s", System.Data.SqlDbType.NVarChar).Value = subcategory;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {

                    var product = new Model()

                    {

                        Id = (int)reader["Id"],

                        Title = (string)reader["Title"],

                        Description = (string)reader["Description"],

                        Price = (decimal)reader["Price"],

                        Quantity = (int)reader["Quantity"],

                        ImageName = (string)reader["ImageName"],

                    };

                    var categoryid = (int)reader["ModelAccesoriessid"];

                    product.ModelAccesoriess = GetModelAccessory(categoryid);

                    products.Add(product);

                }

            }

            return products;

        }
    }
}

