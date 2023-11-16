using CoffeeShop.Application.UseCases.Commands.Reservations;
using CoffeeShop.Application.UseCases.DTO;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Implementation.UseCases.Commands.Reservations
{
    public class CreateReservationCommand : EfUseCase, ICreateReservationCommand
    {
        public CreateReservationCommand(Context context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Create reservation";

        public string Description => "Create reservation using EF";

        public void Execute(CreateReservationDto request)
        {
            var minutes = request.Minutes;
            var hours = request.Hours;
            var halfDay = request.HalfDay;
            var date = Convert.ToDateTime(request.Date);

            var timespan = new TimeSpan(hours, minutes, 00);
            date = date.Add(timespan);

            if (halfDay == "PM")
            {
                var timespan2 = new TimeSpan(12, 00, 00);
                date= date.Add(timespan2);
            }

            //date = date.Add(timespan);

            var reservation = new Reservation
            {
                NameOnReservation = request.NameOfReservation,
                TimeOfReservation = date,
                NumberOfPeople = request.NumberOfPeople,
                UserId = request.UserId
            };

            Context.Reservations.Add(reservation);
            Context.SaveChanges();
        }
    }
}
