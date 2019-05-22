using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class LicenseTypeConfiguration: EntityTypeConfiguration<LicenseType>
    {
        public LicenseTypeConfiguration()
        {
            HasMany(c => c.Drivers)
                .WithRequired(h => h.LicenseType)
                .HasForeignKey(c => c.LicenseTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}