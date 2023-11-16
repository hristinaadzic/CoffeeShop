using CoffeeShop.Application.UseCases.DTO;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Api.Core.DTO
{
    public class CreateBaverageDtoWithImage : CreateBaverageDto
    {
        public IFormFile Image { get; set; }
    }
}
