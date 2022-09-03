using System.Collections.Generic;

namespace Database.Models.Economics.Banks
{
    public interface IBankClient
    {
        List<BankAccount> BankAccounts { get; }
    }
}