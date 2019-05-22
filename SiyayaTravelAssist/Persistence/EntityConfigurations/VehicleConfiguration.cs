using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class VehicleConfiguration: EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            //Vehicle - VehicleColor (H-C)
            HasRequired(h => h.VehicleColor)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(c => c.VehicleColorId)
                .WillCascadeOnDelete(false);

            //Vehicle - VehicleGroup (H-C)
            HasRequired(h => h.VehicleGroup)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(c => c.VehicleGroupId)
                .WillCascadeOnDelete(false);
            //Vehicle - BrandType (H-C)
            HasRequired(h => h.VehicleBrandType)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(c => c.VehicleBrandTypeId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.BookingTrips)
                .WithRequired(h => h.Vehicle)
                .HasForeignKey(c => c.VehicleId)
                .WillCascadeOnDelete(false);
        }
    }
}