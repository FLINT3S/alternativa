using GTANetworkAPI;

namespace Database.Models
{
    public partial class ColShape
    {
        private GTANetworkAPI.ColShape instance;

        public void Spawn(uint dimension = 0U)
        {
            NAPI.Task.WaitForMainThread();
            instance = NAPI.ColShape.CreatCircleColShape(Center.X, Center.Y, Radius, dimension);
        }

        public void Delete() => NAPI.Task.Run(() => NAPI.ColShape.DeleteColShape(instance));
        
        public event GTANetworkAPI.ColShape.ColShapeEvent OnEntityEnter
        {
            add => instance.OnEntityEnterColShape += value;
            remove => instance.OnEntityEnterColShape -= value;
        }

        public event GTANetworkAPI.ColShape.ColShapeEvent OnEntityExit
        {
            add => instance.OnEntityExitColShape += value;
            remove => instance.OnEntityExitColShape -= value;
        }
    }
}