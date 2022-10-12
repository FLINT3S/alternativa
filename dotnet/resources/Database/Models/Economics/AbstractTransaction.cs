namespace Database.Models.Economics
{
    public class AbstractTransaction : AbstractModel
    {
        public double Amount { get; protected set; }
    }
}