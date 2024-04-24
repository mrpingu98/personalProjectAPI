using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Interfaces
{
	public interface IProductHandler
	{
		Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProduct(string name);
        Task AddProducts(AddProductRequest product);
        Task EditProducts(EditProductRequest productName);
        Task DeleteProducts(DeleteProductRequest product);
    }
}

