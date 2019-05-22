using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Driver
    {
        public Driver()
        {
            BookingTrips = new HashSet<BookingTrip>();
        }

        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate {get; set; }
        public ICollection<BookingTrip> BookingTrips { get; set; }
        

        //Employee - Driver (1 -O OR 1) 
        public Employee Employee { get; set; }
       
        //LicenseType - Driver (1 - M) (H-C)
        public virtual LicenseType LicenseType { get; set; }
        public int LicenseTypeId { get; set; }
       
    }
}