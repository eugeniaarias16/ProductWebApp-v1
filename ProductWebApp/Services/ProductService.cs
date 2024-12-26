using ProductWebApp.Repositories;
using ProductWebApp.Models;
using ProductWebApp.Services;


namespace ProductWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void ValidateProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Category) || product.Price < 0)
            {
                throw new ArgumentException("Invalid Product Data.");
            }

        }

        public List<Product> GetAllProducts() => _productRepository.GetAll();

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not Found.");

            }
            return product;
        }

        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            _productRepository.Add(product);
        }

        public void UpDateProduct(Product product)
        {
            if (_productRepository.GetById(product.Id) == null)
            {
                throw new InvalidOperationException("Product not Found.");
            }
            ValidateProduct(product);
            _productRepository.UpDate(product);
        }

        public void DeleteProduct(int id)
        {
            if (_productRepository.GetById(id) == null)
            {
                throw new InvalidOperationException("Product not Found.");
            }
            _productRepository.Delete(id);

        }

    }
}
