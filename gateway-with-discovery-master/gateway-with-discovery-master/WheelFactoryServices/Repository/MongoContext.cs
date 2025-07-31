using MongoDB.Driver;
using WheelFactoryServices.Models;

namespace OrderService.Repository
{
    public class MongoContext
    {
        MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
        IMongoDatabase db;
        public IMongoCollection<Order> orders;
        public MongoContext()
        {
            db = client.GetDatabase("itcjune25");
            orders = db.GetCollection<Order>("Order");
        }
        public void AddOrder(Order order)
        {
            orders.InsertOne(order);
        }
        public List<Order> GetOrders()
        {
            return orders.Find(p => true).ToList();

        }
        public List<Order> GetOrderById(string id)
        {
            return orders.Find(p=>p.Id == id).ToList();
        }
    }
}
