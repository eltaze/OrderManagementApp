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
    public class InvoiceDetailsController (IInvoiceDetailsBL _invoiceDetails): ControllerBase
    {
        private readonly IInvoiceDetailsBL invoiceDetails = _invoiceDetails;
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<InvoiceDetailsUI>>> Get()
        {
            var result = await invoiceDetails.All();
            if(result == null) { return BadRequest() ; }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailsUI>> Get(int id)
        {
            var result = await invoiceDetails.GetById(id);
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(InvoiceDetailsUI value)
        {
            var result = await invoiceDetails.Add(value);
            if (result == false) {  return BadRequest(); }
            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Put(InvoiceDetailsUI value)
        {
            var result = await invoiceDetails.Update(value);
            if (result == false) { return BadRequest(); }
            return Ok(result);
        }       
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await invoiceDetails.Delete(id);
            if (result == false) { return BadRequest(); }
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("ByOrderId")]
        public async Task<ActionResult<List<InvoiceDetailsUI>>>GetByOrderId(int id)
        {
            var result =  invoiceDetails.GetByOrderId(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("GetByProduct")]
        public async Task<ActionResult<List<InvoiceDetailsUI>>> GetByProduct(int id)
        {
            var result =  invoiceDetails.GetByProdcutId(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
