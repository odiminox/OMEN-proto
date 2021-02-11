using System;
using OMEN.Core.Entity;
using OMEN.Core.Exceptions;
using OMEN.Core.Graphics;
using OMEN.Core.Map.BSP;
using OMEN.Core.ModLoader;
using OMEN.StatusHandling;
using UnityEngine;
using Whilefun.FPEKit;
using Logger = OMEN.Logging.Logger;

namespace OMEN
{
    public class Main : MonoBehaviour
    {
        [SerializeField] 
        private string _testMapName;
        
        [SerializeField]
        private OMENGraphics _graphics;

        [SerializeField]
        private GameObject _playerInteractionCore;

        private ModLoader _modLoader;
        private EntitySpawner _entitySpawner;
        private BSPMapLoader _bspMapLoader;

        public void Init()
        {
            InitialiseModLoader();
            InitialiseEntitySpawner();
            InitialiseBspMapLoader();
            
            Logger.LogInfo("Main: " + CoreStatusCodes.InfoCoreInitialised);

            _bspMapLoader.SetMapLoadedCallback(OnMapLoadComplete);
            
            _bspMapLoader.SetMapName(_testMapName);
            _bspMapLoader.AssignSettings();
            _bspMapLoader.LoadMap();
        }

        private void OnMapLoadComplete()
        {
            Debug.Log("Map Loaded!");

            Instantiate(_playerInteractionCore);
        }

        private void InitialiseModLoader()
        {
            try
            {
                _modLoader = new ModLoader();
            }
            catch (ModLoaderPathException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (ModDirectoryException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (Exception e)
            {
                Logger.LogError($"Main: {CoreStatusCodes.ErrorUnknown} {e.Message}");
            }
        }

        private void InitialiseEntitySpawner()
        {
            _entitySpawner = new EntitySpawner();
        }

        private void InitialiseBspMapLoader()
        {
            try
            {
                _bspMapLoader = new BSPMapLoader(_modLoader, _entitySpawner, _graphics);
            }
            catch (InvalidModLoaderException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (InvalidEntitySpawnerException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (ModLoaderInitialisedException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (MapLoaderNameException e)
            {
                Logger.LogError("Main: " + e.Message);
            }
            catch (Exception e)
            {
                Logger.LogError($"Main: {CoreStatusCodes.ErrorUnknown} {e.Message}");
            }
        }

        private void Start()
        {
            Init();
        }
    }
}