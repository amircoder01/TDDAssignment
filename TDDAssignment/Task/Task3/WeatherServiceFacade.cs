using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task3
{
    public class WeatherServiceFacade : IWeatherServiceFacade
    {
        public async Task<string> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            // Simulerad logik för att hämta vädret
            return await System.Threading.Tasks.Task.FromResult("Sunny");
        }
    }
}
