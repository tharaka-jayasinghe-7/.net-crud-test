using dotnet_crud_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_test.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}