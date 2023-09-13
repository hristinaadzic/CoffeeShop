using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.DTO
{
    public class BaverageDto : Dto
    {
        public string BaverageName { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
