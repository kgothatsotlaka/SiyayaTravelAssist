using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Booking
    {
        public Booking()
        {
            Trips = new HashSet<Trip>();
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Trip> Trips { get; set; }
        public Client ClientId { get; set; }
     
    }
}