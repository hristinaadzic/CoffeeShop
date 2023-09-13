using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.Commands.User;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.User
{
    public class ChangeStatusOfUserCommand : EfUseCase, IChangeStatusOfUserCommand
    {
        public ChangeStatusOfUserCommand(Context context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Change status of user";

        public string Description => "Change status of user (active/non active)";

        public void Execute(UserDto request)
        {
            var id = request.id;
            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(user), request);
            }

            if (user.IsActive) user.IsActive = false;
            else user.IsActive = true;

            user.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
