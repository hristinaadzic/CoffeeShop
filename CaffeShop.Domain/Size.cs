using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class Size : Entity
    {
        public string SizeValue { get; set; }
        public ICollection<BaverageIngredientSize> baverageIngredientSizes { get; set; }
    }
}
