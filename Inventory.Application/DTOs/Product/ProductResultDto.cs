namespace Inventory.Application.DTOs.Product;

public class ProductResultDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int TotalStock { get; set; }
    public String CategoryName { get; set; } = string.Empty;

}