using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task3
{
    public interface IWeatherServiceFacade
    {
        Task<string> GetWeather(string city);
    }
}
