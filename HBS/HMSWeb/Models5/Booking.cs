using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMSWeb.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string BookingRefNo { get; set; }
        public int RoomId { get; set; }
        public DateTime? BookingFrom { get; set; }
        public DateTime? BookingTo { get; set; }
        public int? BookingStatusId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Room Room { get; set; }
    }
}
