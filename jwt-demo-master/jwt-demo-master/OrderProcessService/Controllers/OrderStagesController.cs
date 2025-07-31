using Microsoft.AspNetCore.Mvc;
using OrderProcessService.Models;
using OrderProcessService.Repository;
using System.Collections.Generic;

namespace OrderProcessService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessController : ControllerBase
    {
        private readonly OrderStagesRepo _repo;

        public OrderProcessController(OrderStagesRepo repo)
        {
            _repo = repo;
        }

        // GET: api/OrderProcess
        [HttpGet]
        public ActionResult<List<OrderStages>> Show()
        {
            return _repo.ShowOrders();
        }

        // GET: api/OrderProcess/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _repo.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order Not Found");
            }
            return Ok(order);
        }

        // POST: api/OrderProcess
        [HttpPost]
        public IActionResult NewOrder([FromBody] OrderStages order)
        {
            var createdOrder = _repo.Create(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }
        // DELETE: api/OrderProcess/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            bool result = _repo.DeleteOrder(id);
            if (result)
            {
                return Ok("Order Deleted Successfully");
            }
            else
            {
                return NotFound("Order Not Found");
            }
        }
        // PUT: api/OrderProcess/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderStages updatedOrder)
        {
            var result = _repo.EditOrder(id, updatedOrder);
            if (result == null)
            {
                return NotFound("Order Not Found");
            }
            return Ok("Order Updated Successfully");
        }
    }
}
