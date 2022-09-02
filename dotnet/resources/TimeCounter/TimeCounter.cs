using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database.Models;
using Database.Models.Economics.Banks;
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
        }

        #region Common Counter

        private static void CommonTimeCounter()
        {
            while (true)
            {
                Task.Run(IncreaseGameTime);
                Thread.Sleep((int)TimeSpan.FromMinutes(1).TotalMilliseconds);
            }
        }

        private static void IncreaseGameTime()
        {
            List<Character> onlineCharacters = NAPI.Pools.GetActiveCharacters().ToList();
            foreach (var character in onlineCharacters)
                character.IncreaseInGameTime(TimeSpan.FromMinutes(1));
        }

        #endregion

        #region Economics Counter

        private static void EconomicsCounter()
        {
            while (true)
            {
                Task.Run(RecalculateCredits);
                Thread.Sleep((int)TimeSpan.FromHours(1).TotalMilliseconds);
            }
        }

        private static void RecalculateCredits()
        {
            IEnumerable<BankAccount> accounts = Bank.GetAccounts();
            foreach (var account in accounts)
                account.Recalculate();
        }

        #endregion
    }
}