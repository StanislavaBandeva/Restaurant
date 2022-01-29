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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrderService orderService,
            IMapper mapper,
            ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();

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
            var result = _orderService.GetById(id);

            if (result == null)
            {
                return NotFound(id);
            }

            var response = _mapper.Map<OrderResponse>(result);

            this._logger.LogInformation("Get by id returned OK");

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                return BadRequest();
            }

            var order = _mapper.Map<Order>(orderRequest);

            var result = _orderService.Create(order);

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

            var result = _orderService.Delete(id);

            if (result != null)
            {
                this._logger.LogInformation("Delete returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var searchOrder= _orderService.GetById(order.Id);

            if (searchOrder == null)
            {
                return NotFound(order);
            }

            var result = _orderService.Update(order);

            if (result != null)
            {
                this._logger.LogInformation("Update returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
