using eventbookingmgmt.api.Helpers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace eventbookingmgmt.api.Swagger
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = Constants.ClientCodeHeaderName,
                In = ParameterLocation.Header,
                Description = "A client code",
                Required = true,
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}
