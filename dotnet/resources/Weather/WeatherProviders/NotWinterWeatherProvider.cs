using System.Linq;

namespace Weather.WeatherProviders
{
    internal class NotWinterWeatherProvider : OpenWeatherMapProvider
    {
        private GTANetworkAPI.Weather lastWeather; 
        
        public NotWinterWeatherProvider(string apiKey, string zip, string country) : base(apiKey, zip, country)
        {
        }

        public override GTANetworkAPI.Weather GetWeather()
        {
            var forecast = current.GetWeatherDataByZip(zip, country).Result;
            int weatherId = int.Parse(forecast.Weathers.First().Icon[..^1]);
            var weather = ConvertToGtaWeather(weatherId);
            lastWeather = IsRaining(lastWeather) ? GetNotRainyWeather() : weather;
            return lastWeather;
        }

        private static bool IsRaining(GTANetworkAPI.Weather weather) =>
            weather == GTANetworkAPI.Weather.RAIN ||
            weather == GTANetworkAPI.Weather.CLEARING ||
            weather == GTANetworkAPI.Weather.THUNDER;

        protected override GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId) => weatherId switch
        {
            1 => GTANetworkAPI.Weather.EXTRASUNNY,
            2 => GTANetworkAPI.Weather.CLEAR,
            3 => GTANetworkAPI.Weather.OVERCAST,
            4 => GTANetworkAPI.Weather.CLOUDS,
            9 => GTANetworkAPI.Weather.RAIN,
            10 => GTANetworkAPI.Weather.CLEARING,
            11 => GTANetworkAPI.Weather.THUNDER,
            13 => GTANetworkAPI.Weather.RAIN,
            50 => GTANetworkAPI.Weather.FOGGY,
            _ => GTANetworkAPI.Weather.NEUTRAL
        };
    }
}