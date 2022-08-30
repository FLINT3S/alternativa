using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using LocalContext;

namespace TimeCounter
{
    public class TimeCounter : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            Task.Run(CommonTimeCounter);
            Task.Run(DeathTimeCounter);
        }

        #region Common Counter
        
        private static void CommonTimeCounter()
        {
            while (true)
            {
                Task.Run(IncreaseGameTime);
                Thread.Sleep(60_000);
            }
        }

        private static void IncreaseGameTime()
        {
            IQueryable<Account> players = EntityLists.OnlinePlayers.AsQueryable();
            IQueryable<Character> characters = players.Select(account => account.ActiveCharacter);
            IQueryable<Character> onlineCharacters = characters.Where(character => character != null);
            foreach (var character in onlineCharacters)
                character.IncreaseInGameTime(TimeSpan.FromMinutes(1));
        }

        #endregion

        #region Time to Reborn Counter
        
        private static void DeathTimeCounter()
        {
            while (true)
            {
                Task.Run(DecreaseTimeToReborn);
                Thread.Sleep(1_000);
            }
        }

        private static void DecreaseTimeToReborn()
        {
            IQueryable<Account> players = EntityLists.OnlinePlayers.AsQueryable();
            IQueryable<Character> characters = players.Select(account => account.ActiveCharacter);
            IQueryable<Character> onlineCharacters = characters.Where(character => character != null);
            IQueryable<Character> deadCharacters = onlineCharacters.Where(character => character.IsDead);
            foreach (var deadCharacter in deadCharacters)
                deadCharacter.DecreaseTimeToReborn(TimeSpan.FromSeconds(1));
        }

        #endregion
    }
}
