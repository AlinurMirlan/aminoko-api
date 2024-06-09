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
            UserId = template.UserId,
            Body = template.Body
        };
    }

    public static Template ToTemplate(this TemplateDto templateDto)
    {
        return new Template
        {
            Id = templateDto.Id,
            Name = templateDto.Name,
            UserId = templateDto.UserId,
            Body = templateDto.Body
        };
    }
}
