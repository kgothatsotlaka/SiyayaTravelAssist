using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
           
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int Telephone { get; set; }


        //Client-Booking(1-M) (C-H) 
        public ICollection<Booking> Bookings { get; set; }
       

    }
}