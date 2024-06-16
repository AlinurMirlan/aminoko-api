using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Word")]
public class Word
{
    [Key]
    public int Id { get; set; }

    public required string UserId { get; set; }

    public int? FlashcardId { get; set; }

    public required string Name { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    [InverseProperty("Word")]
    public virtual Flashcard? Flashcard { get; set; }

    [InverseProperty("Words")]
    public virtual User User { get; set; } = default!;

}
