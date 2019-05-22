using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class ClientConfiguration: EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {

            HasMany(c => c.Bookings)
                .WithRequired(h => h.Client)
                .HasForeignKey(c => c.ClientId)
                .WillCascadeOnDelete(false);
        }
    }
}