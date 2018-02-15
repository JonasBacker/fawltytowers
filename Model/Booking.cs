using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Booking
    {
        public int BookingID { get; set; }
        public Customer Kunde { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
