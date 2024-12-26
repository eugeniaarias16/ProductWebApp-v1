using ProductWebApp.Models;

namespace ProductWebApp.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void UpDate(Product product);
        void Delete(int id);


    }
}
