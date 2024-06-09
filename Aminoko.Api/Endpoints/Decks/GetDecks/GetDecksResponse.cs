using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Decks.GetDecks;

public class GetDecksResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<DeckDto> Decks { get; set; } = [];
}