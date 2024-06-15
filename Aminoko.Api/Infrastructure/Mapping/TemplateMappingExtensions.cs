using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Infrastructure.Mapping;

public static class TemplateMappingExtensions
{
    public static TemplateDto ToTemplateDto(this Template template)
    {
        return new TemplateDto
        {
            Id = template.Id,
            Name = template.Name,
            Body = template.Body,
            CreationDate = template.CreationDate
        };
    }
}
