using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Academia.Api.Extension
{
    public class DescricaoEnumExtension :ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;
            if (type.IsEnum)
            {
                schema.Type = "integer";
                schema.Enum.Clear();

                foreach (var value in Enum.GetValues(type))
                {
                    var intValue = (int)value;
                    var name = Enum.GetName(type, value);
                    schema.Enum.Add(new OpenApiInteger(intValue));
                }

                var descriptions = Enum.GetValues(type)
                                       .Cast<Enum>()
                                       .Select(e => $"{Convert.ToInt32(e)} = {e}")
                                       .ToArray();
                schema.Description = string.Join(", ", descriptions);
            }
        }
    }
}
