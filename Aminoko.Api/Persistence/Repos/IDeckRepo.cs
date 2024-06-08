using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface IDeckRepo
{
    public Task<Deck> GetAsync(int deckId);

    public Task<PagedResult<Deck>> GetAsync(string userId, PageRequest pageRequest);

    public Task<PagedResult<Deck>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm);

    public Task DeleteAsync(int deckId);

    public Task<Deck> AddAsync(Deck deck);

    public Task UpdateDeckAsync(int deckId, Deck updatedDeck);
}
