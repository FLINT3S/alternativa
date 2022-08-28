namespace Weather.WeatherProviders
{
    internal abstract class WeatherProvider
    {
        public virtual GTANetworkAPI.Weather GetWeather() => 
            GTANetworkAPI.Weather.EXTRASUNNY;
    }
}