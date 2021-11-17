using HMSWeb.Models;
using HMSWeb.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.Repository
{
    public class RoomRepository : IRoomRepository
    {
        HMSContext db;
        public RoomRepository(HMSContext _db)
        {
            db = _db;
        }

        public List<RoomTypeModel> GetRoomTypes()
        {
            if (db != null)
            {
                return db.RoomType
                    .Select(c => new RoomTypeModel { Name = c.Name, Id = c.Id }).ToList();
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

        public List<RoomModel> GetRooms()
        {
            if (db != null)
            {
                return db.Room
                    .Select(c => new RoomModel { Id = c.Id, RoomNo = c.RoomNo, RoomTypeId = c.RoomTypeId }).ToList();
            }
            return null;
        }

    
    }
}
