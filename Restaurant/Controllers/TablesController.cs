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
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        private readonly ILogger<TablesController> _logger;

        public TablesController(
            ITableService tableService,
            IMapper mapper,
            ILogger<TablesController> logger)
        {
            _tableService = tableService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _tableService.GetAll();

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
            var result = _tableService.GetById(id);

            if (result == null)
            {
                return NotFound(id);
            }

            var response = _mapper.Map<TableResponse>(result);

            this._logger.LogInformation("Get by id returned OK");

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TableRequest tableRequest)
        {
            if (tableRequest == null)
            {
                return BadRequest();
            }

            var order = _mapper.Map<Table>(tableRequest);

            var result = _tableService.Create(order);

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

            var result = _tableService.Delete(id);

            if (result != null)
            {
                this._logger.LogInformation("Delete returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Table table)
        {
            if (table == null)
            {
                return BadRequest();
            }

            var searchOrder = _tableService.GetById(table.Id);

            if (searchOrder == null)
            {
                return NotFound(table);
            }

            var result = _tableService.Update(table);

            if (result != null)
            {
                this._logger.LogInformation("Update returned OK");
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
