using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Decks.CreateDeck;

[HttpPost("/deck")]
public sealed class CreateDeckEndpoint : Endpoint<CreateDeckRequest, CreateDeckResponse>
{
    private readonly IDeckRepo _deckRepo;

    public CreateDeckEndpoint(IDeckRepo deckRepo)
    {
        _deckRepo = deckRepo;
    }

    public override async Task HandleAsync(CreateDeckRequest r, CancellationToken ct)
    {
        Deck addedDeck;
        try
        {
            addedDeck = await _deckRepo.AddAsync(r.ToDeck());
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
            return;
        }

        await SendCreatedAtAsync<CreateDeckEndpoint>(
            new { deckId = addedDeck.Id },
            addedDeck.ToCreateDeckResponse(), 
            cancellation: ct);
    }
}