using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ProductRepository
    {
        IProductRepository repository;
        public ProductRepository(IProductRepository data) {
         repository = data;
        }
        public void AddProducrtr(Product p)
        {
            repository.AddProduct(p);
        }
    }
}
