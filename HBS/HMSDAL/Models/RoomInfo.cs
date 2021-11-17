using System;
using System.Collections.Generic;
using System.Text;

namespace HMSDAL.Models
{
    public class RoomInfo : Room
    {
        public string BookingStatus { get; set; }
        public string BookedRoomType { get; set; }
    }
}
