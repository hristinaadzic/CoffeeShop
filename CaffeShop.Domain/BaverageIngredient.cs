using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class BaverageIngredient : Entity
    {
        public int BavarageId { get; set; }
        public int IngredientId { get; set; }
        public Baverage Baverage { get; set; }
        public Ingredient Ingredient { get; set; }
        public ICollection<BaverageIngredientSize> BaverageIngredientSizes { get; set; }
    }
}
