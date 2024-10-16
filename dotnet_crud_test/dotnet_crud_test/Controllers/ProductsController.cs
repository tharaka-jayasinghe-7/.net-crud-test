using dotnet_crud_test.Models;
using dotnet_crud_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crud_test.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext context;
    
    public ProductsController(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public IActionResult Index()
    {
        var products = context.Products.OrderByDescending(p => p.Id).ToList();
        return View(products);
    }

    public IActionResult Create()   
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(ProductDto productDto)   
    {
        if (!ModelState.IsValid)
        {
            return View(productDto);
        }

        Product product = new Product()
        {
            Name = productDto.Name,
            Brand = productDto.Brand,
            Category = productDto.Category,
            Price = productDto.Price,
            Description = productDto.Description,
            CreatedAt = DateTime.Now
        };
        context.Products.Add(product);
        context.SaveChanges();
        
        return RedirectToAction("Index", "Products");
    }
}