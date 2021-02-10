using BSPImporter;
using OMEN.Core.Entity;
using OMEN.Core.Exceptions;

namespace OMEN.Core.Map.BSP
{
    public class BSPMapLoader
    {
        private BSPLoader.Settings _settings;
        private string _mapName;
        private BSPLoader _loader;
        
        private ModLoader.ModLoader _modLoader;
        private EntitySpawner _entitySpawner;

        public BSPMapLoader(ModLoader.ModLoader modLoader,
            EntitySpawner entitySpawner)
        {
            _settings = new BSPLoader.Settings();
            _loader = new BSPLoader();
            _mapName = "error";

            if (null == modLoader)
            {
                throw new InvalidModLoaderException();
            }

            if (null == entitySpawner)
            {
                throw new InvalidEntitySpawnerException();
            }
            
            _modLoader = modLoader;
            _entitySpawner = entitySpawner;
        }

        public void SetMapName(string name)
        {
            if (!_modLoader.IsInitialised)
            {
                throw new ModLoaderInitialisedException();
            }
            
            if (string.IsNullOrEmpty(name))
            {
                throw new MapLoaderNameException(_mapName);
            }
            
            _mapName = name;

            _settings.path = string.Format($"{_modLoader.MapsPath}/{_mapName}");
        }

        public void AssignSettings()
        {
            // TODO Replace these with configuration file defaults
            _settings.meshCombineOptions = BSPLoader.MeshCombineOptions.PerEntity;
            _settings.curveTessellationLevel = 9;
            _settings.texturePath = _modLoader.TexturesPath;
            _settings.materialPath = _modLoader.GeneratedMaterialsPath;
            
            _loader.settings = _settings;
            _loader.settings.entityCreatedCallback = _entitySpawner.OnEntityCreated;
        }

        public void LoadMap()
        {
            _loader.LoadBSP();
        }
    }
}