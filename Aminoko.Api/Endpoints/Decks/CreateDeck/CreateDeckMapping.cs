using Aminoko.Api.Infrastructure.Mapping;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Endpoints.Decks.CreateDeck;

public static class CreateDeckMapping
{
    public static Deck ToDeck(this CreateDeckRequest request)
    {
        return new Deck
        {
            Name = request.Name,
            UserId = request.UserId
        };
    }

    public static CreateDeckResponse ToCreateDeckResponse(this Deck deck)
    {
        return new CreateDeckResponse
        {
            Deck = deck.ToDeckDto()
        };
    }
}

