namespace Database.Models.Rooms
{
    public partial class AbstractRealEstate
    {
        public override bool AvailableFor(Character player) => Owner == player;
    }
}