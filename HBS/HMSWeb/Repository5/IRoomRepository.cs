using HMSWeb.Models;
using HMSWeb.DomainViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.Repository
{
    public interface IRoomRepository
    {
        List<RoomTypeModel> GetRoomTypes();
        int AddRoom(Room room);
        List<RoomModel> GetRooms();
    }
}
