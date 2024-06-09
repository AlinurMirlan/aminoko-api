﻿using Aminoko.Api.Persistence.Models;

namespace Aminoko.Api.Persistence.Repos;

public interface IFlashcardRepo
{
    public Task<Flashcard> GenerateAsync(Template template);

    public Task<Flashcard> GetAsync(int flashcardId);

    public Task UpdateAsync(int flashcardId, Flashcard updatedFlashcard);

    public Task UpdateRepetitionDateAsync(int flashcardId, DateTime repetitionDate);

    public Task DeleteAsync(int flashcardId);

    public Task<IEnumerable<int>> GetDueIdsAsync();
}
