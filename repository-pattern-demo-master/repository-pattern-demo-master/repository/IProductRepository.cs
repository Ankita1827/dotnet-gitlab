using Entities;

namespace repository
{
    public interface IProductRepository
    {
        public void AddProduct(Product p);
        public void RemoveProduct(Product p);
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public List<Product> GetAllProduct();
    }
}
