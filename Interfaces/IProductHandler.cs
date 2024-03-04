using System;
using personalProjectAPI.Domains;

namespace personalProjectAPI.Interfaces
{
	public interface IProductHandler
	{
		IEnumerable<Product> GetAllProducts { get; }
	}
}

