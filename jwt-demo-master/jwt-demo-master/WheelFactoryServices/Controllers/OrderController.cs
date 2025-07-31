using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repository;
using WheelFactoryServices.Models;
using WheelFactoryServices.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WheelFactoryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;
        
        public OrderController()
        {
            _orderRepository= new OrderRepository();
        }
        // GET: api/<OrderController>
        
        [HttpGet]
        
        public IEnumerable<Order> Get()
        {
            return _orderRepository.GetOrders(); 
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(string id)
        {
            return _orderRepository.GetOrderById(id).FirstOrDefault();
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] UserDTO ut)
        {
            Order o=new Order();
            o.Id = "2";
            o.CustomerName = "ankita";// this.User.FindFirst("usernmame").Value;
            o.Model = ut.Model;
            o.Year =ut.Year;
            o.DamageType =ut.DamageType;
            _orderRepository.AddOrder(o);
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //Function to accept two number and return sum

    }
}
