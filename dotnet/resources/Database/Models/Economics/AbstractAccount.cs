using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class AbstractAccount : AbstractModel
    {
        public long Id { get; protected set; }

        public double Sum { get; protected set; }
    }
}