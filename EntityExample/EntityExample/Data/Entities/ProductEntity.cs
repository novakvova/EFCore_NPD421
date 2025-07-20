

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample.Data.Entities;

[Table("tblProducts")]
public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(250)]
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!; // Навігаційна властивість для зв'язку з категорією
}
