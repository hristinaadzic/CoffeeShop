using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class Ingredient : Entity
    {
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public ICollection<BaverageIngredient> BavarageIngredients { get; set; }
    }
}
