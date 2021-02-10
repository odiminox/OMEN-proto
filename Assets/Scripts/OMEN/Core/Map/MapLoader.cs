using BSPImporter;
using OMEN.Core.Entity;
using OMEN.Core.Exceptions;

namespace OMEN.Core.Map
{
    public class MapLoader
    {
        // Loaded relative to Game/maps
        public string mapPath;
        
        protected BSPLoader.Settings settings;

        private EntitySpawner _entitySpawner;
        private ModLoader.ModLoader _modLoader;
        
        public MapLoader()
        {
            
        }
    }
}