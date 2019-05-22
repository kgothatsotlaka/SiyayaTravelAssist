using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class BookingTypeConfiguration: EntityTypeConfiguration<BookingType>
    {
        public BookingTypeConfiguration()
        {
            HasMany(b => b.Bookings)
                .WithRequired(b => b.BookingType)
                .HasForeignKey(b => b.BookingTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}