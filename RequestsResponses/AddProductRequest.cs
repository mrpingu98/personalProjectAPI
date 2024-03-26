using System;
namespace personalProjectAPI.RequestsResponses
{
	public class AddProductRequest
	{
        public required string Name { get; set; }

        public required string Description { get; set; }

        public float Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

