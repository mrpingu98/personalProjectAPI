using Microsoft.AspNetCore.Mvc;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Controllers;

[ApiController]
[Route("/product/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductHandler _productHandler;

    public ProductController(IProductHandler productHandler)
    {
        _productHandler = productHandler;
    }

   
    [HttpGet("get")]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var result = await _productHandler.GetAllProducts();
        return result;
    }

    [HttpPost]
    public async Task AddProducts(AddProductRequest product)
    {
            await _productHandler.AddProducts(product);
    }

    [HttpPut]
    public async Task EditProducts(EditProductRequest product)
    {
        await _productHandler.EditProducts(product);
    }

    [HttpDelete]
    public async Task DeleteProducts(DeleteProductRequest product)
    {
        await _productHandler.DeleteProducts(product);
    }


}