using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class VehicleBrandTypeConfiguration: EntityTypeConfiguration<VehicleBrandType>
    {
        public VehicleBrandTypeConfiguration()
        {
            HasMany(c => c.Vehicles)
                .WithRequired(h => h.VehicleBrandType)
                .HasForeignKey(c => c.VehicleBrandTypeId)
                .WillCascadeOnDelete(false);

            HasRequired(h => h.VehicleModelType)
                .WithMany(c => c.VehicleBrandTypes)
                .HasForeignKey(c => c.VehicleModelTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}