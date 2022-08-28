using System;
using System.Linq;
using System.Security.Cryptography;
using OpenWeatherMap.Standard;
using OpenWeatherMap.Standard.Enums;

namespace Weather.WeatherProviders
{
    internal class OpenWeatherMapProvider : WeatherProvider
    {
        private readonly string zip;

        private readonly string country;

        private readonly Current current;

        public OpenWeatherMapProvider(string apiKey, string zip, string country)
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

        private static GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId) => weatherId switch
        {
            1 => GTANetworkAPI.Weather.EXTRASUNNY,
            2 => GTANetworkAPI.Weather.CLEAR,
            3 => GTANetworkAPI.Weather.OVERCAST,
            4 => GTANetworkAPI.Weather.CLOUDS,
            9 => GTANetworkAPI.Weather.RAIN,
            10 => GTANetworkAPI.Weather.CLEARING,
            11 => GTANetworkAPI.Weather.THUNDER,
            13 => GTANetworkAPI.Weather.SNOW,
            50 => GTANetworkAPI.Weather.FOGGY,
            _ => GTANetworkAPI.Weather.NEUTRAL
        };
    }
}