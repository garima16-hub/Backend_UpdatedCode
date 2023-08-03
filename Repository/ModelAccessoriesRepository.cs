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

            dbconnection = this.configuration["ConnectionStrings:dbconn"];

            dateformat = this.configuration["Contants:DateFormat"];

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

                string query = "SELECT * FROM ModelAccessories;";

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
