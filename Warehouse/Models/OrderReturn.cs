using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class OrderReturn
{
    public int ReturnId { get; set; }

    public int OrderDetailId { get; set; }

    public DateTime ReturnDate { get; set; }

    public int Quantity { get; set; }

    public int ReturnReasonId { get; set; }

    public virtual OrderDetail OrderDetail { get; set; } = null!;

    public virtual ReturnReason ReturnReason { get; set; } = null!;

    public static OrderReturnResponse OrderReturnToResponseDTO(OrderReturn orderReturn)
    {
        return new OrderReturnResponse
        {
            ReturnId = orderReturn.ReturnId,
            ReturnReasonId = orderReturn.ReturnReasonId,
            OrderDetailId = orderReturn.OrderDetailId,
            Quantity = orderReturn.Quantity,
            ReturnDate = orderReturn.ReturnDate
        };
    }

    public static OrderReturn RequestDTOToOrderReturn(OrderReturnRequest orderReturnDetails)
    {
        return new OrderReturn
        {
            ReturnReasonId = orderReturnDetails.ReturnReasonId,
            OrderDetailId = orderReturnDetails.OrderDetailId,
            Quantity = orderReturnDetails.Quantity,
            ReturnDate = orderReturnDetails.ReturnDate
        };
    }
}
