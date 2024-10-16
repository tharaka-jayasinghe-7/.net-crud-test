using System.ComponentModel.DataAnnotations;


namespace dotnet_crud_test.Models;

public class ProductDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = "";
    
    [Required, MaxLength(100)]
    public string Brand { get; set; } = "";
    
    [Required, MaxLength(100)]
    public string Category { get; set; } = "";
    
    [Required]
    public decimal Price { get; set; }
    
    [Required, MaxLength(100)]
    public string Description { get; set; } = "";
    
}