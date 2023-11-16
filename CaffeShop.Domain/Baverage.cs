using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class Baverage : Entity
    {
        public string BaverageName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BaverageIngredient> BaverageIngredients { get; set; }
        public ICollection<BaverageSize> BaverageSizes { get; set; }
    }
}
