using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class BookingConfiguration: EntityTypeConfiguration<Booking>
    {
        /**
         *  HasMany(c => c.Hospitals)
                .WithRequired(h => h.City)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);
         */

        /**
         *   HasRequired(h => h.City)
                .WithMany(c => c.Hospitals)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);
         */
        public BookingConfiguration()
        {
            //Like C
            HasMany(b =>b.BookingTrips)
                 .WithRequired(b => b.Booking)
                 .HasForeignKey(b => b.BookingId)
                 .WillCascadeOnDelete(false);


            //One Client- Many Bookings (Booking is like H)
            HasRequired(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(c => c.ClientId)
                .WillCascadeOnDelete(false);

            //One BookingType - Many Bookings (Booking is like H)
            HasRequired(b => b.BookingType)
                .WithMany(c => c.Bookings)
                .HasForeignKey(c => c.BookingTypeId)
                .WillCascadeOnDelete(false);

            //Quote
            HasOptional(b => b.Quote)
                .WithRequired(p => p.Booking);
        }

    }
}