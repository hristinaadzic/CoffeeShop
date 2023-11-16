using CoffeeShop.Api.Core.DTO;
using CoffeeShop.Application.UseCases.Commands.Baverages;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Baverages;
using CoffeeShop.Implementation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaverageController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };
        private UseCaseHandler _handler;

        public BaverageController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetBaveragesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBaverageQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateBaverageDtoWithImage dto, [FromServices] ICreateBaverageCommand command)
        {
            if (dto.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.Image.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.Image.CopyTo(stream);


                dto.ImagePath = fileName;
            }
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromRoute] BaverageDto dto, [FromServices] IChangeStatusOfBaverageCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
