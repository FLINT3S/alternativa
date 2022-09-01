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
            weatherProvider = new OpenWeatherMapProvider(apiKey, zip, country);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnWeatherStart()
        {
            Task.Run(WeatherUpdatingProcess);
            Task.Run(TimeUpdatingProcess);
        }

        private void WeatherUpdatingProcess()
        {
            while (true)
            {
                var weather = weatherProvider.GetWeather();
                if (IsWinter())
                    SetWinterWeather(weather);
                else
                    SetNotWinterWeather(weather);
            }
        }

        private static bool IsWinter() => DateTime.Now.Month < 3 || DateTime.Now.Month == 12;

        private void SetWinterWeather(GTANetworkAPI.Weather weather)
        {
            SetWeather(weather);
            Thread.Sleep((int)TimeSpan.FromMinutes(10).TotalMilliseconds);
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

        private void SetNotWinterWeather(GTANetworkAPI.Weather weather)
        {
            if (IsRaining(weather))
            {
                SetWeather(weather);
                Thread.Sleep((int)TimeSpan.FromMinutes(10).TotalMilliseconds);
                SetWeather(weatherProvider.GetNotRainyWeather());
                Thread.Sleep((int)TimeSpan.FromMinutes(10).TotalMilliseconds);
            }
            else
            {
                SetWeather(weather);
                Thread.Sleep((int)TimeSpan.FromMinutes(10).TotalMilliseconds);
            }
        }

        private static bool IsRaining(GTANetworkAPI.Weather weather) =>
            weather == GTANetworkAPI.Weather.RAIN ||
            weather == GTANetworkAPI.Weather.CLEARING ||
            weather == GTANetworkAPI.Weather.THUNDER;

        private static void TimeUpdatingProcess()
        {
            while (true)
            {
                void SetCurrentTime() => NAPI.World.SetTime(
                        DateTime.Now.Hour,
                        DateTime.Now.Minute,
                        DateTime.Now.Second
                    );

                NAPI.Task.Run(SetCurrentTime);
                Thread.Sleep(60_000);
            }
        }
    }
}