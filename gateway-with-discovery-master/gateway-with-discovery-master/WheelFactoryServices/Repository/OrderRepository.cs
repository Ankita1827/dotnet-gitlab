using OrderService.Repository;
using WheelFactoryServices.Models;

namespace WheelFactoryServices.Repository
{
    public class OrderRepository
    {
        MongoContext _mongoContext;        
        public OrderRepository()
        {
            _mongoContext = new MongoContext();
        }
        public List<Order> GetOrders()
        {
            return _mongoContext.GetOrders();
        }
        public void AddOrder(Order order)
        {
            _mongoContext.AddOrder(order);
        }
        public List<Order> GetOrderById(string id)
        {
            return _mongoContext.GetOrderById(id);
        }
    }
}
