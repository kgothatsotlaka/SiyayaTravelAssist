using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class NationaliityConfiguration: EntityTypeConfiguration<Nationality>
    {
        public NationaliityConfiguration()
        {
            HasMany(c => c.Employees)
                .WithRequired(h => h.Nationality)
                .HasForeignKey(c => c.NationalityId)
                .WillCascadeOnDelete(false);
        }
    }
}