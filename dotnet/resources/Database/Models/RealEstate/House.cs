using GTANetworkAPI;

namespace Database.Models.RealEstate
{
    public class House : AbstractRealEstate
    {
        private House()
        {
        }
        
        public Vector3 Interior { get; protected set; }
    }
}