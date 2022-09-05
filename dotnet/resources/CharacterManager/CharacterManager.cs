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
            player.PlayAnimation("misshair_shop@barbers", "idle_a_cam", 1);
            player.TriggerEvent(CharacterManagerEvents.CharacterCreationStart);
        }

        [RemoteEvent(CharacterManagerEvents.ChangeGenderFromCef)]
        public void ChangeGender(Player player, int gender)
        {
            NAPI.Entity.SetEntityModel(player.Handle, NAPI.Util.GetHashKey((Sex)gender == Sex.Male ? "mp_m_freemode_01" : "mp_f_freemode_01"));
            CefConnect.TriggerRaw(player, CharacterManagerEvents.ChangeGenderFromCef + "Answered");
            ClientConnect.Trigger(player, "GenderChanged", gender);
        }

        [RemoteEvent(CharacterManagerEvents.CharacterCreatedSubmitFromClient)]
        public void CharacterCreated(Player player, string characterDto)
        {
            var characterCreatorInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterCreatorDto>(characterDto);
            var account = player.GetAccountFromDb()!;
            var character = new Character(account, characterCreatorInfo);
            account.AddCharacter(character);
            player.SetCharacter(character);
            // TODO: Вынести в константы или вообще в БД (но точку спавна наверное в константы все-таки)
            player.Position = new Vector3(-1041.3, -2744.6, 21.36);
            ClientConnect.Trigger(player, "CharacterCreated");
        }

        [Command("createcharacter")]
        public void OnCreateCharacter(Player player)
        {
            var account = player.GetAccountFromDb()!;
            var character = new Character(account, "Vasya", "Pupkin", Sex.Male, DateTime.Now);
            account.AddCharacter(character);
        }

        #region OnRemoteEvent

        [RemoteEvent(CharacterManagerEvent.SelectCharacter)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            try
            {
                var character = AltContext.GetCharacter(player, Guid.Parse(rawGuid));
                player.SetCharacter(character);
                ClientConnect.Trigger(player, "ApplyCharacter", character.Appearance.ToJsonString());
                Console.WriteLine(character.Appearance.ToJsonString());
                player.Position = character.LastPosition ?? Vector3.RandomXy();
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