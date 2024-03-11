using Microsoft.AspNetCore.Mvc;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Controllers;

[ApiController]
[Route("/product")]
public class ProductController : ControllerBase
{
    private readonly IProductHandler _productHandler;

    public ProductController(IProductHandler productHandler)
    {
        _productHandler = productHandler;
    }

   
    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var result = await _productHandler.GetAllProducts();
        return result;
    }

    [HttpPost]
    public async Task<IEnumerable<Product>> AddProducts(ProductRequest product)
    {
        var result = await _productHandler.AddProducts(product);
        return result;
    }

}