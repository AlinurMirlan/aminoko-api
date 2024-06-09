using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Infrastructure.Mapping;

public static class DeckMappingExtensions
{
    public static DeckDto ToDeckDto(this Deck deck)
    {
        return new DeckDto
        {
            Id = deck.Id,
            Name = deck.Name,
            UserId = deck.UserId,
        };
    }

    public static Deck ToDeck(this DeckDto deckDto)
    {
        return new Deck
        {
            Id = deckDto.Id,
            Name = deckDto.Name,
            UserId = deckDto.UserId,
        };
    }
}
