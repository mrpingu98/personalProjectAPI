﻿using System;
using Microsoft.AspNetCore.Mvc;
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
			var products = await _dbContext.Product.ToListAsync();

			return products; 
        }


        public async Task<Product?> GetProduct(string name)
        {
           var product = await _dbContext.Product.FirstOrDefaultAsync(item => item.Name == name);

            return product;
        }


        public async Task AddProducts(AddProductRequest product)
        {
			var newProduct = new Product
			{
				Name = product.Name,
				Description = product.Description,
				Price = product.Price
			};

			_dbContext.Product.Add(newProduct);
			await _dbContext.SaveChangesAsync();
        }

        public async Task EditProducts(EditProductRequest product)
        {
            var productToUpdate = _dbContext.Product.FirstOrDefault(item => item.Name == product.Name);
            //have use FirstOrDefault as this will only return one product
            //if you use where, will return a list of products
            if (productToUpdate != null)
			{
				if (!string.IsNullOrEmpty(product.NewName))
				{
                    productToUpdate.Name = product.NewName;
                }

                if (!string.IsNullOrEmpty(product.Description))
                {
                    productToUpdate.Description = product.Description;
                }

                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    productToUpdate.ImageUrl = product.ImageUrl;
                }

                if (product.Price.HasValue)
                {
                    productToUpdate.Price = product.Price.Value;
                }
                //have to put .Value to convert the nullable? price to an explicit non-nullable type
            }
                await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProducts(DeleteProductRequest product)
        {
            var productToDelete = _dbContext.Product.FirstOrDefault(item => item.Name == product.Name);

            if (productToDelete != null)
            {
                _dbContext.Product.Remove(productToDelete);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}

