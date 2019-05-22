using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    /// <summary>
    /// To Do: Title
    /// </summary>
    public class Employee
    {
        public Employee()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int IdentityNumber { get; set; }
        public int Telephone { get; set; }



        //Gender-Employee (1-M)
        public Gender Gender { get; set; }
        public int  GenderId { get; set; }

        //Client-Booking(1-M) (C-H) 
        public ICollection<Booking> Bookings { get; set; }

    }
}

