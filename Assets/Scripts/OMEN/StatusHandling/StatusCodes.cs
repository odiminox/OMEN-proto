using UnityEngine;

namespace OMEN.StatusHandling
{
    public static class CoreStatusCodes
    {
        // These status codes are used to log in unity and the log file written into Game mod folder
        
        // Errors
        public const string ErrorRootPath = "ERR: Failed to grab Game root mod directory";
        public const string ErrorModDirectory = "ERR: Game directory does not exist";
        public const string ErrorModLoaderInitialised = "ERR: Could not initialise Mod Loader as there were path errors";
        public const string ErrorMapName = "ERR: Map name is invalid";
        public const string ErrorEntitySpawner = "ERR: Injected Entity Spawner is null";
        public const string ErrorModLoader = "ERR: Injected Mod loader is null";
        public const string ErrorInvalidFactoryType = "ERR: Provided class name type is invalid";

        public const string ErrorUnknown = "ERR: UNKNOWN EXCEPTION";
        
        // Warnings
        
        // Info
        public const string InfoCoreInitialised = "INFO: Core systems have initialised";
    }
}
