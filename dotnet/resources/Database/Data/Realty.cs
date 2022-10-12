using System;
using System.Collections.Generic;
using Database.Models.Realty;
using GTANetworkAPI;

namespace Database.Data
{
    public static class Realty
    {
        public static List<Interior> Interiors = new List<Interior>()
        {
            new Interior(new Guid("00000000-0000-0000-0000-000000000001"), "TrevorsTrailerTidy", new Vector3(1973.35, 3816.34, 33.43), new Vector3(1973.35, 3816.34, 33.43)),
            new Interior(new Guid("00000000-0000-0000-0000-000000000002"), string.Empty, new Vector3(266.3, -1007.4, -101), new Vector3(266.3, -1007.4, -101)),
        };
    }
}