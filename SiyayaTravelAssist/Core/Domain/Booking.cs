﻿using System;
using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Booking
    {
        
        public int Id { get; set; }
        public string Status { get; set; }
        public string ClientReference { get; set; } // Id or Registration Number
        public DateTime DateCreated { get; set; }
        public string BookingReference { get; set; } //For Enquirers From Client , auto-generated by system
        public string BookingOrder { get; set; } // We receive this one from them, it is their reference given to us

        //One Client- Many Bookings
        public virtual Client Client { get; set; }
        public Client ClientId { get; set; }  

        //One Employee - Many Bookings
        public virtual Employee Employee { get; set; }
        public Employee EmployeeId { get; set; }

        //Zero Or One Quote - One Booking
        public Quote Quote { get; set; }


        //One Booking - Many BookingTrips
        public ICollection<BookingTrip> Type { get; set; }


        //One BookingType - Many Bookings
        public  virtual BookingTrip BookingTrip { get; set; }
        public BookingTrip BookingTripId { get; set; }
      

     
    }
}