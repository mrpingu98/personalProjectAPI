using System;
using personalProjectAPI.Domains;

namespace personalProjectAPI.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts { get; }
	}
}

