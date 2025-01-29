using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task6
{
    public class BookingServiceFacade
    {
        private readonly IBookingSystem _bookingSystem;

        public BookingServiceFacade(IBookingSystem bookingSystem)
        {
            _bookingSystem = bookingSystem;
        }

        public bool BookSlot(DateTime startTime, DateTime endTime)
        {
            if(startTime >= endTime)
            {
                return false;
            }
            foreach (var booking in _bookingSystem.GetAllBookings())
            {
                if (startTime < booking.EndTime && endTime > booking.StartTime)
                {
                    return false;
                }
            }
            return _bookingSystem.BookTimeSlot(startTime, endTime);

        }

        public List<DateTime> GetAvailableTimeSlots()
        {
            return _bookingSystem.GetAvailableTimeSlots();
        }
        public List<Booking> bookings4
        {
            get
            {
                return _bookingSystem.GetAllBookings();
            }
        }
    }
}
