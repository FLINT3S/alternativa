using GTANetworkAPI;

namespace Logger.EventModels
{
    public class AltPlayerEvent : AltAbstractEvent
    {
        /// <summary>
        ///     Событие игрока, при подключении нового игрока используйте перегрузку <see cref="AltPlayerEvent(object, string, string)" />
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <param name="module">Модуль</param>
        /// <param name="eventName">Событие</param>
        /// <param name="eventDescription">Описание</param>
        public AltPlayerEvent(Player player, object module, string eventName, string eventDescription) : base(
                $"logs/players/{player.SocialClubName}_[{player.SocialClubId}.log",
                module,
                eventName,
                eventDescription
            )
        {
        }
        
        // 
        public AltPlayerEvent(object module, string eventName, string eventDescription) : base(
                $"logs/players/_newPlayers.log",
                module,
                eventName,
                eventDescription
            )
        {
        }
    }
}