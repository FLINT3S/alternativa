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
        [RemoteEvent(CharacterManagerEvents.InitCharacterCreationFromClient)]
        public void InitCharacterCreation(Player player)
        {
            player.Position = new Vector3(-754.459, 318.391, 175.401);
            player.Rotation = new Vector3(-1.7809, 0, -137.35375);
            player.TriggerEvent(CharacterManagerEvents.CharacterCreationStart);
        }


        [Command("createcharacter")]
        public void OnCreateCharacter(Player player)
        {
            var account = player.GetAccountFromDb()!;
            var character = new Character(account, "Vasya", "Pupkin", DateTime.Now);
            account.AddCharacter(character);
        }

        [Command("selectcharacter", GreedyArg = true)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            var account = player.GetAccountFromDb()!;
            var character = account.Characters.FirstOrDefault(c => c.Id == Guid.Parse(rawGuid));
            account.PeekCharacter(character);
            LocalContext.EntityLists.OnlinePlayers.Add(account);
        }
    }
}
