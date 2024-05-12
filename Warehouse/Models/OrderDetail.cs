using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    public virtual Product Product { get; set; } = null!;

    public static OrderDetailResponse OrderDetailToResponseDTO(OrderDetail orderDetail)
    {
        return new OrderDetailResponse
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            Price = orderDetail.Price,
            ProductId = orderDetail.ProductId,
            Quantity = orderDetail.Quantity
        };
    }

    public static OrderDetail RequestDTOToOrderDetail(OrderDetailRequest orderDetailsDetails)
    {
        return new OrderDetail
        {
            OrderId = orderDetailsDetails.OrderId,
            Price = orderDetailsDetails.Price,
            ProductId = orderDetailsDetails.ProductId,
            Quantity = orderDetailsDetails.Quantity
        };
    }
}
