using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BSPImporter;
using OMEN.Core.Entity;

namespace OMEN.Core.Map
{
    public class MapLoader
    {
        // Loaded relative to Game/maps
        public string mapPath;
        
        protected BSPLoader.Settings settings;

        private EntitySpawner _entitySpawner;
        
        public MapLoader()
        {
            
        }

        public void AssignSettings()
        {
        }
    }
}