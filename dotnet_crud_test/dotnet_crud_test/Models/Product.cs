using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_test.Models;

public class Product
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = "";
    
    [MaxLength(100)]
    public string Brand { get; set; } = "";
    
    [MaxLength(100)]
    public string Category { get; set; } = "";
    
    [Precision(16,2)]
    public decimal Price { get; set; }
    
    public string Description { get; set; } = "";
    [MaxLength(100)]
    
    public DateTime CreatedAt { get; set; }
    
}