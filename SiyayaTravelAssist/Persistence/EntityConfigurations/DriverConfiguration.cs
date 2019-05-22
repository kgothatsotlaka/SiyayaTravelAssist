using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class DriverConfiguration : EntityTypeConfiguration<Driver>
    {
        public DriverConfiguration()
        {
            HasMany(c => c.BookingTrips)
                .WithRequired(h => h.Driver)
                .HasForeignKey(c => c.DriverId)
                .WillCascadeOnDelete(false);

            //Employee - Driver (1 -O OR 1) 
            HasOptional(b => b.Employee)
                .WithRequired(p => p.Driver);

            HasRequired(h => h.LicenseType)
                .WithMany(c => c.Drivers)
                .HasForeignKey(c => c.LicenseTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}