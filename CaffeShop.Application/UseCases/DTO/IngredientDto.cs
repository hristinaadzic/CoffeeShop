using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.DTO
{
    public class IngredientDto : Dto
    {
        public string IngredientName { get; set; }
        public int Quantity { get; set; }

    }
}
