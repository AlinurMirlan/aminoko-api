using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence.Repos;

public class WordRepo : IWordRepo
{
    private readonly ApplicationContext _context;

    public WordRepo(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Word> GetAsync(int wordId) =>
        await _context.Words.FindAsync(wordId) ?? throw new NotFoundException(nameof(Word));

    public async Task<PagedResult<Word>> GetAsync(string userId, PageRequest pageRequest)
    {
        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingWords = _context.Words.Where(d => d.UserId == userId);
        var pageCount = (int)Math.Ceiling((double)await matchingWords.CountAsync() / pageSize);
        matchingWords = matchingWords.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Word>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingWords.ToListAsync()
        };
    }

    public Task<Word> AddAsync(Word word)
    {
        if (_context.Users.Find(word.UserId) is null)
        {
            throw new NotFoundException(nameof(User));
        }

        if (_context.Decks.Any(d => d.Name == word.Name && d.UserId == word.UserId))
        {
            throw new ConflictException("Word with the same name already exists.");
        }

        return AddAsyncInternal(word);
    }

    private async Task<Word> AddAsyncInternal(Word word)
    {
        word = (await _context.Words.AddAsync(word)).Entity;

        await _context.SaveChangesAsync();

        return word;
    }

    public async Task DeleteAsync(int wordId)
    {
        Word? deck = await _context.Words.FindAsync(wordId);
        if (deck is null)
        {
            return;
        }

        _context.Remove(deck);

        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<Word>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAsync(userId, pageRequest);
        }

        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingWords = _context.Words.Where(d => d.UserId == userId && d.Name.Contains(searchTerm));
        var pageCount = (int)Math.Ceiling((double)await matchingWords.CountAsync() / pageSize);
        matchingWords = matchingWords.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Word>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingWords.ToListAsync()
        };
    }
}
