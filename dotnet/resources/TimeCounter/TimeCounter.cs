using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

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
            IQueryable<Player> players = NAPI.Pools.GetAllPlayers().AsQueryable();
            IQueryable<Account> accounts = players.Select(player => player.GetAccount()).Where(account => account != null);
            IQueryable<Character> characters = accounts.Select(account => account.ActiveCharacter);
            IQueryable<Character> onlineCharacters = characters.Where(character => character != null);
            foreach (var character in onlineCharacters)
                character.InGameTime += TimeSpan.FromMinutes(1);

            lock (AltContext.Locker)
            {
                AltContext.Instance.UpdateRange(onlineCharacters);
                AltContext.Instance.SaveChanges();
            }
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
            IQueryable<Player> players = NAPI.Pools.GetAllPlayers().AsQueryable();
            IQueryable<Account> accounts = players.Select(player => player.GetAccount()).Where(account => account != null);
            IQueryable<Character> characters = accounts.Select(account => account.ActiveCharacter);
            IQueryable<Character> onlineCharacters = characters.Where(character => character != null);
            IQueryable<Character> deadCharacters = onlineCharacters.Where(character => character.IsDead);
            foreach (var deadCharacter in deadCharacters)
                deadCharacter.TimeToReborn -= TimeSpan.FromSeconds(1);

            lock (AltContext.Locker)
            {
                AltContext.Instance.UpdateRange(deadCharacters);
                AltContext.Instance.SaveChanges();
            }
        }

        #endregion
    }
}
