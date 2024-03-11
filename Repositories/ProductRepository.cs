using System;
using Microsoft.EntityFrameworkCore;
using personalProjectAPI.Db;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly PersonalProjectDbContext _dbContext;

		public ProductRepository(PersonalProjectDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			var result = await _dbContext.Product.ToListAsync();

			return result; 
        }

        public async Task AddProducts(ProductRequest productRequest)
        {
			var product = new Product
			{
				Name = productRequest.Name,
				Description = productRequest.Description,
				Price = productRequest.Price
			};

			_dbContext.Product.Add(product);
			await _dbContext.SaveChangesAsync();
        }

    }
}

