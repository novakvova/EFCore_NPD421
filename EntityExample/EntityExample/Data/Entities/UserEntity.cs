using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample.Data.Entities;

[Table("tblUsers")]
public class UserEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    public string FistName { get; set; } = String.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = String.Empty;
    [StringLength(100)]
    public string Email { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
