using System;
using System.Linq;
using AbstractResource;
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
            var account = player.GetAccountFromDb()!;
            var character = account.Characters.FirstOrDefault(c => c.Id == Guid.Parse(rawGuid));
            account.PeekCharacter(character);
        }

        #region OnRemoteEvent

        [RemoteEvent(CharacterManagerEvent.SelectCharacter)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            try
            {
                var account = player.GetAccountFromDb()!;
                var character = account.Characters.First(c => c.Id == Guid.Parse(rawGuid));
                account.PeekCharacter(character);
                NAPI.Task.Run(() => NAPI.Player.SpawnPlayer(player, character.LastPosition ?? Vector3.RandomXy()));
                if (character.IsDead)
                    NAPI.Task.Run(() => player.Health = 0);
                ClientConnect.Trigger(player, "OnCharacterSpawned", character.IsDead);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(rawGuid);
                Console.WriteLine(ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(rawGuid);
                Console.WriteLine(ex);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(rawGuid);
                Console.WriteLine(ex);
            }
        }

        #endregion
    }
}
