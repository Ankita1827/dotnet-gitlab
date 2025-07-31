using Microsoft.EntityFrameworkCore;
using OrderProcessService.Models;

namespace OrderProcessService.Repository
{
    public class OrderStagesRepo
    {
        private readonly OrderStagesDBContext _context;

        public OrderStagesRepo(OrderStagesDBContext context)
        {
            _context = context;
        }

        public OrderStages Create(OrderStages order)
        {
            _context.Database.ExecuteSqlRaw($"insert into orderstages values ('{order.Status}','{order.Remarks}','{order.Image}',getdate(),getdate(),{order.EmpId})");
            //_context.SaveChanges();
            return order;
        }

        public List<OrderStages> ShowOrders()
        {
            return _context.OrderStages.ToList();
        }

        public bool DeleteOrder(int id)
        {
            var order = _context.OrderStages.Find(id);
            if (order == null)
            {
                return false;
            }

            _context.OrderStages.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public OrderStages EditOrder(int id, OrderStages updatedOrder)
        {
            var existingOrder = _context.OrderStages.Find(id);
            if (existingOrder == null)
            {
                return null;
            }

            // Update relevant fields
            existingOrder.Status = updatedOrder.Status;
            existingOrder.Remarks = updatedOrder.Remarks;
            existingOrder.Image = updatedOrder.Image;
            existingOrder.StartDate = updatedOrder.StartDate;
            existingOrder.EndDate = updatedOrder.EndDate;
            existingOrder.EmpId = updatedOrder.EmpId;

            _context.SaveChanges();
            return existingOrder;
        }

        public OrderStages GetOrderById(int id)
        {
            return _context.OrderStages.FirstOrDefault(o => o.OrderId == id);
        }
    }
}
