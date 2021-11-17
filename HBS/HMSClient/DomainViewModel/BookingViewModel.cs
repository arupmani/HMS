using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMSClient.DomainViewModel
{
    public class BookingViewModel
    {
        [Required]
        public DateTime BookingFrom { get; set; }
        [Required]
        public DateTime BookingTo { get; set; }
        [Required]
        public int RoomTypeId { get; set; }

        public string  RoomType { get; set; }

        public DateTime BookingDate { get; set; }
        public string RoomNo { get; set; }
    }
}
