using System;
using System.Collections.Generic;
using Database.Models.Realty;
using GTANetworkAPI;

namespace Database.Data
{
    public static class Realty
    {
        public static readonly List<Interior> Interiors = new List<Interior>()
        {
            new Interior(
                new Guid("00000000-0000-0000-0000-000000000001"),
                "TrevorsTrailerTidy",
                "Автодом Тревора",
                new Vector3(1973.35, 3816.34, 33.43),
                new Vector3(1973.35, 3816.34, 33.43),
                new DateTime(2022, 10, 16)
            ),
            new Interior(
                new Guid("00000000-0000-0000-0000-000000000002"),
                string.Empty,
                "Low End Apartment",
                new Vector3(266.3, -1007.4, -101),
                new Vector3(266.3, -1007.4, -101),
                new DateTime(2022, 10, 16),
                false
            ),
            new Interior(
                new Guid("00000000-0000-0000-0000-000000000003"),
                string.Empty,
                "Medium End Apartment	",
                new Vector3(347.26, -999.29, -99.2),
                new Vector3(347.26, -999.29, -99.2),
                new DateTime(2022, 10, 16),
                false
            ),
        };

        // Для вставки объектов с отношениями нужно определять свойство InteriorId вместо Interior
        public static readonly List<object> RealtyPrototypes = new List<object>()
        {
            new {
                Id = new Guid("00000000-0000-0000-0001-000000000001"),
                Name = "Дом эконом-класса",
                InteriorId = Interiors[0].Id,
                Type = RealtyType.House,
                PriceSegment = RealtyPriceSegment.Economy,
                GovernmentPrice = 100_000_000L,
                ParkingPlaces = (byte) 2,
                CreatedDate = new DateTime(2022, 10, 16),
                UpdatedDate = new DateTime(2022, 10, 16)
            }
        };
    }
}