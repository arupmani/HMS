using HMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMSDAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        HMSContext db;
        public RoomRepository(HMSContext _db)
        {
            db = _db;
        }

        public List<RoomType> GetRoomTypes()
        {
            if (db != null)
            {
                return db.RoomType.Where(w => w.IsActive == true)
                    .Select(c => new RoomType { Name = c.Name, Id = c.Id }).ToList();
            }
            return null;
        }
        public int AddRoom(Room room)
        {
            if (db != null)
            {
                db.Room.Add(room);
                db.SaveChanges();

                return room.Id;
            }

            return 0;
        }

        public List<RoomInfo> GetRooms()
        {
            List<RoomInfo> roomInfo = new List<RoomInfo>();

            if (db != null)
            {
                roomInfo = (from r in db.Room
                            join t in db.RoomType
                            on r.RoomTypeId equals t.Id
                            join b in db.Booking
                            on r.Id equals b.RoomId
                            select new RoomInfo
                            {
                                RoomNo = r.RoomNo,
                                BookedRoomType = r.RoomType.Name,
                                BookingStatus = ""

                            }).ToList();




            }
            return roomInfo;
        }
        public int GetRoomIdToBook(DateTime fromDate, DateTime toDate, int roomTypeId)
        {
            int returnRoomId = 0;
            List<int> bookedRoomIds = new List<int>();
            bookedRoomIds = getBookedRoomIds(fromDate, toDate);
            if (db != null)
            {
                if (bookedRoomIds.Count > 0)
                {
                    returnRoomId = db.Room.Where(r => !bookedRoomIds.Contains(r.Id) && r.RoomTypeId == roomTypeId).Select(x => x.Id).Take(1).FirstOrDefault();
                }
                else
                {
                    returnRoomId = db.Room.Where(w => w.RoomTypeId == roomTypeId).Select(r => r.Id).Take(1).FirstOrDefault();
                }
            }
            return returnRoomId;



        }
        private List<int> getBookedRoomIds(DateTime fromDate, DateTime toDate)
        {
            List<int> roomIds = new List<int>();
            if (db != null)
            {
                roomIds = db.Booking.Where(b => b.BookingFrom >= fromDate && b.BookingTo <= toDate).Select(s => s.RoomId).Distinct().ToList();
            }
            return roomIds;
        }


    }
}
