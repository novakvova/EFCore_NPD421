using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample.Data.Entities;

[Table("tblCategories")]
public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
