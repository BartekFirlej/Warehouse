using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string ProductTypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public static ProductTypeResponse ProductToResponseDTO(ProductType productType)
    {
        return new ProductTypeResponse
        {
            ProductTypeId = productType.ProductTypeId,
            ProductTypeName = productType.ProductTypeName
        };
    }
}
