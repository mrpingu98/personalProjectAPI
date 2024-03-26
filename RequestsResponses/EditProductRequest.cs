using System;
namespace personalProjectAPI.RequestsResponses
{
	public class EditProductRequest
	{
		public EditProductRequest()
		{
		}

        public required string Name { get; set; }

        public string? NewName { get; set; }

        public string? Description { get; set; }

        public float? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

