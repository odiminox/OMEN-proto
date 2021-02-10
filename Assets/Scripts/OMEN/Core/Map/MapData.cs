using System.Collections.Generic;
using OMEN.Core.Entity;

namespace OMEN.Core.Map
{
    public class MapData
    {
        private string name;
        public List<IEntity> entities = new List<IEntity>();

        public MapData(string name)
        {
            this.name = name;
        }
    }
}