namespace Weather.WeatherProviders
{
    internal class WinterWeatherProvider : OpenWeatherMapProvider
    {
        public WinterWeatherProvider(string apiKey, string zip, string country) : base(apiKey, zip, country)
        {
        }

        protected override GTANetworkAPI.Weather ConvertToGtaWeather(int weatherId) =>
            throw new System.NotImplementedException();
    }
}