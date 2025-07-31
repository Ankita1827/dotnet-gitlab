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
        //start soldering process
        [HttpPost]
        [Route("startsoldering")]
        public IActionResult StartSolering(int orderid)
        {
            _repo.StartSoldering(orderid);
            return Ok();
        }
        [HttpPost]
        [Route("startpainting")]
        public IActionResult StartPainting(int orderid)
        {
            _repo.StartPainting(orderid);
            return Ok();
        }
        [HttpPost]
        [Route("startpackaging")]
        public IActionResult StartPackaging(int orderid) { 
            _repo.StartPackaging(orderid);
            return Ok();
        }
        [HttpPut]
        [Route("completesoldering")]
        public IActionResult CompleteSoldering(int orderid,UpdateStageDTO stage)
        {
            if(_repo.CompleteSoldering(orderid, stage))
            {
                _repo.StartPainting(orderid);
                return Ok(true);
            }

            return BadRequest(true);
        }
        [HttpPut]
        [Route("completepainting")]
        public IActionResult CompletePainting(int orderid,UpdateStageDTO stage)
        {
            if(_repo.CompletePainting(orderid, stage))
            {
                _repo.StartPackaging(orderid);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("completepackaging")]
        public IActionResult CompletePackaging(int orderid,[FromBody]UpdateStageDTO stage)
        {
            _repo.CompletePackaging(orderid, stage);
            return Ok();
        }
    }
}
