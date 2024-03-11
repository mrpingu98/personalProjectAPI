using System;
using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Interfaces
{
	public interface IProductHandler
	{
		Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> AddProducts(AddProductRequest product);
        Task<IEnumerable<Product>> EditProducts(EditProductRequest productName);
    }
}

