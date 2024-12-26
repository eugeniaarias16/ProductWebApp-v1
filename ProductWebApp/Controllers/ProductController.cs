using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductWebApp.Models;
using ProductWebApp.Services;
namespace ProductWebApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                return Ok(product);
            }
            catch(InvalidOperationException ex)

            {
                return NotFound(ex.Message);
            }

        }
        
        public IActionResult CreateProduct(int id,[FromBody]Product product)
        {
            if(id != product.Id)
            {
                return BadRequest("The ID mismatch.");
            }
            try
            {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IActionResult UpDate(int id,[FromBody]Product product)
        {

            try
            {
                _productService.UpDateProduct(product);
                return NoContent();
            }

            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
    }
}
