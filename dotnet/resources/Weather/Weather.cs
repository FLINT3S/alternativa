using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using Microsoft.Extensions.Configuration;
using Weather.WeatherProviders;

namespace Weather
{
    public class Main : AltAbstractResource
    {
        private readonly WeatherProvider weatherProvider;

        public Main()
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
                if (!IsWinter() && IsRaining(weather))
                {
                    SetWeather(weather);
                    Thread.Sleep(600_000);
                    SetWeather(weatherProvider.GetNotRainyWeather());
                    Thread.Sleep(180_000);
                }
                else if (!IsWinter() && !IsRaining(weather))
                {
                    SetWeather(weather);
                    Thread.Sleep(3600_000);
                }
                else
                {
                    SetWeather(weatherProvider.GetWinterWeather());
                    Thread.Sleep(3600_000);
                }
            }
        }

        private static bool IsWinter() => DateTime.Now.Month < 3 || DateTime.Now.Month == 12;

        private static bool IsRaining(GTANetworkAPI.Weather weather) =>
            weather == GTANetworkAPI.Weather.RAIN || 
            weather == GTANetworkAPI.Weather.CLEARING || 
            weather == GTANetworkAPI.Weather.THUNDER;

        private static void SetWeather(GTANetworkAPI.Weather weather)
        {
            NAPI.Task.Run(() => NAPI.World.SetWeather(weather));
            NAPI.Task.Run(() => 
                NAPI.ClientEvent.TriggerClientEventForAll(WeatherEvents.SetWeatherToClient, weather.ToString()));
        }

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
