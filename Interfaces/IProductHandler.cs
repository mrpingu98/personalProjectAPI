using System;
using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Interfaces
{
	public interface IProductHandler
	{
		Task<IEnumerable<Product>> GetAllProducts();
        Task AddProducts(AddProductRequest product);
        Task EditProducts(EditProductRequest productName);
        Task DeleteProducts(string name);
    }
}

