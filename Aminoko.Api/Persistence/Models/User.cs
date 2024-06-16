using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

public class User : IdentityUser
{
    [InverseProperty("User")]
    public virtual ICollection<Deck> Decks { get; set; } = [];

    [InverseProperty("User")]
    public virtual ICollection<Template> Templates { get; set; } = [];

    [InverseProperty("User")]
    public virtual ICollection<Word> Words { get; set; } = [];

    [InverseProperty("User")]
    public virtual ICollection<Flashcard> Flashcards { get; set; } = [];
}
