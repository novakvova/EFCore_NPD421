using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityExample.Data.Entities;

[Table("tblOrderStatus")]
public class OrderStatusEntity
{
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
}
