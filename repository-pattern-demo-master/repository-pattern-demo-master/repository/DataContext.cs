using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class DataContext : IProductRepository   //data base
    {
        public void AddProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
