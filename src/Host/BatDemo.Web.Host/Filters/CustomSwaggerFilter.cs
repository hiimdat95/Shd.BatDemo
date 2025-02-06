using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace BatDemo.Web.Host.Filters
{
    public class CustomSwaggerFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //remove paths those start with /api/abp prefix
            swaggerDoc.Paths
                .Where(x => 
                !x.Key.ToLowerInvariant().StartsWith("/api/services/app/file")
                &&
                !x.Key.ToLowerInvariant().StartsWith("/api/services/app/import"))
                .ToList()
                .ForEach(x => swaggerDoc.Paths.Remove(x.Key));
        }
    }
}






