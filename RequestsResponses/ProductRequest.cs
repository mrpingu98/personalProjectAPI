using System;
namespace personalProjectAPI.RequestsResponses
{
	public class ProductRequest
	{
        public required string Name { get; set; }

        public required string Description { get; set; }

        public double Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

