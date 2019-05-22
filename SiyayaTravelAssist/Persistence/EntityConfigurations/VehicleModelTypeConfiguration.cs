using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class VehicleModelTypeConfiguration: EntityTypeConfiguration<VehicleModelType>
    {
        public VehicleModelTypeConfiguration()
        {
            HasMany(c => c.VehicleBrandTypes)
                .WithRequired(h => h.VehicleModelType)
                .HasForeignKey(c => c.VehicleModelTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}