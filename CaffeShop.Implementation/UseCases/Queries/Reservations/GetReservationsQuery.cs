using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.Application.UseCases.DTO.Searches;
using CoffeeShop.Application.UseCases.Queries.Reservations;
using CoffeeShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Queries.Reservations
{
    public class GetReservationsQuery : EfUseCase, IGetReservationQuery
    {
        public GetReservationsQuery(Context context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Search reservations";

        public string Description => "Search reservations using EF";

        public IEnumerable<ReservationDto> Execute(BaseSearch request)
        {
            var query = Context.Reservations.Where(x => x.IsActive)
                .Include(x => x.User).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.User.FirstName.Contains(request.Keyword) || x.User.LastName.Contains(request.Keyword) || x.NameOnReservation.Contains(request.Keyword));
            }

            return query.Select(x => new ReservationDto
            {   
                id = x.Id,
                NameOfReservation = x.NameOnReservation,
                TimeOfReservation = x.TimeOfReservation,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                UserEmail = x.User.Email,
                NumberOfPeople = x.NumberOfPeople
            }).ToList();
        }
    }
}
