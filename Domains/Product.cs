using System;
namespace personalProjectAPI.Domains
{
	public class Product
	{
		public Product()
		{
		}

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public float Price { get; set; }

		public string? ImageUrl { get; set; }
	}
}

