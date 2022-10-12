using System;
using GTANetworkAPI;

namespace Database.Models.Realty
{
    public class Interior : AbstractModel
    {
        protected Interior()
        {
        }

        public Interior(Guid guid, string iplName, Vector3 entrance, Vector3 exit)
        {
            Id = guid;
            IplName = iplName;
            Entrance = entrance;
            Exit = exit;
        }
        
        public string IplName { get; protected set; }
        
        public Vector3 Entrance { get; protected set; }
        
        public Vector3 Exit { get; protected set; }
    }
}