using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAssignment.Task.Task6;

namespace TDDAssignmentTests.Test.Task6
{
    [TestClass()]
    public class BookingSystemTests
    {
        [TestMethod()]
        public void BookTimeSlotTest()
        {
            //Arrange
            BookingSystem bookingSystem = new BookingSystem();
            DateTime startTime = new DateTime(2021, 1, 1, 10, 0, 0);
            DateTime endTime = new DateTime(2021, 1, 1, 11, 0, 0);
            //Act
            bool result = bookingSystem.BookTimeSlot(startTime, endTime);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void OverlappingBookTimeSlotTest()
        {
            //Arrange
            BookingSystem bookingSystem = new BookingSystem();
            DateTime startTime = new DateTime(2021, 1, 1, 10, 0, 0);
            DateTime endTime = new DateTime(2021, 1, 1, 11, 0, 0);
            DateTime startTime2 = new DateTime(2021, 1, 1, 10, 30, 0);
            DateTime endTime2 = new DateTime(2021, 1, 1, 11, 30, 0);
            bookingSystem.BookTimeSlot(startTime, endTime);
            bookingSystem.BookTimeSlot(startTime2, endTime2);
            //Act
            bool result = bookingSystem.BookTimeSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));
            bool result2 = bookingSystem.BookTimeSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void GetAvailableTimeSlotsTest()
        {
            // Arrange
            var bookingSystem = new BookingSystem();
            DateTime now = DateTime.Now;

            // Act
            var actualSlots = bookingSystem.GetAvailableTimeSlots();

            // Assert
            Assert.AreEqual(10, actualSlots.Count, "Antalet tillgängliga tidsluckor är inte korrekt.");

            for (int i = 0; i < actualSlots.Count; i++)
            {
                // Jämför bara timmar för att undvika precisionstimingproblem
                Assert.AreEqual(now.AddHours(i).ToString("yyyy-MM-dd HH"),
                                actualSlots[i].ToString("yyyy-MM-dd HH"),
                                $"Tidslucka på index {i} är inte korrekt.");
            }
        }
        [TestMethod()]
        public void StartTimeIsAfterEndTimeTest()
        {
            //Arrange
            BookingSystem bookingSystem = new BookingSystem();
            DateTime startTime = new DateTime(2021, 1, 1, 14, 0, 0);
            DateTime endTime = new DateTime(2021, 1, 1, 13, 0, 0);
            //Act
            bool result = bookingSystem.BookTimeSlot(startTime, endTime);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void BookServiceFacadeTestWithMockning()
        {
            //Arrange
            var mockBookingSystem = Substitute.For<IBookingSystem>(); // Mockar IBookingSystem
            var bookingServiceFacade = new BookingServiceFacade(mockBookingSystem);
            DateTime startTime = new DateTime(2021, 1, 1, 10, 0, 0);
            DateTime endTime = new DateTime(2021, 1, 1, 11, 0, 0);
            mockBookingSystem.BookTimeSlot(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(true);
            mockBookingSystem.GetAllBookings().Returns(new List<Booking>());
            //Act
            bool result = bookingServiceFacade.BookSlot(startTime, endTime);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void OverlapningBookingSystemWithMochTest()
        {
            var mockBookingSystem = Substitute.For<IBookingSystem>(); // Mockar IBookingSystem
            var bookingServiceFacade = new BookingServiceFacade(mockBookingSystem);
            DateTime startTime = new DateTime(2021, 1, 1, 10, 0, 0);
            DateTime endTime = new DateTime(2021, 1, 1, 11, 0, 0);
            DateTime startTime2 = new DateTime(2021, 1, 1, 10, 30, 0);
            DateTime endTime2 = new DateTime(2021, 1, 1, 11, 30, 0);
            mockBookingSystem.BookTimeSlot(startTime, endTime).Returns(true);
            mockBookingSystem.BookTimeSlot(startTime2, endTime2).Returns(true);
            mockBookingSystem.GetAllBookings().Returns(new List<Booking> { new Booking(startTime, endTime) });
            //Act
            bool result = bookingServiceFacade.BookSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));
            bool result2 = bookingServiceFacade.BookSlot(startTime.AddMinutes(30), endTime.AddMinutes(30));
            //Assert
            Assert.IsFalse(result);
        }
    }
}