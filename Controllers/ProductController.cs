using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personalProjectAPI.Domains;
using personalProjectAPI.Exceptions;
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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddProducts(AddProductRequest product)
    {
        try
        {
            await _productHandler.AddProducts(product);
            return Ok();
        }
        catch(InvalidArgumentException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch(DuplicateEntryException ex)
        {
            return StatusCode(409, ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    [HttpPut]
    public async Task<IActionResult> EditProducts(EditProductRequest product)
    {
        try
        {
            await _productHandler.EditProducts(product);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (InvalidArgumentException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        //have to return ex.message - if you try to return the whole exception object itself(ex), there will be a 'serialisation error', and will always return a 500
        //something to do with JSON not being able to serialise the object and return it 
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProducts(DeleteProductRequest product)
    {
        try
        {
            await _productHandler.DeleteProducts(product);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(404, ex.Message);
        }
        catch (InvalidArgumentException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
  
    }


}