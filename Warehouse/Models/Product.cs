using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductType ProductType { get; set; } = null!;

    public static ProductResponse ProductToResponseDTO(Product product)
    {
        return new ProductResponse
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            ProductTypeId = product.ProductTypeId
        };
    }

    public static Product RequestDTOToProduct(ProductRequest productDetails)
    {
        return new Product
        {
            ProductName = productDetails.ProductName,
            Price = productDetails.Price,
            ProductTypeId = productDetails.ProductTypeId
        };
    }

    public static ProductWithProductTypeResponse ProductToProductWithProductTypeResponseDTO(Product product)
    {
        return new ProductWithProductTypeResponse
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            ProductTypeId = product.ProductTypeId,
            ProductTypeName = product.ProductType.ProductTypeName
        };
    }
}
