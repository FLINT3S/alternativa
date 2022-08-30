using System;
using System.Linq;
using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace CharacterManager
{
    public class Main : AltAbstractResource
    {
        [Command("createcharacter")]
        public void OnCreateCharacter(Player player)
        {
            var account = player.GetAccountFromDb()!;
            var character = new Character(account, "Vasya", "Pupkin", DateTime.Now);
            account.AddCharacter(character);
        }
        
        [Command("selectcharacter", GreedyArg = true)]
        public void OnSelectCharacterCommand(Player player, string rawGuid)
        {
            var account = player.GetAccountFromDb()!;
            var character = account.Characters.FirstOrDefault(c => c.Id == Guid.Parse(rawGuid));
            account.PeekCharacter(character);
        }

        #region OnRemoteEvent

        [RemoteEvent(CharacterManagerEvent.SelectCharacter)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            var account = player.GetAccountFromDb()!;
            var character = account.Characters.FirstOrDefault(c => c.Id == Guid.Parse(rawGuid));
            account.PeekCharacter(character);
            NAPI.Player.SpawnPlayer(player, Vector3.RandomXy());
        }

        #endregion
    }
}
