using HMSClient.DomainViewModel;
using HMSDAL.Models;
using HMSDAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HMSClient.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        IRoomRepository roomRepository;
        IBookingRepository bookingRepository;

        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, IRoomRepository _roomRepository, IBookingRepository _bookingRepository)
        {
            _logger = logger;
            roomRepository = _roomRepository;
            bookingRepository = _bookingRepository;
        }

        public IActionResult Index()
        {
            var roomTypes = roomRepository.GetRoomTypes();
            var selectList = new List<SelectListItem>();
            foreach (var room in roomTypes)
            {
                selectList.Add(new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.Name
                });
            }
                ViewData["RoomTypes"] = selectList;

            
            return View();

        }

        [HttpPost]
        public IActionResult PostBookRoom(BookingViewModel model )
        {
            string strContactAdministratorMsg = "Error in room booking. Please contact administrator";
            if (ModelState.IsValid)
            {
                var roomIdToBook = roomRepository.GetRoomIdToBook(model.BookingFrom, model.BookingTo, model.RoomTypeId);

                if (roomIdToBook > 0)
                {
                    var ret = bookingRepository.BookRoom(new Booking { BookingFrom = model.BookingFrom, BookingTo = model.BookingTo, RoomId = roomIdToBook, BookedBy = User.Identity.Name });
                    if (ret > 0)
                    {
                        TempData["RoomBookedSuccessMessage"] = "<p>Room is booked! Room Id Is : </p>" + roomIdToBook;
                        return RedirectToAction("MyBooking");
                    }
                    else
                    {
                        TempData["RoomBookedFailureMessage"] = strContactAdministratorMsg;
                        return RedirectToAction("Index");
                    }

                }
                TempData["RoomBookedFailureMessage"] = strContactAdministratorMsg;
                return RedirectToAction("Index");
            }
            TempData["RoomBookedFailureMessage"] = "Please enter mandatory fields" ;
            return RedirectToAction("Index");


        }
        public IActionResult MyBooking()
        {
            var result = bookingRepository.GetMyBookings(User.Identity.Name);
          
            List<BookingViewModel> model = new List<BookingViewModel>();
            model = result.Select(a => new BookingViewModel { BookingDate = a.CreatedDate, RoomNo = a.Room.RoomNo,RoomType=a.Room.RoomType.Name }).ToList();
            return View(model);
        }

      
    }
}
