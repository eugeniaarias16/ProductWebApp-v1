using ProductWebApp.Models;


namespace ProductWebApp.Services

{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpDateProduct(Product product);
        void DeleteProduct(int id);

        void ValidateProduct(Product product);



    }
}
