using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Templates.UpdateTemplate;

public static class UpdateTemplateMapping
{
    public static Template ToTemplate(this UpdateTemplateRequest request)
    {
        return request.Template.ToTemplate();
    }
}
