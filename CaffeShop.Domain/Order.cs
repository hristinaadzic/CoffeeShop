using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
