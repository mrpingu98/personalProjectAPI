using Microsoft.AspNetCore.Mvc;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;

namespace personalProjectAPI.Controllers;

[ApiController]
[Route("/product")]
public class ProductController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProductController> _logger;

    private readonly IProductHandler _productHandler;

    public ProductController(ILogger<ProductController> logger, IProductHandler productHandler)
    {
        _logger = logger;
        _productHandler = productHandler;
    }

    //[HttpGet]
    //public IEnumerable<WeatherForecast> TestOne()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}

    [HttpGet]
    public IEnumerable<Product> GetAllProducts()
    {
        return _productHandler.GetAllProducts;
    }
}
