using System;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Handlers
{
	public class ProductHandler : IProductHandler
	{
		private readonly IProductRepository _productRepository;

		public ProductHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

        public async Task<IEnumerable<Product>> GetAllProducts()
		{
            var result = await _productRepository.GetAllProducts();
			return result;
        }

		public async Task AddProducts(AddProductRequest product)
		{
			await _productRepository.AddProducts(product);
		}

        public async Task EditProducts(EditProductRequest product)
        {
            await _productRepository.EditProducts(product);
        }

		public async Task DeleteProducts(string name)
		{
			await _productRepository.DeleteProducts(name);
		}

    }
}

//we just await the method call to the repo as nothing is returned - don't need to assign it to a variable