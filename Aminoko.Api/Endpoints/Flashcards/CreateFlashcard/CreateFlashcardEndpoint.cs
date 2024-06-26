﻿using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Persistence.Models;
using Aminoko.Api.Persistence.Repos;
using Aminoko.Api.Services;
using FastEndpoints;

namespace Aminoko.Api.Endpoints.Flashcards.CreateFlashcard;

[HttpPost("/flashcards")]
public class CreateFlashcardEndpoint : Endpoint<CreateFlashcardRequest, CreateFlashcardResponse>
{
    private readonly IFlashcardComposer _flashcardComposer;

    public CreateFlashcardEndpoint(IFlashcardComposer flashcardComposer)
    {
        _flashcardComposer = flashcardComposer ?? throw new ArgumentNullException(nameof(flashcardComposer));
    }

    public override async Task HandleAsync(CreateFlashcardRequest r, CancellationToken ct)
    {
        Flashcard addedFlashcard;
        try
        {
            addedFlashcard = await _flashcardComposer.ComposeAsync(r);
        }
        catch (BadRequestException e)
        {
            ThrowError(e.Message);
            return;
        }

        await SendCreatedAtAsync<CreateFlashcardEndpoint>(
            new { flashcardId = addedFlashcard.Id },
            addedFlashcard.ToCreateFlashcardResponse(),
            cancellation: ct);
    }
}
