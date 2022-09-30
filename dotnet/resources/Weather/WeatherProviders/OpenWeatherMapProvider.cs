using System.Linq;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Enums;

namespace Weather.WeatherProviders
{
    internal abstract class OpenWeatherMapProvider : WeatherProvider
    {
        protected readonly string country;

        protected readonly Current current;

        protected readonly string zip;

        protected OpenWeatherMapProvider(string apiKey, string zip, string country)
        {
            this.country = country;
            this.zip = zip;
            current = new Current(apiKey, WeatherUnits.Metric);
        }

        public override GTANetworkAPI.Weather GetWeather()
        {
            var forecast = current.GetWeatherDataByZip(zip, country).Result;
            int weatherId = int.Parse(forecast.Weathers.First().Icon[..^1]);
            return ConvertToGtaWeather(weatherId);
        }

        protected abstract GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId);
    }
}