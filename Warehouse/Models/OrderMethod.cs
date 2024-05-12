using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class OrderMethod
{
    public int OrderMethodId { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public static OrderMethodResponse ReturnOrderMethodToResponseDTO(OrderMethod orderMethod)
    {
        return new OrderMethodResponse
        {
            OrderMethodId = orderMethod.OrderMethodId,
            MethodName = orderMethod.MethodName
        };
    }

    public static OrderMethod RequestDTOToOrderMethod(OrderMethodRequest orderMethodDetails)
    {
        return new OrderMethod
        {
            MethodName = orderMethodDetails.MethodName
        };
    }
}
