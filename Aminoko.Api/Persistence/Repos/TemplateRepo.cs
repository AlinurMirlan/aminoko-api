﻿using Aminoko.Api.Infrastructure.Exceptions;
using Aminoko.Api.Models;
using Aminoko.Api.Persistence.Models;
using Aminoko.TemplateGen;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence.Repos;

public class TemplateRepo : ITemplateRepo
{
    private readonly ApplicationContext _context;

    public TemplateRepo(ApplicationContext dbContext)
    {
        _context = dbContext?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Template> GetAsync(int templateId) =>
        await _context.Templates.FindAsync(templateId) ?? throw new NotFoundException(nameof(Template));

    public async Task<PagedResult<Template>> GetAsync(string userId, PageRequest pageRequest)
    {
        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingDecks = _context.Templates.Where(d => d.UserId == userId);
        var pageCount = (int)Math.Ceiling((double)await matchingDecks.CountAsync() / pageSize);
        matchingDecks = matchingDecks.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Template>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingDecks.ToListAsync()
        };
    }

    public async Task<PagedResult<Template>> SearchAsync(string userId, PageRequest pageRequest, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAsync(userId, pageRequest);
        }

        var pageSize = pageRequest.PageSize;
        var page = pageRequest.Page;
        var matchingTemplates = _context.Templates.Where(d => d.UserId == userId && EF.Functions.ILike(d.Name, $"%{searchTerm}%"));
        var pageCount = (int)Math.Ceiling((double)await matchingTemplates.CountAsync() / pageSize);
        matchingTemplates = matchingTemplates.Skip(pageSize * (page - 1)).Take(pageSize);

        return new PagedResult<Template>
        {
            Page = page,
            PageSize = pageSize,
            TotalPages = pageCount,
            Items = await matchingTemplates.ToListAsync()
        };
    }

    public async Task DeleteAsync(int templateId)
    {
        var template = await _context.Templates.FindAsync(templateId);
        if (template is null)
        {
            return;
        }

        _context.Templates.Remove(template);
        await _context.SaveChangesAsync();
    }

    public Task<Template> AddAsync(Template template)
    {
        if (_context.Users.Find(template.UserId) is null)
        {
            throw new NotFoundException(nameof(User));
        }

        if (_context.Templates.Any(t => t.Name == template.Name && t.UserId == template.UserId))
        {
            throw new ConflictException("Template with the same name already exists.");
        }

        return AddAsyncInternal(template);
    }

    private async Task<Template> AddAsyncInternal(Template template)
    {
        template = (await _context.Templates.AddAsync(template)).Entity;

        await _context.SaveChangesAsync();

        return template;
    }

    public async Task UpdateAsync(int templateId, Template updatedTemplate)
    {
        var template = await _context.Templates.FindAsync(templateId) ?? throw new NotFoundException(nameof(Template));

        if (!string.IsNullOrEmpty(updatedTemplate.Name))
        {
            template.Name = updatedTemplate.Name;
        }

        if (!string.IsNullOrEmpty(updatedTemplate.Body))
        {
            template.Body = updatedTemplate.Body;
        }

        if (updatedTemplate.CreationDate != default)
        {
            template.CreationDate = updatedTemplate.CreationDate;
        }

        await _context.SaveChangesAsync();
    }
}
