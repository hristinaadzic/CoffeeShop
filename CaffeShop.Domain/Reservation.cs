using System;

namespace CoffeeShop.Domain
{
    public class Reservation : Entity
    {
        public string NameOnReservation { get; set; }
        public DateTime TimeOfReservation { get; set; }
        public int NumberOfPeople { get; set; }
        public int MyProperty { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
