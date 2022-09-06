using System;
using System.Reflection;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;
using Newtonsoft.Json;

namespace CharacterManager
{
    public class CharacterManager : AltAbstractResource
    {
        private static string GetEntityModel(int gender) => (Sex)gender switch
        {
            Sex.Male => "mp_m_freemode_01",
            Sex.Female => "mp_f_freemode_01",
            _ => throw new ArgumentException()
        };

        private void SpawnCharacter(Player player, Vector3 coords)
        {
            var character = player.GetCharacter()!;
            player.ApplyCharacter(character);
            NAPI.Task.Run(
                    () =>
                    {
                        player.Position = coords;
                        NAPI.Player.SpawnPlayer(player, coords);
                        if (character.IsDead) player.Health = 0;
                    }
                );
            LogPlayer(player, "PlayerSpawned", $"Player spawned at {coords}");
        }

        private static Character CreateCharacter(Player player, string characterDto)
        {
            var characterCreatorInfo = JsonConvert.DeserializeObject<CharacterCreatorDto>(characterDto);
            var account = player.GetAccountFromDb()!;
            var character = new Character(account, characterCreatorInfo);
            account.AddCharacter(character);
            return character;
        }

        #region OnRemoteEvent

        [RemoteEvent(CharacterManagerEvents.SelectCharacter)]
        public void OnSelectCharacter(Player player, string rawGuid)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            try
            {
                var character = AltContext.GetCharacter(player, Guid.Parse(rawGuid));
                player.SetCharacter(character);
                SpawnCharacter(player, character.LastPosition ?? new Vector3(-1041.3, -2744.6, 21.36));
                ClientConnect.Trigger(player, "OnCharacterSpawned", character.IsDead);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        [RemoteEvent(CharacterManagerEvents.InitCharacterCreationFromClient)]
        public void InitCharacterCreation(Player player)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            player.Position = new Vector3(-754.459, 318.391, 175.401);
            player.Rotation = new Vector3(-1.7809, 0, -137.35375);
            AnimationManager.AnimationManager.PlayAnimation(player, "misshair_shop@barbers", "idle_a_cam", 1);
            player.TriggerEvent(CharacterManagerEvents.CharacterCreationStart);
            LogPlayer(player, "InitCharacterCreation", "Player was started character creation");
        }

        [RemoteEvent(CharacterManagerEvents.ChangeGenderFromCef)]
        public void ChangeGender(Player player, int gender)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            NAPI.Entity.SetEntityModel(player.Handle, NAPI.Util.GetHashKey(GetEntityModel(gender)));
            AnimationManager.AnimationManager.PlayAnimation(player, "misshair_shop@barbers", "idle_a_cam", 1);
            CefConnect.TriggerRaw(player, CharacterManagerEvents.ChangeGenderFromCef + "Answered");
            ClientConnect.Trigger(player, "GenderChanged", gender);
        }

        [RemoteEvent(CharacterManagerEvents.CharacterCreatedSubmitFromClient)]
        public void CharacterCreated(Player player, string characterDto)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            var character = CreateCharacter(player, characterDto);
            player.SetCharacter(character);
            SpawnCharacter(player, new Vector3(-1041.3, -2744.6, 21.36));
            ClientConnect.Trigger(player, "CharacterCreated");
        }

        #endregion
    }
}