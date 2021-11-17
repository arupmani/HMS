using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMSClient.Models1
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int? RoomTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
