using System.Security.Cryptography;

namespace Weather.WeatherProviders
{
    internal abstract class WeatherProvider
    {
        public virtual GTANetworkAPI.Weather GetWeather() => 
            GTANetworkAPI.Weather.EXTRASUNNY;
        
        public virtual GTANetworkAPI.Weather GetNotRainyWeather()
        {
            GTANetworkAPI.Weather[] weathersId = {
                GTANetworkAPI.Weather.EXTRASUNNY,
                GTANetworkAPI.Weather.CLEAR,
                GTANetworkAPI.Weather.CLOUDS,
                GTANetworkAPI.Weather.SMOG,
                GTANetworkAPI.Weather.FOGGY,
                GTANetworkAPI.Weather.OVERCAST,
                GTANetworkAPI.Weather.NEUTRAL,
            };
            return weathersId[RandomNumberGenerator.GetInt32(weathersId.Length)];
        }

        public virtual GTANetworkAPI.Weather GetWinterWeather()
        {
            GTANetworkAPI.Weather[] weathersId =
            {
                GTANetworkAPI.Weather.XMAS,
                GTANetworkAPI.Weather.SNOWLIGHT,
                GTANetworkAPI.Weather.SNOW,
                GTANetworkAPI.Weather.BLIZZARD,
            };
            return weathersId[RandomNumberGenerator.GetInt32(weathersId.Length)];
        }
    }
}