﻿using businessLogic.BL;
using businessLogic.Interface;
using businessLogic.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Authorize]
    [EnableCors]  
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductBL productBL) : ControllerBase
    {
        private readonly IProductBL productBL = productBL;
        [AllowAnonymous]
        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<ProductsUI>>>GetAll()
        {
            var result = await productBL.All();
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsUI>> Get(int id)
        {
            var result = await productBL.GetById(id);
            if(result == null) { return BadRequest(); }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult> Post( ProductsUI product)
        {
            var result = await productBL.Add(product);
            if(result==false) { return BadRequest(); }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Upadte (ProductsUI products)
        {
            var result = await productBL.Update(products);
            if (result == false) { return BadRequest(); }
            return Ok();
        }        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await productBL.Delete(id);
            if (result == false) { return BadRequest(); }
            return Ok();
        }        
        [HttpGet ("{Name}")]
        public async Task<List<ProductsUI>> GetAll(string Name)
        {
            var result =  productBL.GetByName(Name);
            if(result == null) { BadRequest(); }
            return result;
        }
    }
}
