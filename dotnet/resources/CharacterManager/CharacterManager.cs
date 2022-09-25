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

        private void SpawnCharacter(Player player)
        {
            var character = player.GetCharacter();

            // Чтобы персонаж при спавне не проваливался под землю
            character.SpawnData.Position.Z += 0.3f;

            player.ApplyCharacter(character);

            player.Heading = character.SpawnData.Heading;
            player.Position = character.SpawnData.Position;

            NAPI.Player.SpawnPlayer(player, player.Position);

            player.Armor = character.SpawnData.Armor;
            player.Health = character.SpawnData.Health;

            LogPlayer(player, "PlayerSpawned", $"Player spawned at {character.SpawnData.Position}");
        }

        private static Character CreateCharacter(Player player, string characterDto)
        {
            var characterCreatorInfo = JsonConvert.DeserializeObject<CharacterCreatorDto>(characterDto);
            var account = ((Account)player)!;
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
                SpawnCharacter(player);
                ClientConnect.Trigger(player, "OnCharacterSpawned", (int)character.TimeToReborn.TotalSeconds);
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

            var account = AltContext.GetAccount(player)!;
            if (account.CanCreateCharacter())
            {
                LogException(new InvalidOperationException("Exceeding the characters count"));
                return;
            }
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
            character.SpawnData.Position = new Vector3(-1041.3, -2744.6, 21.36);
            SpawnCharacter(player);
            ClientConnect.Trigger(player, "CharacterCreated");
        }

        [RemoteEvent(CharacterManagerEvents.GetOwnCharacters)]
        public void GetOwnCharacters(Player player)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            var account = ((Account)player)!;
            string characters = JsonConvert.SerializeObject(account.Characters, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Formatting = Formatting.Indented
                    }
                );
            CefConnect.TriggerRaw(player, CharacterManagerEvents.GetOwnCharacters + "Answered", characters);
        }

        #endregion
    }
}
