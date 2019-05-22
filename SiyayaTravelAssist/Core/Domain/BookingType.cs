using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class BookingType
    {
        public BookingType()
        {
            Bookings = new HashSet<Booking>();
        }


        public int Id { get; set; }
        public string BookingTypeDescription { get; set; }

        public ICollection<Booking> Bookings { get; set; }


    }
}