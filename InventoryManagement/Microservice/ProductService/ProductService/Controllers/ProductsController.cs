using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProductsController: ControllerBase{

    private readonly ProductServiceContext _context;

    public ProductsController(ProductServiceContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO product){
        var newProduct = new Product{
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id){
        var product = await _context.Products.FindAsync(id);
        if(product == null){
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> getProducts(){
        var products = await _context.Products.ToArrayAsync();
        return Ok(products);
    }

}