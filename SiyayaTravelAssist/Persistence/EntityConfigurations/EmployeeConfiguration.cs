using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class EmployeeConfiguration: EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            //EmployeeType-Employee (1-M))
            HasRequired(h => h.EmployeeType)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.EmployeeTypeId)
                .WillCascadeOnDelete(false);

            //Gender-Employee (1-M)
            HasRequired(h => h.Gender)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.GenderId)
                .WillCascadeOnDelete(false);

            //Title-Employee (1-M)
            HasRequired(h => h.Title)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.TitleId)
                .WillCascadeOnDelete(false);
            //Nationality-Employee (1-M)
            HasRequired(h => h.Nationality)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.NationalityId)
                .WillCascadeOnDelete(false);

        }
    }
}