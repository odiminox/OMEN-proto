using BSPImporter;
using OMEN.Core.Entity;
using OMEN.Core.Exceptions;
using OMEN.Core.Graphics;
using UnityEngine.Events;

namespace OMEN.Core.Map.BSP
{
    public class BSPMapLoader
    {
        private OMENGraphics _omenGraphics;
        private BSPLoader.Settings _settings;
        private string _mapName;
        private BSPLoader _loader;
        
        private ModLoader.ModLoader _modLoader;
        private EntitySpawner _entitySpawner;

        public BSPMapLoader(ModLoader.ModLoader modLoader,
            EntitySpawner entitySpawner,
            OMENGraphics omenGraphics)
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
            
            // TODO Error handling for omen graphics
            
            _modLoader = modLoader;
            _entitySpawner = entitySpawner;
            _omenGraphics = omenGraphics;
        }

        public void SetMapLoadedCallback(UnityAction callback)
        {
            _loader.MapLoadComplete += callback;
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
            _settings.meshCombineOptions = BSPLoader.MeshCombineOptions.PerMaterial;
            _settings.curveTessellationLevel = 9;
            _settings.texturePath = _modLoader.TexturesPath;
            _settings.materialPath = _modLoader.GeneratedMaterialsPath;

            _loader.TargetShader = _omenGraphics.Shader;
            _loader.settings = _settings;
            _loader.settings.meshCombineOptions = BSPLoader.MeshCombineOptions.PerEntity;
            _loader.settings.entityCreatedCallback = _entitySpawner.OnEntityCreated;
        }

        public void LoadMap()
        {
            _loader.LoadBSP();
        }
    }
}