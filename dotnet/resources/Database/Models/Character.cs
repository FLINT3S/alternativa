using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.Economics.Banks;
using Database.Models.Economics.CryptoWallets;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public partial class Character : AbstractModel
    {
        // ReSharper disable once UnusedMember.Global
        protected Character()
        {
        }

        public Character(Account account, CharacterCreatorDto characterCreatorDto)
        {
            Account = account;
            FirstName = characterCreatorDto.Name;
            LastName = characterCreatorDto.Surname;
            Birthday = DateTime.Today.AddYears(-1 * characterCreatorDto.Age);
            Sex = (Sex)characterCreatorDto.Gender;
            InGameTime = TimeSpan.Zero;
            Appearance = new CharacterAppearance(characterCreatorDto);
            Finances = new CharacterFinances();
            SpawnData = new CharacterSpawnData();
        }
        
        public CharacterSpawnData SpawnData { get; protected set; }

        private TimeSpan TimeToReborn { get; set; } = TimeSpan.Zero;

        #region Main Data

        public Guid Id { get; }
        
        public long StaticId { get; }

        public Account Account { get; }

        public TimeSpan InGameTime { get; private set; } = TimeSpan.Zero;

        #endregion

        #region Biography

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Sex Sex { get; private set; }

        public DateTime Birthday { get; private set; }

        public CharacterAppearance Appearance { get; private set; }
        
        public CharacterFinances Finances { get; private set; }

        #endregion
    }
}