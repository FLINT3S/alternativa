using GTANetworkAPI;

namespace Database.Models
{
    public partial class Character
    {
        #region OnEvents

        public void OnDisconnect(Vector3 position)
        {
            LastPosition = position;
            UpdateInContext();
        }

        #endregion
        
        public override string ToString() => $"{Id}: [{FirstName} {LastName}]";
    }
}