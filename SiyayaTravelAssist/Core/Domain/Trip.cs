using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Trip
    {
       
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }
        public Location DropOffLocationId { get; set; }
        public Location PickUpLocationId { get; set; }
        public string PickUpInstructions { get; set; }


        public Passenger PassengerId { get; set; }
        public Booking BookingId { get; set; } // Prefer to use Booking Reference Attribute
        public Vehicle VehicleId { get; set; }
        public Driver DriverId { get; set; }


    }
}