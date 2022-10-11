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

namespace Updater
{
    public class Updater : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnUpdaterStart()
        {
            Task.Run(TimeUpdatingProcess);
            Task.Run(CommonTimeCounter);
            Task.Run(EconomicsCounter);
            Task.Run(DimensionReleaseProcess);
        }

        #region Time Updating
        
        private static void TimeUpdatingProcess()
        {
            while (true)
            {
                NAPI.Task.Run(SetCurrentTime);
                Thread.Sleep(60_000);
            }
        }

        private static void SetCurrentTime() =>
            NAPI.World.SetTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        #endregion
        
        #region In Game Time Updating

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

        #region Bank Accounts Updating

        private static void EconomicsCounter()
        {
            while (true)
            {
                Task.Run(RecalculateAccounts);
                Thread.Sleep((int)TimeSpan.FromHours(1).TotalMilliseconds);
            }
        }

        private static void RecalculateAccounts()
        {
            IEnumerable<BankAccount> accounts = Bank.GetAccounts();
            foreach (var account in accounts)
                account.Recalculate();
        }

        #endregion

        #region Dimension Releasing
        
        private static void DimensionReleaseProcess()
        {
            while (true)
            {
                NAPI.Task.Run(DimensionProvider.DimensionManager.ReleaseUnusedDimensions);
                Thread.Sleep(TimeSpan.FromMinutes(1));
            }
        }

        #endregion
    }
}
