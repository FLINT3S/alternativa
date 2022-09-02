using System;

namespace Database.Models.Economics
{
    public class AbstractTransaction : AbstractModel
    {
        public Guid Id { get; protected set; }

        public double Sum { get; protected set; }
    }
}