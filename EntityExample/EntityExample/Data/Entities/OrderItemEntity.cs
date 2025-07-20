using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityExample.Data.Entities;

[Table("tblOrderItems")]
public class OrderItemEntity
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal PriceBuy { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
}
