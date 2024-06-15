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
            CreationDate = deck.CreationDate
        };
    }
}
