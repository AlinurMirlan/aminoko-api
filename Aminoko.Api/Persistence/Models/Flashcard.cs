using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Flashcard")]
public partial class Flashcard
{
    [Key]
    public int Id { get; set; }

    public int DeckId { get; set; }

    public int WordId { get; set; }

    public int RetentionStatsId { get; set; }

    public required string Front { get; set; }

    public required string Back { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime RepetitionDate { get; set; }

    [ForeignKey("RetentionStatsId")]
    public virtual RetentionStats RetentionStats { get; set; } = default!;

    [ForeignKey("DeckId")]
    [InverseProperty("Flashcards")]
    public virtual Deck Deck { get; set; } = default!;

    [ForeignKey("WordId")]
    [InverseProperty("Flashcard")]
    public virtual Word Word { get; set; } = default!;
}
