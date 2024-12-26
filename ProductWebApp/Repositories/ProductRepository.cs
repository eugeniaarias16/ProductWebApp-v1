using ProductWebApp.Models;
using ProductWebApp.Repositories;

public class ProductRepository : IProductRepository
{
    private static List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1000.00m, Stock = 10 },
        new Product { Id = 2, Name = "Earbud", Category = "Electronics", Price = 50.00m, Stock = 55 },
        new Product { Id = 3, Name = "Smartphone", Category = "Electronics", Price = 800.00m, Stock = 15 }
    };

    public List<Product> GetAll() => _products;

    public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        var maxId = _products.Any() ? _products.Max(p => p.Id) : 0;
        product.Id = maxId + 1;
        _products.Add(product);
    }

    public void UpDate(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Stock = product.Stock;
        }
    }

    public void Delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
