using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class BookingTripConfiguration: EntityTypeConfiguration<BookingTrip>
    {
        public BookingTripConfiguration()
        {
            /**
             * //One Client- Many Bookings (Booking is like H)
            HasRequired(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(c => c.ClientId)
                .WillCascadeOnDelete(false);
             */

            HasRequired(b => b.Booking)
                .WithMany(c => c.BookingTrips)
                .HasForeignKey(c => c.BookingId)
                .WillCascadeOnDelete(false);

            //BookingTrip - Driver (Entity is Like H)
            HasRequired(b => b.Driver)
                .WithMany(c => c.BookingTrips)
                .HasForeignKey(c => c.DriverId)
                .WillCascadeOnDelete(false);

            //BookingTrip - Vehicle (Entity is Like H)
            HasRequired(b => b.Vehicle)
                .WithMany(c => c.BookingTrips)
                .HasForeignKey(c => c.VehicleId)
                .WillCascadeOnDelete(false);

            HasOptional(b => b.Trip)
                .WithRequired(p => p.BookingTrip);
        }
    }
}