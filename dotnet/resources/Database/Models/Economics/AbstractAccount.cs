using System.Diagnostics.CodeAnalysis;

namespace Database.Models.Economics
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class AbstractAccount : AbstractModel
    {
        public double Amount { get; protected set; }
    }
}