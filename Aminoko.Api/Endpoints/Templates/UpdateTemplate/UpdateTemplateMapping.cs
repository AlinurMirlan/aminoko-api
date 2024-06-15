using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

public static class UpdateTemplateMapping
{
    public static Template ToTemplate(this UpdateTemplateRequest request)
    {
        return new Template
        {
            Id = request.TemplateId,
            Name = request.Name,
            Body = request.Body
        };
    }
}
