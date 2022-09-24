using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

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

        [JsonProperty("guid")] public Guid Id { get; }

        [JsonProperty("staticId")] public long StaticId { get; }

        [JsonIgnore] public Account Account { get; }

        public TimeSpan InGameTime { get; private set; } = TimeSpan.Zero;

        #endregion

        #region Biography

        [JsonProperty("firstName")] public string FirstName { get; private set; }

        [JsonProperty("lastName")] public string LastName { get; private set; }

        public Sex Sex { get; private set; }

        public DateTime Birthday { get; private set; }

        public CharacterAppearance Appearance { get; private set; }

        public CharacterFinances Finances { get; private set; }

        #endregion
    }
}
