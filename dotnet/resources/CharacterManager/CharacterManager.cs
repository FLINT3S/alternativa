using System;
using System.Linq;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace CharacterManager
{
    public class CharacterManager : AltAbstractResource
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
            var character = AltContext.GetCharacter(player, Guid.Parse(rawGuid));
            player.SetCharacter(character);
        }

        #region OnRemoteEvent

        [RemoteEvent(CharacterManagerEvent.SelectCharacter)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            try
            {
                var character = AltContext.GetCharacter(player, Guid.Parse(rawGuid));
                player.SetCharacter(character);
                NAPI.Task.Run(() => NAPI.Player.SpawnPlayer(player, character.LastPosition ?? Vector3.RandomXy()));
                if (character.IsDead)
                    NAPI.Task.Run(() => player.Health = 0);
                ClientConnect.Trigger(player, "OnCharacterSpawned", character.IsDead);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        #endregion
    }
}
