using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.Economics.Banks;
using Database.Models.Economics.CryptoWallets;
using GTANetworkAPI;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public partial class Character : AbstractModel
    {
        // ReSharper disable once UnusedMember.Global
        protected Character()
        {
        }

        public Character(Account account, string firstname, string lastname, Sex sex, DateTime birthday)
        {
            Account = account;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
            Sex = sex;
            InGameTime = TimeSpan.Zero;
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
        }

        public Vector3 LastPosition { get; private set; }

        private TimeSpan TimeToReborn { get; set; } = TimeSpan.Zero;

        #region Finances

        public long Cash { get; set; }

        public List<BankAccount> BankAccounts { get; } = new List<BankAccount>();

        public BankAccount MainBankAccount { get; protected set; }

        public List<CryptoWallet> CryptoWallets { get; } = new List<CryptoWallet>();

        #endregion

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

        #endregion
    }
}