using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.BL.Interfaces;
using Restaurant.Models.DTO;
using Restaurant.Models.Requests;
using Restaurant.Models.Responses;

namespace Restaurant.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IProductService productService,
            IMapper mapper,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result != null)
            {
                this._logger.LogInformation("Get all returned OK");
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            if (result == null)
            {
                return NotFound(id);
            }

            var response = _mapper.Map<ProductResponse>(result);

            this._logger.LogInformation("Get by id returned OK");

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productRequest);

            var result = _productService.Create(product);

            this._logger.LogInformation("Create returned OK");

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(id);
            }

            var result = _productService.Delete(id);

            if (result != null)
            {
                this._logger.LogInformation("Delete returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var searchOrder = _productService.GetById(product.Id);

            if (searchOrder == null)
            {
                return NotFound(product);
            }

            var result = _productService.Update(product);

            if (result != null)
            {
                this._logger.LogInformation("Update returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
