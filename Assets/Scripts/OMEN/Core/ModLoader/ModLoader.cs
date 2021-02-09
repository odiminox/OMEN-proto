using System;
using UnityEngine;

using OMEN.Core.Exceptions;

namespace OMEN.Core.ModLoader
{
    public class ModLoader : MonoBehaviour
    {
        protected string modDirRootPath;
        
        protected string mapsPath;
        protected string modelsPath;
        protected string scriptsPath;
        protected string texturesPath;
        protected string configurationPath;
        
        public void FindModDir()
        {
            // TODO Add support for multiple directories Game_1 Game_2 and load highest numerical value
            var dataPath = Application.dataPath;

            modDirRootPath = string.Format($"{dataPath}/Game");
            
            // TODO load settings file to determine custom path locations
            
            if (string.IsNullOrEmpty(modDirRootPath))
            {
                throw new ModLoaderPathException(modDirRootPath);
            }
            
            // Game/maps
            mapsPath = string.Format($"{modDirRootPath}/maps");

            if (string.IsNullOrEmpty(mapsPath))
            {
                throw new ModLoaderPathException(mapsPath);
            }
            
            // TODO do other paths
        }
    }

}

