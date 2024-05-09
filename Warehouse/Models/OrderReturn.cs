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
}
