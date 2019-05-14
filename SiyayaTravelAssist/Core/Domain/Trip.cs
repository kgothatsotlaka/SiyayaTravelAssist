using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Trip
    {
        public Trip()
        {
            Passengers = new HashSet<Passenger>();
        }
        public int Id { get; set; }
        /*Add trip attributes
         *
         */
        public Booking BookingId { get; set; }
        public Client ClientId { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

    }
}