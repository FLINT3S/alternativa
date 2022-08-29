import {weatherEvents} from "./weatherEvents";

let currentWeather = null

mp.events.add(weatherEvents.SET_WEATHER_FROM_SERVER, (newWeather) => {
  if (currentWeather == null)
    mp.game.gameplay.setWeatherTypeNow(newWeather)
  else
    mp.game.gameplay.setWeatherTypeTransition(currentWeather, newWeather, 0.5)
  currentWeather = newWeather
})
