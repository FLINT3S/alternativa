using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Models;
using Database.Models.Bans;
using GTANetworkAPI;
using GTANetworkMethods;
using ColShape = GTANetworkAPI.ColShape;
using Player = GTANetworkAPI.Player;

namespace NAPIExtensions
{
    public static class PlayerExtensions
    {
        public static PermanentBan? GetBanByHwid(this Player player)
        {
            using var context = new AltContext();
            return context.Bans.OfType<PermanentBan>().FirstOrDefault(b => b.HWID == player.Serial);
        }

        public static (int VipLevel, int AdminLevel) GetAccessLevels(this Player player) =>
        (
            player.GetOwnSharedData<int>(PlayerConstants.VipLevel),
            player.GetOwnSharedData<int>(PlayerConstants.AdminLevel)
        );

        public static void SetAccessLevels(this Player player, int vipLevel, int adminLevel)
        {
            player.SetOwnSharedData(PlayerConstants.VipLevel, vipLevel);
            player.SetOwnSharedData(PlayerConstants.AdminLevel, adminLevel);
        }

        #region Character

        /// <summary>
        ///     Аккаунт получается из Data и существует только в рантайме
        ///     Для получения аккаунта из базы данных нужно использовать <see cref="AltContext.GetAccount(Player)" />
        /// </summary>
        /// <param name="player">Объект игрока</param>
        /// <returns>Account из <b>player.Data</b></returns>
        public static Character GetCharacter(this Player player) =>
            player.GetData<Character>(PlayerConstants.Character);

        public static void SetCharacter(this Player player, Character character) =>
            player.SetData(PlayerConstants.Character, character);

        public static void ApplyCharacter(this Player player, Character character)
        {
            player.Name = character.Fullname;
            player.ApplyCharacterAppearance(character);
        }

        private static void ApplyCharacterAppearance(this Player player, Character? character)
        {
            #region SetHeadBlend

            Console.WriteLine(character!.Appearance?.ToJsonString());

            var headBlend = new HeadBlend
            {
                ShapeFirst = character.Appearance!.MotherId,
                ShapeSecond = character.Appearance.FatherId,
                ShapeThird = 0,
                SkinFirst = character.Appearance.MotherId,
                SkinSecond = character.Appearance.FatherId,
                SkinThird = 0,
                ShapeMix = character.Appearance.Similarity,
                SkinMix = character.Appearance.SkinSimilarity,
                ThirdMix = 0.0f
            };

            NAPI.Player.SetPlayerHeadBlend(player, headBlend);

            #endregion

            #region SetFaceFeatures

            for (int i = 0; i < character.Appearance.FaceFeatures.Count; i++)
                NAPI.Player.SetPlayerFaceFeature(player, i, character.Appearance.FaceFeatures[i]);

            #endregion
        }

        public static void RemoveCharacter(this Player player) =>
            player.ResetData(PlayerConstants.Character);

        public static IEnumerable<Character> GetActiveCharacters(this Pools pools) =>
            pools.GetAllPlayers().Where(a => a.HasData(PlayerConstants.Character)).Select(a => a.GetCharacter());

        #endregion

        #region Colshape

        /*
         * Колшейпы используются для обработки входа/выхода игрока в зону, хранить их нужно для получения
         * экшенов или прочей даты, использующейся в коллбэках
         */

        public static void SetPlayerColShape(this Player player, ColShape? shape)
        {
            if (shape == null)
            {
                player.ResetData(PlayerConstants.PlayerColshape);
            }
            else
            {
                player.SetData<ColShape>(PlayerConstants.PlayerColshape, shape);
            }
        }

        public static ColShape? GetPlayerColShape(this Player player)
        {
            if (player.HasData(PlayerConstants.PlayerColshape)) return player.GetData<ColShape>(PlayerConstants.PlayerColshape);
            return null;
        }

        #endregion
    }
}