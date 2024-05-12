using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int OrderMethodId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderMethod OrderMethod { get; set; } = null!;

    public static OrderResponse OrderToResponseDTO(Order order)
    {
        return new OrderResponse
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            OrderMethodId = order.OrderMethodId
        };
    }

    public static Order RequestDTOToOrder(OrderRequest orderDetails)
    {
        return new Order
        {
            CustomerId = orderDetails.CustomerId,
            OrderDate = orderDetails.OrderDate,
            TotalAmount = orderDetails.TotalAmount,
            OrderMethodId = orderDetails.OrderMethodId
        };
    }
}
