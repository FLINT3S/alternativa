namespace Database.Models.Rooms
{
    public partial class AbstractRealEstate
    {
        public override bool AvailableFor(Character character) => Owner == character;
    }
}