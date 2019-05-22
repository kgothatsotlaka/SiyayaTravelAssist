using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class VehicleColorConfiguration: EntityTypeConfiguration<VehicleColor>
    {
        public VehicleColorConfiguration()
        {
            HasMany(c => c.Vehicles)
                .WithRequired(h => h.VehicleColor)
                .HasForeignKey(c => c.VehicleColorId)
                .WillCascadeOnDelete(false);
        }
    }
}