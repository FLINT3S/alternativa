namespace RoomManager
{
    internal static class RoomManagerEvents
    {
        public const string InteractOnColShapeFromClient = "CLIENT:SERVER:RoomManager:InteractOnColShape";
        
        #region ColShape Events

        public const string OpenHouseInterfaceToClient = "OpenHouseInterface";

        public const string OpenApartmentHouseInterfaceToClient = "OpenApartmentHouseInterface";
        
        #endregion
        
        public const string EnterToHouseFromCef = "CEF:SERVER:RoomManager:EnterToHouse";

        public const string LoadInteriorToClient = "LoadInterior";

        public const string UnloadInteriorToClient = "UnloadInterior";
    }
}