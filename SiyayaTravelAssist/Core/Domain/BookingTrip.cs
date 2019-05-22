namespace SiyayaTravelAssist.Core.Domain
{
    public class BookingTrip
    {
        public int Id { get; set; }

        //One Booking - Many BookingTrips (BookingTrip is like H)
        public virtual Booking Booking { get; set; }
        public int BookingId { get; set; }

        //BookingTrip - Driver (Entity is Like H)
        public virtual Driver Driver { get; set; }
        public int DriverId { get; set; }

        //BookingTrip - Vehicle (Entity is Like H)
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        //BookingTrip - Trip (Entity is Like B)
        public Trip Trip { get; set; }
    }
}