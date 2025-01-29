using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task6
{
    public class BookingSystem : IBookingSystem
    {
        public List<Booking> Bookings { get; private set; } = new List<Booking>();

        public bool BookTimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
            {
                return false; // Returnera false om starttiden är efter sluttiden
            }

            // Logik för att kontrollera om tidsintervallet redan är bokat
            foreach (var booking in Bookings)
            {
                if (startTime < booking.EndTime && endTime > booking.StartTime)
                {
                    return false; // Överlappar en befintlig bokning
                }
            }

            // Om inga överlappningar, boka tidsintervallet
            Bookings.Add(new Booking(startTime, endTime));
            return true;
        }

        public List<DateTime> GetAvailableTimeSlots()
        {
            // Här kan vi till exempel skapa en lista med tillgängliga tider
            List<DateTime> availableSlots = new List<DateTime>();
            DateTime start = DateTime.Now;
            for (int i = 0; i < 10; i++) // Exempel, de första 10 tillgängliga tiderna
            {
                availableSlots.Add(start.AddHours(i));
            }
            return availableSlots;
        }
        public List<Booking> GetAllBookings()
        {
            return Bookings;
        }


    }
}
