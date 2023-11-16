using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Application.UseCases.DTO
{
    public class CreateReservationDto : Dto
    {
        public string NameOfReservation { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string HalfDay { get; set; }
        public int NumberOfPeople { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
    }
    //Wed Sep 27 2023

    public class ReservationDto : Dto
    {
        public string NameOfReservation { get; set; }
        public DateTime TimeOfReservation { get; set; }
        public int NumberOfPeople { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
