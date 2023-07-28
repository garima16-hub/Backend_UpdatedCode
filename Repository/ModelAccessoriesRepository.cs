using _3DModels.Models;

using Microsoft.Data.SqlClient;

using System.Security.Claims;

using System.Data.Common;

using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using System.Text;

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _3DModels.Repository

{

    public class ModelAccessoriesRepository : IModelAccessories

    {

        private readonly IConfiguration configuration;

        private readonly string dbconnection;

        private readonly string dateformat;

        public ModelAccessoriesRepository(IConfiguration configuration)

        {

            this.configuration = configuration;

            dbconnection = this.configuration["ConnectionStrings:Configuration"];

            dateformat = this.configuration["Contants:DateFormat"];

        }

        // <..............Get the ModelAccessories by their id............>          

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
        public List<ModelAccessories> GetModelAccessories()

        {

            var ProductCategory = new List<ModelAccessories>();

            using (SqlConnection connection = new(dbconnection))

            {

                SqlCommand command = new()

                {

                    Connection = connection

                };

                string query = "SELECT * FROM ModelAccesories;";

                command.CommandText = query;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                {

                    var category = new ModelAccessories()

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


    }
}
