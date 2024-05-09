using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class OrderMethod
{
    public int OrderMethodId { get; set; }

    public string MethodName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
