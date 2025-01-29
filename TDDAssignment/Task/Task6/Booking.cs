using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task6
{
    public class Booking
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public Booking(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
