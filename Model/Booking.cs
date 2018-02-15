using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Customer Kunde { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
