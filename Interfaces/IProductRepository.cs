using System;
using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Interfaces
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProducts();
        Task AddProducts(AddProductRequest product);
        Task EditProducts(EditProductRequest productName);
    }
}

