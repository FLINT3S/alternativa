namespace RoomManager
{
    internal static class RoomManagerEvents
    {
        public const string OnPolyRoomHouseColShapeEnterToClient = "OnPolyRoomHouseColShapeEnter";

        public const string OnMonoRoomHouseColShapeEnterToClient = "OnMonoRoomHouseColShapeEnter";

        public const string OnExitColShapeEnterToClient = "OnMonoRoomHouseColShapeEnter";

        public const string OnEnterColShapeHouseExitToClient = "OnColShapeExit";

        public const string OnEnterFailureToCef = "OnEnterFailure";

        public const string OnRoomExitToClient = "OnRoomExit";

        public const string EnterInRoomFromCef = "CEF:SERVER:RoomManager:EnterInRoom";

        public const string ExitFromRoomFromCef = "CEF:SERVER:RoomManager:ExitFromRoom";
    }
}