using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = _manager.ProductService.GetAllProduct(false);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneProduct([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetProductById(id, false);
            
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateOneProduct([FromBody] ProductDtoForInsertion productdto)
        {

            if (productdto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var product=_manager.ProductService.CreateOneProduct(productdto);

            return StatusCode(201, product);

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDtoForUpdate productdto)
        {

            if (productdto is null)
                return BadRequest();
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _manager.ProductService.UpdateOneProduct(id, productdto, false);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProduct([FromRoute(Name = "id")] int id)
        {

            _manager.ProductService.DeleteOneProduct(id, false);
            return NoContent();

        }
    }
}
