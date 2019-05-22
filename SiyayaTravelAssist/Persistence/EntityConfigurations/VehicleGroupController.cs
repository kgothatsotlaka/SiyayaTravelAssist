using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class VehicleGroupController: EntityTypeConfiguration<VehicleGroup>
    {
        public VehicleGroupController()
        {
            HasMany(c => c.Vehicles)
                .WithRequired(h => h.VehicleGroup)
                .HasForeignKey(c => c.VehicleGroup)
                .WillCascadeOnDelete(false);
        }
    }
}