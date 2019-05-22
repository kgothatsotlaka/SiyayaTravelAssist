using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class TitleConfiguration: EntityTypeConfiguration<Title>
    {
        public TitleConfiguration()
        {
            HasMany(c => c.Employees)
                .WithRequired(h => h.Title)
                .HasForeignKey(c => c.TitleId)
                .WillCascadeOnDelete(false);
        
    }
    }
}