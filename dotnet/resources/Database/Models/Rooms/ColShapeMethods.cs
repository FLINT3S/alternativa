using GTANetworkAPI;

namespace Database.Models.Rooms
{
    public partial class ColShape
    {
        private GTANetworkAPI.ColShape instance;
        
        public void SpawnColShape(uint dimension)
        {
            NAPI.Task.WaitForMainThread();
            instance = NAPI.ColShape.CreatCircleColShape(Center.X, Center.Y, Radius, dimension);
        }

        public void DeleteColShape()
        {
            NAPI.ColShape.DeleteColShape(instance);
        }
    }
}