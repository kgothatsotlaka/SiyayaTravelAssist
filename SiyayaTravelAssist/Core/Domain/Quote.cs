using System;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Quote
    {

        public int Id { get; set; }
        public DateTime DateCreated  { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

        //Zero Or One Quote - One Booking
        public Booking Booking { get; set; }

    }
}