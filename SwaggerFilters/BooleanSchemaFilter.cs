using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class BooleanSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null)
        {
            return;
        }

        var booleanProperties = context.Type.GetProperties().Where(
            prop => prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?));

        foreach (var booleanProperty in booleanProperties)
        {
            var propertyName = booleanProperty.Name;
            var property = schema.Properties.FirstOrDefault(p => p.Key.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).Value;

            if (property != null)
            {
                property.Type = "boolean";
                property.Format = null;
                property.Enum = new List<IOpenApiAny>
                {
                    new OpenApiBoolean(false), // Add the 'false' option to the enum
                    new OpenApiBoolean(true)   // Add the 'true' option to the enum
                };
                property.Description = "true or false";
            }
        }
    }
}
