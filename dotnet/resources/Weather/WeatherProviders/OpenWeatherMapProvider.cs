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
            int weatherId = forecast.Weathers.First().Id;
            return ConvertToGtaWeather(weatherId);
        }

        private static GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId)
        {
            switch (weatherId / 10)
            {
                case 20:
                case 21: 
                case 22:
                case 23:
                    return GTANetworkAPI.Weather.THUNDER;
                
                case 30:
                case 31:
                case 32:
                case 52:
                case 53:
                    return GTANetworkAPI.Weather.RAIN;
                
                case 50:
                    return GTANetworkAPI.Weather.CLEARING;
                
                case 51:
                case 60:
                    return GTANetworkAPI.Weather.SNOWLIGHT;
                
                case 61:
                    return GTANetworkAPI.Weather.SNOW;
                case 62:
                    return GTANetworkAPI.Weather.BLIZZARD;
                
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                    return GTANetworkAPI.Weather.SMOG;
                case 75:
                case 76:
                case 77:
                case 78:
                    return GTANetworkAPI.Weather.FOGGY;
                
                case 80:
                    return (GTANetworkAPI.Weather)RandomNumberGenerator.GetInt32(0, 12);
                
                default:
                    return GTANetworkAPI.Weather.EXTRASUNNY;
            }
        }
    }
}