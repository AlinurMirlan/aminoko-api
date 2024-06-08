using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Word")]
public class Word
{
    [Key]
    public int Id { get; set; }

    public int? FlashcardId { get; set; }

    public required string Name { get; set; }

    [InverseProperty("Word")]
    public virtual Flashcard? Flashcard { get; set; }
}
