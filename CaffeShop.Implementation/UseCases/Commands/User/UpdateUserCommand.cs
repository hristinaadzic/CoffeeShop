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
    public class UpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        public UpdateUserCommand(Context context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Update user";

        public string Description => "Update user using EF";

        public void Execute(UserDto request)
        {
            var id = request.id;
            var firstName = request.FirstName;
            var lastName = request.LastName;
            var email = request.Email;

            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email))
            {
                throw new Exception();
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            Context.SaveChanges();
        }
    }
}
