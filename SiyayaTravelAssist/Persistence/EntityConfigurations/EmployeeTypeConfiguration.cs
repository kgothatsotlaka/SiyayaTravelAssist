using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class EmployeeTypeConfiguration: EntityTypeConfiguration<EmployeeType>
    {
        public EmployeeTypeConfiguration()
        {
            HasMany(c => c.Employees)
                .WithRequired(h => h.EmployeeType)
                .HasForeignKey(c => c.EmployeeTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}