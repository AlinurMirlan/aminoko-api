using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Infrastructure.Mapping;

public static class WordMappingExtensions
{
    public static WordDto ToWordDto(this Word word)
    {
        return new WordDto
        {
            Id = word.Id,
            Name = word.Name,
            CreationDate = word.CreationDate
        };
    }
}
