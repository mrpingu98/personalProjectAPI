using personalProjectAPI.Domains;
using personalProjectAPI.Exceptions;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Handlers
{
	public class ProductHandler : IProductHandler
	{
		private readonly IProductRepository _productRepository;

		public ProductHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}


        public async Task<IEnumerable<Product>> GetAllProducts()
		{
            var result = await _productRepository.GetAllProducts();
			return result;
        }


        public async Task<Product?> GetProduct(string name)
        {
            var product = await _productRepository.GetProduct(name);

            return product;
        }


        public async Task AddProducts(AddProductRequest product)
		{
			if(product.Name == "" || product.Price == 0 || product.Description == "")
			{
				throw new InvalidArgumentException("Must input required information for a new product");
			}

            var checkProductAlreadyExists = await GetProduct(product.Name);

            if (checkProductAlreadyExists != null)
			{
                throw new DuplicateEntryException(product.Name);
            }
			else
			{
                await _productRepository.AddProducts(product);
            }
			//if product already exists
			//if name desciption and price are empty 
		}
        //if price is null


        public async Task EditProducts(EditProductRequest product)
        {
            if (product.Name == "")
            {
                throw new InvalidArgumentException("Name cannot be empty");
            }

            var getProduct = await GetProduct(product.Name);

           
            if (product.NewName == "" && product.ImageUrl == "" && product.Description == "" && product.Price == 0)
            {
                throw new InvalidArgumentException("An update must be made to the product");
            }
            if (getProduct == null)
            {
                throw new EntityNotFoundException(product.Name);
            }
            else
			{
                await _productRepository.EditProducts(product);
            }
			//empty name
			//no update to product
			//product not found
        }


		public async Task DeleteProducts(DeleteProductRequest product)
		{
            if (product.Name == "")
            {
                throw new InvalidArgumentException("Name cannot be empty");
            }

            var productToDelete = await GetProduct(product.Name);

			if(productToDelete == null)
			{
				throw new EntityNotFoundException(product.Name);
			}
			else
			{
                await _productRepository.DeleteProducts(product);
            }
			//empty name
			//product not found
		}

    }
}

//we just await the method call to the repo as nothing is returned - don't need to assign it to a variable