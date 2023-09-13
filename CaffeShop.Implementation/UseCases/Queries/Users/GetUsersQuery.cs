using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Users;
using CoffeeShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Users
{
    public class GetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public GetUsersQuery(Context context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Searc users";

        public string Description => "Search users using EF";

        public IEnumerable<UserDto> Execute(BaseSearch request)
        {
            var query = Context.Users.Where(x => x.IsActive).Include(x => x.Role).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(request.Keyword) ||
                                         x.LastName.Contains(request.Keyword));
            }

            return query.Select(x => new UserDto
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Role = x.Role.Name
            }).ToList();
        }
    }
}
