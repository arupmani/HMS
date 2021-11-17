using HMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSDAL.Repository
{
    public interface IBookingRepository
    {
        int BookRoom(Booking booking);
        List<Booking> GetMyBookings(string userName);
    }
}
