using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Title
    {
        public Title()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}