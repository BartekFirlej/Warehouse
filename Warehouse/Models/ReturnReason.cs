using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class ReturnReason
{
    public int ReturnReasonId { get; set; }

    public string ReasonDescription { get; set; } = null!;

    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();
}
