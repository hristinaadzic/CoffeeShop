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
        public string Description { get; set; }
        public string Category { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
        public IEnumerable<SizeDto> Sizes { get; set; }
    }

    public class CreateBaverageDto
    {
        public string BaverageName { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int[] IngredientIds { get; set; }
        public int[] SizeIds { get; set; }
    }
}
