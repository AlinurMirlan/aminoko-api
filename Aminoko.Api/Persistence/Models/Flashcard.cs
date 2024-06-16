using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Flashcard")]
public class Flashcard
{
    [Key]
    public int Id { get; set; }

    public int DeckId { get; set; }

    public int WordId { get; set; }

    public int RetentionStatsId { get; set; }

    public required string Front { get; set; }

    public required string Back { get; set; }

    public string UserId { get; set; } = default!;

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    [Column(TypeName = "date")]
    public DateTime? RepetitionDate { get; set; }

    [ForeignKey("RetentionStatsId")]
    public virtual RetentionStats RetentionStats { get; set; } = default!;

    [ForeignKey("DeckId")]
    [InverseProperty("Flashcards")]
    public virtual Deck Deck { get; set; } = default!;

    [ForeignKey("WordId")]
    [InverseProperty("Flashcard")]
    public virtual Word Word { get; set; } = default!;

    [ForeignKey("UserId")]
    [InverseProperty("Flashcards")]
    public virtual User User { get; set; } = default!;
}
