using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class ReturnReason
{
    public int ReturnReasonId { get; set; }

    public string ReasonDescription { get; set; } = null!;

    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    public static ReturnReasonResponse ReturnReasonToResponseDTO(ReturnReason returnReason)
    {
        return new ReturnReasonResponse
        {
            ReturnReasonId = returnReason.ReturnReasonId,
            ReasonDescription = returnReason.ReasonDescription
        };
    }
}
