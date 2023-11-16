using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class BaverageSize : Entity
    {
        public int BaverageId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public Baverage Baverage { get; set; }
        public Size Size { get; set; }
    }
}
