using CoffeeShop.Application.UseCases.Commands.Reservations;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Reservations;
using CoffeeShop.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ReservationController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetReservationQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationDto dto, [FromServices] ICreateReservationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
