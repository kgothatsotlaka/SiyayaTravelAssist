using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Trip
    {
       
        public int Id { get; set; }
        public DateTime PickUpTime { get; set; } //given by client
        public DateTime PickUpDate { get; set; } //given by client
        public DateTime EstimatedDropOffTime { get; set; } //calculated by system
       
        

        //Trip and Location (P B)
        public Location PickupLocation { get; set; }
        public Location DropOffLocation { get; set; }

        //Trip and BookingTrip(P B)
        public BookingTrip BookingTrip { get; set; }

        //Trip-Passenger ( H-C)
        public virtual Passenger Passenger { get; set; }
        public int PassengerId { get; set; }

        //LocationType- Location (1-M) (C - H)
        public virtual LocationType LocationType { get; set; }
        public int LocationTypeId { get; set; }


    }
}