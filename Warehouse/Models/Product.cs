using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? ProductTypeId { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductType? ProductType { get; set; }
}
