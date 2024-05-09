using businessLogic.BL;
using businessLogic.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController (OrderDetailsBL orderDetails): ControllerBase
    {
        private readonly OrderDetailsBL orderDetails = orderDetails;
       
        [HttpGet]
        public async Task<ActionResult<List<OrderDetailsUI>>> Get()
        {
            var result = await orderDetails.All();
            if(result == null) { return BadRequest() ; }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsUI>> Get(int id)
        {
            var result = await orderDetails.GetById(id);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Post(OrderDetailsUI value)
        {
            var result = await orderDetails.Add(value);
            if (result == false) {  return BadRequest(); }
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> Put(OrderDetailsUI value)
        {
            var result = await orderDetails.Update(value);
            if (result == false) { return BadRequest(); }
            return Ok(result);
        }       
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await orderDetails.Delete(id);
            if (result == false) { return BadRequest(); }
            return Ok(result);
        }
        [HttpGet]
        [Route("ByOrderId")]
        public async Task<ActionResult<List<OrderDetailsUI>>>GetByOrderId(int id)
        {
            var result = await orderDetails.GetByOrder(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetByProduct")]
        public async Task<ActionResult<List<OrderDetailsUI>>> GetByProduct(int id)
        {
            var result = await orderDetails.GetPyProduct(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
