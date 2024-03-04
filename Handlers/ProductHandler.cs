using System;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;

namespace personalProjectAPI.Handlers
{
	public class ProductHandler : IProductHandler
	{
		private readonly IProductRepository _productRepository;

		public ProductHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

        public IEnumerable<Product> GetAllProducts =>_productRepository.GetAllProducts;
    }
}

