using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class BaverageIngredientSize
    {
        public int BaverageIngredientId { get; set; }
        public int SizeId { get; set; }
        public int IngredientQuantity { get; set; }
        public decimal Price { get; set; }
        public BaverageIngredient BaverageIngredient { get; set; }
        public Size Size { get; set; }
        //public ICollection<Price> Prices { get; set; }
    }
}
