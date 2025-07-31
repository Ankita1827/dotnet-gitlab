using Microsoft.AspNetCore.Mvc;
using OrderProcessService.Filters;
using OrderProcessService.Models;
using OrderProcessService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderProcessService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(OrderStageLogActionFilter))]
    // [OrderStageLogActionFilter]
    [ExcpHandlingFilter]
    public class OrderStageGetController : ControllerBase
    {
        private readonly OrderStageGetRepo _repo;
        private readonly ILogger<OrderStageGetController> _logger;
        public OrderStageGetController(OrderStageGetRepo repo,ILogger<OrderStageGetController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        // GET: api/ -- Get all order stage
        [HttpGet]
        public ActionResult<List<OrderStages>> Show()
        {
            _logger.LogInformation("Show order method called at :"+DateTime.Now.ToString()+Request.Host.ToString());
            throw new Exception("fldkfj");
            return _repo.ShowOrders();
        }        
        [HttpGet]
        [Route("SolderingNotCompleted")]
        public IActionResult GetSolderingNotCompleted() {
            _logger.LogInformation("Soldering not completed method called at :" + DateTime.Now.ToString() + Request.Host.ToString());
            return Ok(_repo.GetSolderingToComplete());
        }
        [HttpGet]
        [Route("PaintingNotStarted")]
        public IActionResult GetPaintingNotStarted()
        {
            return Ok(_repo.GetPaintingToStart());
        }
        [HttpGet]
        [Route("PaintingNotCompleted")]
        public IActionResult GetPaintingNotCompleted()
        {
            return Ok(_repo.GetPaintingToComplete());
        }
        [HttpGet]
        [Route("GetPackagingNotStarted")]
        public IActionResult GetPackagingNotStarted()
        {
            return Ok(_repo.GetPackagingToStart());
        }
        [HttpGet]
        [Route("GetPackagingNotCompleted")]
        public IActionResult GetPackagingNotCompleted()
        {
            return Ok(_repo?.GetPackagingToComplete());
        }
    }
}
