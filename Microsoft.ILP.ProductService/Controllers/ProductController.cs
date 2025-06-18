using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.ProductService.DTOs;
using Microsoft.ILP.ProductService.Services;

namespace Microsoft.ILP.ProductService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto> Create([FromBody] CreateProductDto dto)
        {
            var product = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductDto dto)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();

            _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }
    }
}
