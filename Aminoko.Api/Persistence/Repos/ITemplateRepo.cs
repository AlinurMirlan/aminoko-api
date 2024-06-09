using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface ITemplateRepo
{
    public Task<Template> GetAsync(int templateId);

    public Task<PagedResult<Template>> GetAsync(string userId, PageRequest pageRequest);

    public Task<PagedResult<Template>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm);

    public Task DeleteAsync(int templateId);

    public Task<Template> AddAsync(Template template);

    public Task UpdateAsync(int templateId, Template updatedTemplate);
}
