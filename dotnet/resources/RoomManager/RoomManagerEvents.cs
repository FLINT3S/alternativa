﻿namespace RoomManager
{
    internal static class RoomManagerEvents
    {
        #region External ColShape Events

        public const string EnterInPolyRoomColShapeToClient = "EnterInPolyRoomColShape";

        public const string EnterInSingleRoomColShapeToClient = "EnterInSingleRoomColShape";

        public const string EnterInRoomFromCef = "CEF:SERVER:RoomManager:EnterInRoom";

        public const string EnterInRoomFailureToClient = "EnterInRoomFailure";

        public const string ExitFromExternalRoomColShapeToClient = "ExitFromExternalRoomColShape";

        #endregion

        #region Internal ColShape Events

        public const string EnterInInternalRoomColShapeToClient = "EnterInInternalRoomColShape";
        
        public const string ExitFromRoomFromCef = "CEF:SERVER:RoomManager:ExitFromRoom";

        public const string ExitFromInternalRoomColShapeToClient = "ExitFromInternalRoomColShape";

        #endregion
    }
}