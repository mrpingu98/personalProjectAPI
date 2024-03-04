using System;
using Microsoft.EntityFrameworkCore;
using personalProjectAPI.Db;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;

namespace personalProjectAPI.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly PersonalProjectDbContext _dbContext;

		public ProductRepository(PersonalProjectDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Product> GetAllProducts => _dbContext.Product;
	}
}

