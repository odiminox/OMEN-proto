using System;
using UnityEngine;

using OMEN.Core.Exceptions;
using UnityEditor;

namespace OMEN.Core.ModLoader
{
    public class ModLoader
    {
        public bool IsInitialised => !string.IsNullOrEmpty(MapsPath) &&
                                     !string.IsNullOrEmpty(TexturesPath) &&
                                     !string.IsNullOrEmpty(GeneratedMaterialsPath);

        public string MapsPath { get; private set; }
        public string TexturesPath { get; private set; }
        public string GeneratedMaterialsPath { get; private set; }

        private string _modDirRootPath;
        
        protected string modelsPath;
        protected string scriptsPath;
        protected string configurationPath;
        
        public ModLoader()
        {
            FindModDir();
        }
        
        private void FindModDir()
        {
            // TODO Add support for multiple directories Game_1 Game_2 and load highest numerical value
            var dataPath = Application.dataPath;

            _modDirRootPath = string.Format($"{dataPath}/Game");
            
            // TODO load settings file to determine custom path locations
            
            if (string.IsNullOrEmpty(_modDirRootPath))
            {
                throw new ModLoaderPathException(_modDirRootPath);
            }
            
            // Game/maps - contains .bsp map files
            MapsPath = string.Format($"{_modDirRootPath}/maps");

            if (string.IsNullOrEmpty(MapsPath))
            {
                throw new ModLoaderPathException(MapsPath);
            }
            
            // Game/textures - textures used in creating maps
            TexturesPath = string.Format($"{_modDirRootPath}/textures");
            
            // Assets/bin/mats - generated .mat files after BSPLoader imports .bsp file into game
            GeneratedMaterialsPath = "Assets/bin/mat";

            // TODO do other paths
        }
    }
}

