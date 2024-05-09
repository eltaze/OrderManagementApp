
using businessLogic.BL;
using businessLogic.Model;
using DataBack.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderBL orderBL) : ControllerBase
    {
        private readonly OrderBL orderBL = orderBL;
        [HttpGet]
        public async Task<ActionResult<List<OrderUI>>> Get() 
        {
            var result = await orderBL.All();
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpGet("GetId")]
        public async Task<ActionResult<OrderUI>> GetById(int id)
        {
            var result = await orderBL.GetById(id);
            if(result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpGet("GetByCustomerName")]
        public async Task<ActionResult<List<OrderUI>>> GetByCustomerName(string Name)
        {
            var result = await orderBL.GetByCustomerName(Name);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpGet("GetByCustomerEmail")]
        public async Task<ActionResult<List<OrderUI>>> GetByCustomerEmail(string Email)
        {
            var result = await orderBL.GetByCustomerEmail(Email);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create(OrderUI orderUI)
        {
            var result = await orderBL.Add(orderUI);
            if(result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
        [HttpPut]
        public async Task<ActionResult> Update(OrderUI order)
        {
            var result = await orderBL.Update(order);
            if (result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await orderBL.Delete(id);
            if (result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
    }
}
