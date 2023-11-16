using CoffeeShop.Application.UseCases.Commands.Orders;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private UseCaseHandler _handler;

        public OrderController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

    }
}
