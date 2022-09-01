using System;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace CharacterManager
{
    public class CharacterManager : AltAbstractResource
    {
        [RemoteEvent(CharacterManagerEvents.InitCharacterCreationFromClient)]
        public void InitCharacterCreation(Player player)
        {
            player.Position = new Vector3(-754.459, 318.391, 175.401);
            player.Rotation = new Vector3(-1.7809, 0, -137.35375);
            player.TriggerEvent(CharacterManagerEvents.CharacterCreationStart);
        }

        [RemoteEvent(CharacterManagerEvents.ChangeGenderFromCef)]
        public void ChangeGender(Player player, int gender)
        {
            if (gender == 0)
            {
                NAPI.Entity.SetEntityModel(player.Handle, NAPI.Util.GetHashKey("mp_m_freemode_01"));
            }
            else
            {
                NAPI.Entity.SetEntityModel(player.Handle, NAPI.Util.GetHashKey("mp_f_freemode_01"));
            }
        }


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