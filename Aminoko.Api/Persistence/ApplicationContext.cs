using Aminoko.Api.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aminoko.Api.Persistence;

public class ApplicationContext : IdentityDbContext<User>
{
    public DbSet<Deck> Decks { get; set; }
    
    public DbSet<Flashcard> Flashcards { get; set; }

    public DbSet<Template> Templates { get; set; }

    public DbSet<Word> Words { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}
