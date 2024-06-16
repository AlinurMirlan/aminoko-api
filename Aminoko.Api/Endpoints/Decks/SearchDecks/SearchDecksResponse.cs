using Aminoko.Api.Models;

namespace Aminoko.Api.Endpoints.Decks.SearchDecks;

public class SearchDecksResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public List<DeckDto> Decks { get; set; } = [];
}