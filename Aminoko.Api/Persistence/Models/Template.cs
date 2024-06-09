using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aminoko.Api.Persistence.Models;

[Table("Template")]
public class Template
{
    [Key]
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string Name { get; set; }

    public required string Body { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; }

    [InverseProperty("Templates")]
    public virtual User User { get; set; } = default!;
}
