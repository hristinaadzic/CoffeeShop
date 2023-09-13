using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class Payment : Entity
    {
        public string PaymentMethod { get; set; }
    }
}
