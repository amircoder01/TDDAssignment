using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task6
{
    public interface IBookingSystem
    {
        bool BookTimeSlot(DateTime startTime, DateTime endTime);
        List<DateTime> GetAvailableTimeSlots();
        List<Booking> GetAllBookings();
    }
}
