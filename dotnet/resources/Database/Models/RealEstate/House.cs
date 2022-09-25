using System.Diagnostics.CodeAnalysis;
using GTANetworkAPI;

namespace Database.Models.RealEstate
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class House : AbstractRealEstate
    {
        // ReSharper disable once EmptyConstructor
        private House()
        {
        }
        
        public Vector3 Interior { get; protected set; }
    }
}