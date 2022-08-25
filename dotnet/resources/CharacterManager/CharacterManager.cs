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
            account.Characters.Add(character);
            account.UpdateInContext();
        }
        
        [Command("selectcharacter", GreedyArg = true)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            var account = player.GetAccountFromDb(a => a.Characters);
            var character = account!.Characters.FirstOrDefault(c => c.Id == Guid.Parse(rawGuid));
            account.OnCharacterPeek(character);
        }
    }
}
