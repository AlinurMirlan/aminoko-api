﻿using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence.Repos;

public class DeckRepo : IDeckRepo
{
    private readonly ApplicationContext _context;

    public DeckRepo(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Deck> GetAsync(int deckId) => 
        await _context.Decks.FindAsync(deckId) ?? throw new NotFoundException(nameof(Deck));

    public async Task<PagedResult<Deck>> GetAsync(string userId, PageRequest pageRequest)
    {
        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingDecks = _context.Decks.Where(d => d.UserId == userId);
        var pageCount = (int)Math.Ceiling((double)await matchingDecks.CountAsync() / pageSize);
        matchingDecks = matchingDecks.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Deck>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingDecks.ToListAsync()
        };
    }

    public Task<Deck> AddAsync(Deck deck)
    {
        if (_context.Decks.Any(d => d.Name == deck.Name && d.UserId == deck.UserId))
            throw new InvalidOperationException("Deck with the same name already exists in the database.");

        return AddAsyncInternal(deck);
    }

    private async Task<Deck> AddAsyncInternal(Deck deck)
    {
        deck = (await _context.Decks.AddAsync(deck)).Entity;

        await _context.SaveChangesAsync();

        return deck;
    }

    public async Task DeleteAsync(int deckId)
    {
        Deck? deck = await _context.Decks.FindAsync(deckId);
        if (deck is null)
        {
            return;
        }

        _context.Remove(deck);

        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<Deck>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAsync(userId, pageRequest);
        }

        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingDecks = _context.Decks.Where(d => d.UserId == userId && d.Name.Contains(searchTerm));
        var pageCount = (int)Math.Ceiling((double)await matchingDecks.CountAsync() / pageSize);
        matchingDecks = matchingDecks.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Deck>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingDecks.ToListAsync()
        };
    }

    public async Task UpdateDeckAsync(int deckId, Deck updatedDeck)
    {
        var deck = await _context.Decks.FindAsync(deckId) ?? throw new NotFoundException(nameof(Deck));

        deck.Name = updatedDeck.Name;

        await _context.SaveChangesAsync();
    }
}
