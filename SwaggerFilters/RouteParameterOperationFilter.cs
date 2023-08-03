using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

public class RouteParameterOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var routeParameters = context.ApiDescription.ParameterDescriptions
            .Where(p => p.Source == BindingSource.Path).ToList();

        foreach (var routeParameter in routeParameters)
        {
            var parameter = operation.Parameters.FirstOrDefault(p => p.Name == routeParameter.Name);
            if (parameter != null)
            {
                parameter.Description = $"ID of the {routeParameter.Name.Replace("Id", "")}.";
                parameter.Required = true;
            }
        }
    }
}

