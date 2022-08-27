using System.Collections.Generic;
using AbstractResource;
using Database.Models;

namespace LocalContext
{
    public class EntityLists : AltAbstractResource
    {
        public static readonly List<Account> OnlinePlayers = new List<Account>();
    }
}
