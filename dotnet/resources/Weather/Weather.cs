using System;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using Microsoft.Extensions.Configuration;
using Weather.WeatherProviders;

namespace Weather
{
    public class Weather : AltAbstractResource
    {
        private readonly WeatherProvider weatherProvider;

        public Weather()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string apiKey = config.GetValue<string>("OpenWeatherApi");
            string country = config.GetValue<string>("OpenWeatherCountry");
            string zip = config.GetValue<string>("OpenWeatherZip");
            bool isWinter = config.GetValue<bool>("IsWinter");
            if (isWinter) 
                weatherProvider = new WinterWeatherProvider(apiKey, zip, country);
            else
                weatherProvider = new NotWinterWeatherProvider(apiKey, zip, country);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnWeatherStart() =>
            Task.Run(WeatherUpdatingProcess);

        private void WeatherUpdatingProcess()
        {
            while (true)
            {
                var weather = weatherProvider.GetWeather();
                SetWeather(weather);
                Thread.Sleep((int)TimeSpan.FromMinutes(10).TotalMilliseconds);
            }
        }

        private void SetWeather(GTANetworkAPI.Weather weather)
        {
            NAPI.Task.Run(
                    () =>
                    {
                        NAPI.World.SetWeather(weather);
                        NAPI.ClientEvent.TriggerClientEventForAll(WeatherEvents.SetWeatherToClient, weather.ToString());
                    }
                );
            AltLogger.Instance.LogResource(
                    new AltResourceEvent(this, ResourceEventType.Info, $"Set weather: {weather.ToString()}")
                );
        }
    }
}