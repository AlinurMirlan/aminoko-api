using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface IWordRepo
{
    public Task<Word> GetAsync(int wordId);

    public Task<PagedResult<Word>> GetAsync(string userId, PageRequest pageRequest);

    public Task<PagedResult<Word>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm);

    public Task DeleteAsync(int wordId);
}
