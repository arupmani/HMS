using HMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMSDAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        HMSContext db;
        public BookingRepository(HMSContext _db)
        {
            db = _db;
        }

        public int BookRoom(Booking booking)
        {
            if (db != null)
            {
                db.Booking.Add(booking);
                db.SaveChanges();

                return booking.Id;
            }

            return 0;
        }

        public List<Booking> GetMyBookings(string userName)
        {
            List<Booking> bookedRooms = new List<Booking>();
            if (db != null)
            {
                return db.Booking.Where(w => w.BookedBy == userName)
                    .Include(r => r.Room).Include(a => a.Room.RoomType).ToList();
                    
            }
            return bookedRooms;
        }
        //public List<Booking> GetMyBookings(string userName)
        //{
        //    List<Booking> bookedRooms = new List<Booking>();
        //    if (db != null)
        //    {
        //        bookedRooms = (from b in db.Booking
        //                       join r in db.Room
        //                       on b.RoomId equals r.Id
        //                       where r.IsActive == true && b.BookedBy == userName
        //                       select new Booking
        //                       {
        //                           BookingFrom = b.BookingFrom,
        //                           BookingTo = b.BookingTo,
        //                           RoomType = r.RoomType.Name,
        //                           BookingDate=b.CreatedDate,
        //                           RoomNo=r.RoomNo
        //                       }).ToList();
        //    }
        //    return bookedRooms;
        //}


    }
}
