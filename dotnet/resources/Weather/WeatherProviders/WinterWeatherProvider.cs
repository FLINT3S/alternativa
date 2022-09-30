namespace Weather.WeatherProviders
{
    internal class WinterWeatherProvider : OpenWeatherMapProvider
    {
        public WinterWeatherProvider(string apiKey, string zip, string country) : base(apiKey, zip, country)
        {
        }

        protected override GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId) => weatherId switch
        {
            1 => GTANetworkAPI.Weather.SNOWLIGHT,
            2 => GTANetworkAPI.Weather.SNOWLIGHT,
            3 => GTANetworkAPI.Weather.SNOWLIGHT,
            4 => GTANetworkAPI.Weather.SNOW,
            9 => GTANetworkAPI.Weather.BLIZZARD,
            10 => GTANetworkAPI.Weather.BLIZZARD,
            11 => GTANetworkAPI.Weather.BLIZZARD,
            13 => GTANetworkAPI.Weather.SNOW,
            50 => GTANetworkAPI.Weather.SNOWLIGHT,
            _ => GTANetworkAPI.Weather.SNOWLIGHT
        };
    }
}