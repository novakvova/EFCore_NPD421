using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample.Data.Entities;

[Table("tblOrders")]
public class OrderEntity
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(OrderStatus))]
    public int OrderStatusId { get; set; }
    public OrderStatusEntity OrderStatus { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!; // Навігаційна властивість для зв'язку з користувачем

    public virtual ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
}
