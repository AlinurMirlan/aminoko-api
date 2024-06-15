using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Deck")]
[Index("Name", Name = "IX_Deck_Name", IsUnique = false)]
[Index("UserId", "Name", Name = "IX_Deck_UserId_Name", IsUnique = true)]
public class Deck
{
    [Key]
    public int Id { get; set; }

    public string UserId { get; set; } = default!;

    public required string Name { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; }

    [InverseProperty("Deck")]
    public virtual ICollection<Flashcard> Flashcards { get; } = [];

    [InverseProperty("Decks")]
    public virtual User User { get; set; } = default!;
}
