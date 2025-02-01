
using businessLogic.BL;
using businessLogic.Interface;
using businessLogic.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController(IInvoiceBL _InvoiceBl) : ControllerBase
    {
        private readonly IInvoiceBL invoiceBl = _InvoiceBl;
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<InvoiceUI>>> Get() 
        {
            var result = await invoiceBl.All();
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetId")]
        public async Task<ActionResult<InvoiceUI>> GetById(int id)
        {
            var result =  invoiceBl.GetById(id);
            if(result == null) { return BadRequest(); }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetByCustomerName")]
        public async Task<ActionResult<List<InvoiceUI>>> GetByCustomerName(string Name)
        {
            var result =  invoiceBl.GetByCustomerName(Name);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        //[HttpGet("GetByCustomerEmail")]
        //public async Task<ActionResult<List<InvoiceUI>>> GetByCustomerEmail(string Email)
        //{
        //    var result = _InvoiceBl.(Email);
        //    if (result == null) { return BadRequest(); }
        //    return Ok(result);
        //}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(InvoiceUI orderUI)
        {
            var result = await invoiceBl.Add(orderUI);
            if(result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(InvoiceUI order)
        {
            var result = await invoiceBl.Update(order);
            if (result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await invoiceBl.Delete(id);
            if (result == false) { return BadRequest(); }
            else { return Ok(result); }
        }
    }
}
