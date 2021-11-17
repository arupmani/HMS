using HMSDAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSDAL.Repository
{
    public interface IRoomRepository
    {
        List<RoomType> GetRoomTypes();
        int AddRoom(Room room);
        List<RoomInfo> GetRooms();
        int GetRoomIdToBook(DateTime fromDate, DateTime toDate, int roomTypeId);
    }
}
