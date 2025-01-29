using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDAssignment.Task.Task3;

namespace TDDAssignmentTests.Test.Task3
{
    [TestClass()]
    public class WeatherClientTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task GetWeatherShouldReturnWeatherForValidCity()
        {
            // Arrange
            var weatherServiceFacade = Substitute.For<IWeatherServiceFacade>();
            string city = "London";
            string expected = "Sunny";

            weatherServiceFacade.GetWeather(city).Returns(System.Threading.Tasks.Task.FromResult(expected));
            var weatherClient = new WeatherClient(weatherServiceFacade);

            // Act
            var actual = await weatherClient.GetWeather(city);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public async System.Threading.Tasks.Task GetWeatherWhenInternetGoesDownShouldReturnNull()
        {
            // Arrange
            var weatherServiceFacade = Substitute.For<IWeatherServiceFacade>();
            string city = "London";
            string expected = null;

            weatherServiceFacade.GetWeather(city).Returns(System.Threading.Tasks.Task.FromResult(expected));
            var weatherClient = new WeatherClient(weatherServiceFacade);

            // Act
            var actual = await weatherClient.GetWeather(city);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public async System.Threading.Tasks.Task GetWeatherShouldThrowArgumentNullExceptionForNullCity()
        {
            // Arrange
            var weatherServiceFacade = Substitute.For<IWeatherServiceFacade>();
            string city = null;
            var weatherClient = new WeatherClient(weatherServiceFacade);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => weatherClient.GetWeather(city));
        }
    }
}