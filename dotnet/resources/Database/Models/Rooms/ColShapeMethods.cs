﻿using GTANetworkAPI;
using ColShapeEvent = GTANetworkAPI.ColShape.ColShapeEvent;

namespace Database.Models.Rooms
{
    public partial class ColShape
    {
        private GTANetworkAPI.ColShape instance;
        
        public void SpawnColShape(uint dimension = 0U)
        {
            NAPI.Task.WaitForMainThread();
            instance = NAPI.ColShape.CreatCircleColShape(Center.X, Center.Y, Radius, dimension);
        }

        public void DeleteColShape() => NAPI.Task.Run(() => NAPI.ColShape.DeleteColShape(instance));
        
        public event ColShapeEvent OnEntityEnterColShape
        {
            add => instance.OnEntityEnterColShape += value;
            remove => instance.OnEntityEnterColShape -= value;
        }

        public event ColShapeEvent OnEntityExitColShape
        {
            add => instance.OnEntityExitColShape += value;
            remove => instance.OnEntityExitColShape -= value;
        }
    }
}