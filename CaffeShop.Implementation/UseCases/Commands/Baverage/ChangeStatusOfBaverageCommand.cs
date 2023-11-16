using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.Commands.Baverages;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Baverage
{
    public class ChangeStatusOfBaverageCommand : EfUseCase, IChangeStatusOfBaverageCommand
    {
        public ChangeStatusOfBaverageCommand(Context context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Change status of baverage";

        public string Description => "Change status of baverage (active/non active)";

        public void Execute(BaverageDto request)
        {
            var id = request.id;

            var baverage = Context.Baverages.FirstOrDefault(x => x.Id == id);

            if (baverage == null)
            {
                throw new EntityNotFoundException(nameof(Baverage), request);
            }

            if (baverage.IsActive) baverage.IsActive = false;
            else baverage.IsActive = true;

            baverage.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
