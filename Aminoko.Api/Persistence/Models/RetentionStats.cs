using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("RetentionStats")]
public class RetentionStats
{
    [Key]
    public int Id { get; set; }

    public int FlashcardId { get; set; }

    public double? Difficulty { get; set; }

    public double? Stability { get; set; }

    [Column(TypeName = "date")]
    public DateTime ReviewDate { get; set; }

    [InverseProperty("RetentionStats")]
    public virtual Flashcard Flashcard { get; set; } = default!;
}
