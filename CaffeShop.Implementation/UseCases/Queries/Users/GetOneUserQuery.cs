using CoffeeShop.Application.Exceptions;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.Queries.Users;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Users
{
    public class GetOneUserQuery : EfUseCase, IGetOneUserQuery
    {
        public GetOneUserQuery(Context context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Get user by id";

        public string Description => "Get user by id using EF";

        public UserDto Execute(int request)
        {
            var user = Context.Users.Where(x => x.IsActive).Include(x => x.Role).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }

            return new UserDto
            {
                id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role.Name
            };
        }
    }
}
