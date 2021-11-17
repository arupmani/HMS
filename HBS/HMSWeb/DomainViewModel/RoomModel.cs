using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.DomainViewModel
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public int? RoomTypeId { get; set; }
    }
}
