using CoffeeShop.Application.UseCases.Commands.Orders;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Orders
{
    public class CreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        public CreateOrderCommand(Context context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Create order";

        public string Description => "Create order using EF";

        public void Execute(CreateOrderDto request)
        {

            var order = new Order
            {
                UserId = request.UserId,
                PaymentId = request.PaymentId,
                OrderLines = request.OrderLines.Select(x => new OrderLine{
                    BavIngSizeId = x.BavSizeId,
                    Quantity = x.Quantity,
                    Price = x.PriceForOne,
                    ProductName = x.ProductName
                }).ToList()
            };
            order.Total = order.OrderLines.Select(x => x.Price * x.Quantity).Sum();

            Context.Orders.Add(order);
            Context.OrderLines.AddRange(order.OrderLines);
            Context.SaveChanges();
        }
    }
}
