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

    public IActionResult Edit(int id)
    {
        var product = context.Products.Find(id);

        if (product == null)
        {
            return RedirectToAction("Index", "Products");
        }

        var productDto = new ProductDto()
        {
            Name = product.Name,
            Brand = product.Brand,
            Category = product.Category,
            Price = product.Price,
            Description = product.Description,
        };
        ViewData["ProductId"] = product.Id;
        ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");
       
        
        return View(productDto);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, ProductDto productDto)
    {
        var product = context.Products.Find(id);
        if (product == null)
        {
            return RedirectToAction("Index", "Products");
        }

        if (!ModelState.IsValid)
        {
            ViewData["ProductId"] = product.Id;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");
            return View(productDto);
        }
        product.Name = productDto.Name;
        product.Brand = productDto.Brand;
        product.Category = productDto.Category;
        product.Price = productDto.Price;
        product.Description = productDto.Description;
        
        context.SaveChanges();
        return RedirectToAction("Index", "Products");
    }

    public IActionResult Delete(int id)
    {
        var product = context.Products.Find(id);

        if (product == null)
        {
            return RedirectToAction("Index", "Products");
        }
        context.Products.Remove(product);
        context.SaveChanges(true);
        
        return RedirectToAction("Index", "Products");
    }
}