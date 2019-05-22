using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Passenger
    {
        public Passenger()
        {
            Trips = new HashSet<Trip>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }

        //Trip - Passenger (M - 1) (C- H)
        public ICollection<Trip> Trips { get; set; }



    }
}