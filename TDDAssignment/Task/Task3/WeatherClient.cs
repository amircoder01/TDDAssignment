using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace TDDAssignment.Task.Task3
{
    public class WeatherClient
    {
        private readonly IWeatherServiceFacade _weatherServiceFacade;

        public WeatherClient(IWeatherServiceFacade weatherServiceFacade)
        {
            _weatherServiceFacade = weatherServiceFacade ?? throw new ArgumentNullException(nameof(weatherServiceFacade));
        }

        public async Task<string> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            return await _weatherServiceFacade.GetWeather(city);
        }
    }
}
